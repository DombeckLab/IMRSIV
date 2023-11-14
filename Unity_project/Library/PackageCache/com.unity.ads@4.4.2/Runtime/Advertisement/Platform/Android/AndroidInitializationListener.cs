using System;
using UnityEngine.Advertisements.Utilities;

namespace UnityEngine.Advertisements {
    internal class AndroidInitializationListener : AndroidJavaProxy {

        private const string CLASS_REFERENCE = "com.unity3d.ads.IUnityAdsInitializationListener";
        private IUnityAdsInitializationListener m_ManagedListener;

        public AndroidInitializationListener(IUnityAdsInitializationListener initializationListener) : base(CLASS_REFERENCE) {
            m_ManagedListener = initializationListener;
        }

        public void onInitializationComplete()
        {
            m_ManagedListener?.OnInitializationComplete();
        }

        public void onInitializationFailed(AndroidJavaObject error, string message)
        {
            m_ManagedListener?.OnInitializationFailed(EnumUtilities.GetEnumFromAndroidJavaObject(error, UnityAdsInitializationError.UNKNOWN), message);
        }
    }
}
