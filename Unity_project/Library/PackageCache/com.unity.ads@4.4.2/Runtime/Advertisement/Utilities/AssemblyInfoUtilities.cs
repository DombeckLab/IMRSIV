using System;
using System.Reflection;

namespace UnityEngine.Advertisements.Utilities {
    public static class AssemblyInfoUtilities {
        public static string GetCurrentAssemblyInfoVersion() {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
