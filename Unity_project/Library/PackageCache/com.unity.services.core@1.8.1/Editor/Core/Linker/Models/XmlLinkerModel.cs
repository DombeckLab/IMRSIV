using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Unity.Services.Core.Editor
{
    /// <remarks>
    /// Checkout <see href="https://docs.unity3d.com/Manual/ManagedCodeStripping.html"/> for more info.
    /// </remarks>
    [DataContract(Name = "linker")]
    class XmlLinkerModel
    {
        [DataMember(Name = "assembly", IsRequired = true, EmitDefaultValue = false)]
        public List<XmlLinkedAssembly> Assemblies { get; set; }
    }
}
