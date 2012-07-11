using SocialStream.AddIn;

namespace SocialStream.AddIn.Facebook
{
    [SocialStreamProvider("TesssssstFacebook")]
    internal class FacebookSocialStreamProvider:ISocialStreamProvider
    {

        public string ProviderName
        {
            get { return "TestFacebook"; }
        }
    }
}