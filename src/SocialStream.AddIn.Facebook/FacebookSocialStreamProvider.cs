using System;
using Facebook;
using SocialStream.AddIn;

namespace SocialStream.AddIn.Facebook
{
    [SocialStreamProvider("TesssssstFacebook")]
    internal class FacebookSocialStreamProvider:ISocialStreamProvider
    {

        public StreamItemCollection GetStreamItemCollection()
        {
            try
            {
                ExtendAccesstoken();


                string accesstoken = "";

                string appid = "";
                string appsecret = ""; 


                FacebookClient client = new FacebookClient();
                dynamic Me = client.Get(@"me/home");



                string aboutMe = Me.about;


            }
            catch (Exception exc)
            {
                
                throw;
            }
           
            return null;
        }



        public StreamItemCollection ExtendAccesstoken()
        {
            try
            {
                string accesstoken = "";

                string appid = "";
                string appsecret = "";


                FacebookClient client = new FacebookClient();
                dynamic Me = client.Get("oauth/access_token", new
                {
                    client_id = appid,
                    client_secret = appsecret,
                    grant_type = "fb_exchange_token",
                    fb_exchange_token = accesstoken,
                    redirect_uri ="http://www.example.com",
                });



               


            }
            catch (Exception exc)
            {

                throw;
            }

            return null;
        }
    }
}