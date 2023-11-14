using System.Runtime.Serialization;

namespace Unity.Services.Core.Editor
{
    [DataContract]
    abstract class XmlLinkedMember
    {
        /// <example>
        /// Standard:
        /// * System.Int32 FieldName
        /// * System.Int32 PropertyName
        /// * System.Void MethodName()
        /// * System.Void MethodName(System.Int32,System.String)
        /// * System.EventHandler EventName
        ///
        /// With Generics:
        /// * System.Collections.Generic.List`1&lt;System.Int32&gt; FieldName
        /// * System.Collections.Generic.List`1&lt;T&gt; PropertyName
        /// * System.Void MethodName(System.Collections.Generic.List`1&lt;System.Int32&gt;)
        /// * System.EventHandler`1&lt;System.EventArgs&gt; EventName
        /// </example>
        [DataMember(Name = "@signature", EmitDefaultValue = false, IsRequired = false)]
        public string Signature { get; set; }

        [DataMember(Name = "@name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }
    }
}
