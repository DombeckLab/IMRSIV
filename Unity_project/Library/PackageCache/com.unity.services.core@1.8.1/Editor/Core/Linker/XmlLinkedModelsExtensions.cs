using System.Reflection;

namespace Unity.Services.Core.Editor
{
    static class XmlLinkedModelsExtensions
    {
        public static XmlLinkedAssembly SetFullName(this XmlLinkedAssembly self, Assembly assembly)
        {
            self.FullName = assembly.GetName().Name;
            return self;
        }

        public static XmlLinkedAssembly SetPreserve(this XmlLinkedAssembly self, XmlLinkedPreserve? preserve)
        {
            self.Preserve = preserve;
            return self;
        }
    }
}
