using UnityEngine.Advertisements.Utilities;

namespace UnityEngine.Advertisements {

    internal class UnityAdsLoadListenerMainDispatch : IUnityAdsLoadListener
    {
        private IUnityAdsLoadListener m_LoadListener;
        private IUnityLifecycleManager m_LifecycleManager;

        public UnityAdsLoadListenerMainDispatch(IUnityAdsLoadListener loadListener, IUnityLifecycleManager lifecycleManager)
        {
            m_LoadListener = loadListener;
            m_LifecycleManager = lifecycleManager;
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            m_LifecycleManager.Post(() => { m_LoadListener?.OnUnityAdsAdLoaded(placementId); });
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            m_LifecycleManager.Post(() => { m_LoadListener?.OnUnityAdsFailedToLoad(placementId, error, message); });
        }
    }
}
