using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Unity.Services.Core.Editor
{
    [DataContract(Name = "property")]
    class XmlLinkedProperty : XmlLinkedMember
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "accessor", IsRequired = false, EmitDefaultValue = false)]
        public XmlLinkedAccessors? Accessors { get; set; }
    }
}
