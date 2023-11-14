using System;
using System.IO;
using Newtonsoft.Json;
using Unity.Services.Core.Internal;
using UnityEngine;
using NotNull = JetBrains.Annotations.NotNullAttribute;

namespace Unity.Services.Core.Telemetry.Internal
{
    abstract class FileCachePersister
    {
        internal static bool IsAvailableFor(RuntimePlatform platform)
        {
            return !string.IsNullOrEmpty(GetPersistentDataPathFor(platform));
        }

        internal static string GetPersistentDataPathFor(RuntimePlatform platform)
        {
            // Application.persistentDataPath has side effects on Switch so it shouldn't be called.
            if (platform == RuntimePlatform.Switch)
                return string.Empty;

            return Application.persistentDataPath;
        }
    }

    class FileCachePersister<TPayload> : FileCachePersister, ICachePersister<TPayload>
        where TPayload : ITelemetryPayload
    {
        const string k_MultipleInstanceDiagnosticsName = "telemetry_cache_file_multiple_instances_exception";
        const string k_CacheFileException = "telemetry_cache_file_exception";
        const string k_MultipleInstanceError =
            "This exception is most likely caused by a multiple instance file sharing violation.";

        readonly CoreDiagnostics m_Diagnostics;

        public FileCachePersister(string fileName, CoreDiagnostics diagnostics)
        {
            FilePath = Path.Combine(GetPersistentDataPathFor(Application.platform), fileName);
            m_Diagnostics = diagnostics;
        }

        public string FilePath { get; }

        public bool CanPersist { get; } = IsAvailableFor(Application.platform);

        public void Persist(CachedPayload<TPayload> cache)
        {
            if (cache.IsEmpty())
            {
                return;
            }

            try
            {
                var serializedEvents = JsonConvert.SerializeObject(cache);
                File.WriteAllText(FilePath, serializedEvents);
            }
            catch (IOException e)
                when (TelemetryUtils.LogTelemetryException(e))
            {
                var exception = new IOException(k_MultipleInstanceError, e);
                CoreLogger.LogTelemetry(exception);
                m_Diagnostics.SendCoreDiagnosticsAsync(k_MultipleInstanceDiagnosticsName, exception);
            }
            catch (Exception e)
                when (TelemetryUtils.LogTelemetryException(e, true))
            {
                m_Diagnostics.SendCoreDiagnosticsAsync(k_CacheFileException, e);
            }
        }

        public bool TryFetch(out CachedPayload<TPayload> persistedCache)
        {
            persistedCache = default;

            if (!File.Exists(FilePath))
            {
                return false;
            }

            try
            {
                var rawPersistedCache = File.ReadAllText(FilePath);
                persistedCache = JsonConvert.DeserializeObject<CachedPayload<TPayload>>(rawPersistedCache);
                return persistedCache != null;
            }
            catch (IOException e)
            {
                var exception = new IOException(k_MultipleInstanceError, e);
                CoreLogger.LogTelemetry(exception);
                m_Diagnostics.SendCoreDiagnosticsAsync(k_MultipleInstanceDiagnosticsName, exception);
                return false;
            }
            catch (Exception e)
                when (TelemetryUtils.LogTelemetryException(e, true))
            {
                m_Diagnostics.SendCoreDiagnosticsAsync(k_CacheFileException, e);
                return false;
            }
        }

        public void Delete()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            try
            {
                File.Delete(FilePath);
            }
            catch (IOException e)
            {
                var exception = new IOException(k_MultipleInstanceError, e);
                CoreLogger.LogTelemetry(exception);
                m_Diagnostics.SendCoreDiagnosticsAsync(k_MultipleInstanceDiagnosticsName, exception);
            }
            catch (Exception e)
                when (TelemetryUtils.LogTelemetryException(e, true))
            {
                m_Diagnostics.SendCoreDiagnosticsAsync(k_CacheFileException, e);
            }
        }
    }
}
