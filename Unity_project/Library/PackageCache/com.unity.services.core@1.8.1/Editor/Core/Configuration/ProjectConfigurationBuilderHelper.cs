using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Unity.Services.Core.Configuration.Editor
{
    static class ProjectConfigurationBuilderHelper
    {
        public static string RuntimeConfigFullPath { get; }
            = Path.Combine(Application.streamingAssetsPath, ConfigurationUtils.ConfigFileName);

        public static void GenerateConfigFileInProject(ProjectConfigurationBuilder builder)
        {
            var config = builder.BuildConfiguration();
            var serializedConfig = JsonConvert.SerializeObject(config);
            AddConfigToProject(serializedConfig);
        }

        internal static void AddConfigToProject(string config)
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            File.WriteAllText(RuntimeConfigFullPath, config);
            AssetDatabase.Refresh();
        }


    }
}
