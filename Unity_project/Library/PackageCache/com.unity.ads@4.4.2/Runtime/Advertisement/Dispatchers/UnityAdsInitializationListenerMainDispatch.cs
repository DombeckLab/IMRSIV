using UnityEngine.Advertisements.Utilities;

namespace UnityEngine.Advertisements {

    internal class UnityAdsInitializationListenerMainDispatch : IUnityAdsInitializationListener
    {
        private IUnityAdsInitializationListener m_InitializationListener;
        private IUnityLifecycleManager m_LifecycleManager;

        public UnityAdsInitializationListenerMainDispatch(IUnityAdsInitializationListener initializationListener, IUnityLifecycleManager lifecycleManager)
        {
            m_InitializationListener = initializationListener;
            m_LifecycleManager = lifecycleManager;
        }

        public void OnInitializationComplete()
        {
            m_LifecycleManager.Post(() => { m_InitializationListener?.OnInitializationComplete(); });
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            m_LifecycleManager.Post(() => { m_InitializationListener?.OnInitializationFailed(error, message); });
        }
    }
}
