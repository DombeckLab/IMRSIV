using System.Runtime.Serialization;

namespace Unity.Services.Core.Editor
{
    [DataContract(Name = "preserve")]
    enum XmlLinkedPreserve
    {
        /// <summary>
        /// Preserve the entirety of the element.
        /// </summary>
        [EnumMember(Value = "all")]
        All = default,
        /// <summary>
        /// Force element to be processed for roots but don’t explicitly preserve anything in particular.
        /// </summary>
        /// <remarks>
        /// Useful when the assembly isn't referenced.
        /// </remarks>
        [EnumMember(Value = "nothing")]
        Nothing,
        /// <summary>
        /// Preserve all fields on a type.
        /// </summary>
        [EnumMember(Value = "fields")]
        Fields,
        /// <summary>
        /// Preserve all fields on a type.
        /// </summary>
        [EnumMember(Value = "methods")]
        Methods,
    }
}
