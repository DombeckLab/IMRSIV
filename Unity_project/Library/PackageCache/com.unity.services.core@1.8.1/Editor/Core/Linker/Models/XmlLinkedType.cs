using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Unity.Services.Core.Editor
{
    [DataContract(Name = "type")]
    class XmlLinkedType
    {
        /// <example>
        /// * Generic type name: "AssemblyName.TypeName`1"
        /// * Preserve a nested type:"AssemblyName.ParentTypeName/NestedTypeName"
        /// * Preserve all types in a namespace: "AssemblyName.SomeNamespace*"
        /// * Preserve all types with a common prefix in their name: "Prefix*"
        /// </example>
        [DataMember(Name = "@fullname", IsRequired = true)]
        public string FullName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "@preserve", IsRequired = false, EmitDefaultValue = false)]
        public XmlLinkedPreserve? Preserve { get; set; }

        [DataMember(Name = "@required", IsRequired = false, EmitDefaultValue = false)]
        int? SerializedRequired { get; set; }

        /// <summary>
        /// Preserve type only if it is used.
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public bool? Required
        {
            get => SerializedRequired.HasValue ? SerializedRequired.Value != 0 : (bool?)null;
            set
            {
                if (value is null)
                {
                    SerializedRequired = null;
                }
                else
                {
                    SerializedRequired = value == true ? 1 : 0;
                }
            }
        }

        [DataMember(Name = "event", IsRequired = false, EmitDefaultValue = false)]
        public List<XmlLinkedEvent> Events { get; set; }

        [DataMember(Name = "field", IsRequired = false, EmitDefaultValue = false)]
        public List<XmlLinkedField> Fields { get; set; }

        [DataMember(Name = "property", IsRequired = false, EmitDefaultValue = false)]
        public List<XmlLinkedProperty> Properties { get; set; }

        [DataMember(Name = "method", IsRequired = false, EmitDefaultValue = false)]
        public List<XmlLinkedMethod> Methods { get; set; }
    }
}
