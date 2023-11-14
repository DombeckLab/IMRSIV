using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Unity.Services.Core.Editor
{
    /// <summary>
    /// Preserve types and members in an assembly.
    /// </summary>
    [DataContract(Name = "assembly")]
    class XmlLinkedAssembly
    {
        [DataMember(Name = "@fullname", IsRequired = true)]
        public string FullName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "@preserve", IsRequired = false, EmitDefaultValue = false)]
        public XmlLinkedPreserve? Preserve { get; set; }

        [DataMember(Name = "@ignoreIfMissing", IsRequired = false, EmitDefaultValue = false)]
        int? SerializedIgnoreIfMissing { get; set; }

        /// <summary>
        /// Use this attribute if you need to declare preservations for
        /// an assembly that doesn't exist during all Player builds.
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public bool? IgnoreIfMissing
        {
            get => SerializedIgnoreIfMissing.HasValue ? SerializedIgnoreIfMissing.Value != 0 : (bool?)null;
            set
            {
                if (value is null)
                {
                    SerializedIgnoreIfMissing = null;
                }
                else
                {
                    SerializedIgnoreIfMissing = value == true ? 1 : 0;
                }
            }
        }

        [DataMember(Name = "@ignoreIfUnreferenced", IsRequired = false, EmitDefaultValue = false)]
        int? SerializedIgnoreIfUnreferenced { get; set; }

        /// <summary>
        /// In some cases, you might want to preserve entities in an assembly
        /// only when that assembly is referenced by another assembly.
        /// Use this attribute to preserve the entities in an assembly
        /// only when at least one type is referenced in an assembly.
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public bool? IgnoreIfUnreferenced
        {
            get => SerializedIgnoreIfUnreferenced.HasValue ? SerializedIgnoreIfUnreferenced.Value != 0 : (bool?)null;
            set
            {
                if (value is null)
                {
                    SerializedIgnoreIfUnreferenced = null;
                }
                else
                {
                    SerializedIgnoreIfUnreferenced = value == true ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// When you define preservations for a Windows Runtime Metadata
        /// (.winmd) assembly, you must add this attribute.
        /// </summary>
        [DataMember(Name = "@windowsruntime", IsRequired = false, EmitDefaultValue = false)]
        public bool? WindowsRuntime { get; set; }

        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public List<XmlLinkedType> Types { get; set; }
    }
}
