using System.Runtime.Serialization;

namespace Unity.Services.Core.Editor
{
    [DataContract(Name = "accessor")]
    enum XmlLinkedAccessors
    {
        [EnumMember(Value = "all")]
        All = default,
        [EnumMember(Value = "get")]
        Get,
        [EnumMember(Value = "set")]
        Set,
    }
}
