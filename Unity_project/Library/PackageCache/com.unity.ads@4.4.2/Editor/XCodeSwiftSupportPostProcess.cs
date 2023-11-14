#if !UNITY_2020_1_OR_NEWER  && UNITY_IOS
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
 
public class XCodeSwiftSupportPostProcess
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string path)
    {
        string projPath = PBXProject.GetPBXProjectPath(path);
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);
        
        string targetGuid = GetTargetGUID(proj);
        proj.SetBuildProperty(targetGuid, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
        if (ShouldAddSwiftVersion()) 
        {
            proj.SetBuildProperty(targetGuid, "SWIFT_VERSION", "5.0");
        }
        
        proj.WriteToFile(projPath);
    }

    private static bool ShouldAddSwiftVersion() {
         #if UNITY_2019_1_OR_NEWER
            return false;
        #else
            return true;
        #endif
    } 

    private static string GetTargetGUID(PBXProject project) {
        #if UNITY_2019_3_OR_NEWER
            return project.GetUnityFrameworkTargetGuid();
        #else
            return project.TargetGuidByName(PBXProject.GetUnityTargetName());
        #endif
    }
}

#endif //UNITY_2018_1_OR_NEWER