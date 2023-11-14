using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Unity.Services.Core.Configuration.Editor;
using Unity.Services.Core.Internal;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.UnityLinker;
using UnityEditorInternal;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace Unity.Services.Core.Editor
{
    class LinkFileGenerator : IUnityLinkerProcessor
    {
        const string k_LinkerFileName = "link.xml";

        internal static readonly string LinkerFilePath
            = Path.Combine(AssetUtils.CoreLibraryFolderPath, k_LinkerFileName);

        int IOrderedCallback.callbackOrder { get; }

        internal static string GenerateAdditionalLinkXmlFile(IEnumerable<Assembly> packageAssemblies)
        {
            // Cleanup old linker file.
            if (File.Exists(LinkerFilePath))
            {
                File.Delete(LinkerFilePath);
            }

            var linkedAssemblies = GetLinkedAssemblies(packageAssemblies);
            if (!linkedAssemblies.Any())
                return null;

            var linker = new XmlLinkerModel
            {
                Assemblies = linkedAssemblies,
            };
            CreateLinkerFile(linker);

            var fullPath = Path.GetFullPath(LinkerFilePath);
            return fullPath;
        }

        internal static List<XmlLinkedAssembly> GetLinkedAssemblies(IEnumerable<Assembly> packageAssemblies)
        {
            return packageAssemblies
                .Select(CreateLinkedAssemblyFrom)
                .Where(x => !(x is null))
                .OrderBy(x => x.FullName)
                .ToList();
        }

        internal static XmlLinkedAssembly CreateLinkedAssemblyFrom(Assembly assembly)
        {
            return new XmlLinkedAssembly()
                .SetFullName(assembly)
                .SetPreserve(XmlLinkedPreserve.Nothing);
        }

        internal static void CreateLinkerFile(XmlLinkerModel linker)
        {
            if (!Directory.Exists(AssetUtils.CoreLibraryFolderPath))
            {
                Directory.CreateDirectory(AssetUtils.CoreLibraryFolderPath);
            }

            var linkerJson = JsonConvert.SerializeObject(linker);
            var xmlLinker = JsonConvert.DeserializeXmlNode(linkerJson, "linker");
            File.WriteAllText(LinkerFilePath, xmlLinker.InnerXml);
        }

        string IUnityLinkerProcessor.GenerateAdditionalLinkXmlFile(BuildReport report, UnityLinkerBuildPipelineData data)
        {
            var coreAssemblyNames = GetCoreAssemblyNames();
            var eligibleProviderPackageNames = TypeCache.GetTypesDerivedFrom<IServiceComponent>()
                .Where(x => !x.IsAbstract && !coreAssemblyNames.Contains(x.Assembly.GetName().Name))
                .Select(x => PackageInfo.FindForAssembly(x.Assembly))
                .GroupBy(x => x.name)
                .Select(x => x.Key)
                .ToList();
            var packagesToLink = TypeCache.GetTypesDerivedFrom<IInitializablePackage>()
                .Where(
                    x =>
                    {
                        var package = PackageInfo.FindForAssembly(x.Assembly);
                        return eligibleProviderPackageNames.Contains(package.name);
                    })
                .GroupBy(x => x.Assembly)
                .Select(x => x.Key)
                .ToList();

            return GenerateAdditionalLinkXmlFile(packagesToLink);
        }

        static IEnumerable<string> GetCoreAssemblyNames()
        {
            var corePackage = PackageInfo.FindForAssembly(typeof(LinkFileGenerator).Assembly);
            var coreAssemblyNames = AssetDatabase.FindAssets(
                $"t:{nameof(AssemblyDefinitionAsset)}",
                new[] { corePackage.assetPath })
                .Select(GetAssemblyNameFrom)
                .ToList();
            return coreAssemblyNames.ToList();

            string GetAssemblyNameFrom(string assetGuid)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                var assemblyDefinition = AssetDatabase.LoadAssetAtPath<AssemblyDefinitionAsset>(assetPath);
                return assemblyDefinition.name;
            }
        }

#if !UNITY_2021_2_OR_NEWER
        void IUnityLinkerProcessor.OnBeforeRun(BuildReport report, UnityLinkerBuildPipelineData data)
        {
            // Nothing to setup.
        }

        void IUnityLinkerProcessor.OnAfterRun(BuildReport report, UnityLinkerBuildPipelineData data)
        {
            // Nothing to cleanup.
        }

#endif
    }
}
