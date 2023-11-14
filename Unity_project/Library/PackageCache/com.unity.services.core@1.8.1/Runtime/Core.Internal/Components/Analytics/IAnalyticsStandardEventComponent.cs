using System.Collections.Generic;
using Unity.Services.Core.Internal;
#if UNITY_2020_2_OR_NEWER
using UnityEngine.Scripting;
#endif

// We can't use "Unity.Services.Analytics.Internal" because of a compatibility issue with User Reporting 2.0.4.
namespace Unity.Services.Core.Analytics.Internal
{
    /// <summary>
    /// Contract for sending a standard event to the analytics pipeline.
    /// </summary>
#if UNITY_2020_2_OR_NEWER
    [RequireImplementors]
#endif
    public interface IAnalyticsStandardEventComponent : IServiceComponent
    {
        /// <summary>
        /// Records a standard event.
        /// </summary>
        /// <param name="eventName">
        /// The name of the standard event.
        /// </param>
        /// <param name="eventParameters">
        /// The parameters of the standard event.
        /// Only the parameters specific to this event should be sent.
        /// </param>
        /// <param name="eventVersion">
        /// The version of the standard event.
        /// </param>
        /// <param name="packageName">
        /// The name of the package recording the standard event.
        /// </param>
        void Record(
            string eventName, IDictionary<string, object> eventParameters, int eventVersion, string packageName);
    }
}
