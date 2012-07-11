using System;
using System.ComponentModel.Composition;

namespace SocialStream.AddIn
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SocialStreamProviderAttribute : ExportAttribute
    {
        public SocialStreamProviderAttribute(string providerName)
            : base(typeof(ISocialStreamProvider))
        {
            ProviderName = providerName;
        }

        public string ProviderName { get; private set; }
    }
}