using System;
using UnityEngine.Advertisements.Utilities;

namespace UnityEngine.Advertisements {

    internal class UnityAdsShowListenerMainDispatch : IUnityAdsShowListener
    {
        private IUnityAdsShowListener m_ShowListener;
        private IUnityLifecycleManager m_LifecycleManager;
        public UnityAdsShowListenerMainDispatch(IUnityAdsShowListener showListener, IUnityLifecycleManager lifecycleManager)
        {
            m_ShowListener = showListener;
            m_LifecycleManager = lifecycleManager;
        }
        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            m_LifecycleManager.Post(() => { m_ShowListener?.OnUnityAdsShowFailure(placementId, error, message); });
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            m_LifecycleManager.Post(() => { m_ShowListener?.OnUnityAdsShowStart(placementId); });
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            m_LifecycleManager.Post(() => { m_ShowListener?.OnUnityAdsShowClick(placementId); });
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            m_LifecycleManager.Post(() => { m_ShowListener?.OnUnityAdsShowComplete(placementId, showCompletionState); });
        }
    }
}
