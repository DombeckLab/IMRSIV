using System.Collections.Generic;
using UnityEditor;
using Unity.Services.Core.Scheduler.Internal;
using UnityEngine.LowLevel;

namespace Unity.Services.Core.Editor
{
    class ActionSchedulerCleaner
    {
        static ActionSchedulerCleaner s_EditorInstance;

        readonly List<PlayerLoopSystem> m_CachedRegisteredSchedulerSystems = new List<PlayerLoopSystem>();

        internal IReadOnlyList<PlayerLoopSystem> CachedRegisteredSchedulerSystems
            => m_CachedRegisteredSchedulerSystems;

        [InitializeOnLoadMethod]
        static void RegisterSchedulerCleaner()
        {
            if (s_EditorInstance is null)
            {
                s_EditorInstance = new ActionSchedulerCleaner();
            }

            EditorApplication.playModeStateChanged -= s_EditorInstance.OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += s_EditorInstance.OnPlayModeStateChanged;
        }

        void OnPlayModeStateChanged(PlayModeStateChange playModeState)
        {
            switch (playModeState)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    CacheAllSchedulerSystemsFrom(PlayerLoop.GetCurrentPlayerLoop());
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    ClearNonCachedRegisteredSchedulersSystems();
                    break;
            }
        }

        internal void CacheAllSchedulerSystemsFrom(PlayerLoopSystem playerLoop)
        {
            m_CachedRegisteredSchedulerSystems.Clear();
            foreach (var system in playerLoop.subSystemList)
            {
                if (system.type == typeof(ActionScheduler))
                {
                    m_CachedRegisteredSchedulerSystems.Add(system);
                }
            }
        }

        internal void ClearNonCachedRegisteredSchedulersSystems()
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            var currentSubSystems = new List<PlayerLoopSystem>(currentPlayerLoop.subSystemList);
            currentSubSystems.RemoveAll(IsNonCachedSchedulerSystem);
            ActionScheduler.UpdateCurrentPlayerLoopWith(currentSubSystems, currentPlayerLoop);

            bool IsNonCachedSchedulerSystem(PlayerLoopSystem system)
            {
                return system.type == typeof(ActionScheduler)
                    && !m_CachedRegisteredSchedulerSystems.Contains(system);
            }
        }
    }
}
