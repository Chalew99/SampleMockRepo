using BasicAuthenticationUsingClientSideMessageHandler.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(BasicAuthenticationUsingClientSideMessageHandler.Startup))]

namespace BasicAuthenticationUsingClientSideMessageHandler
{
    // In this class we will Configure the OAuth Authorization Server.
    //public class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        // Enable CORS (cross origin resource sharing) for making request using browser from different domains
    //        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

    //        OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
    //        {
    //            AllowInsecureHttp = true,
    //            //The Path For generating the Toekn
    //            TokenEndpointPath = new PathString("/token"),
    //            //Setting the Token Expired Time (24 hours)
    //            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
    //            //MyAuthorizationServerProvider class will validate the user credentials
    //            Provider = new MyAuthorizationServerProvider()
    //        };
    //        //Token Generations
    //        app.UseOAuthAuthorizationServer(options);
    //        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

    //        HttpConfiguration config = new HttpConfiguration();
    //        WebApiConfig.Register(config);
    //    }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
                {
                    
                    
                    AllowInsecureHttp = true,
                    //The Path For generating the Toekn
                    TokenEndpointPath = new PathString("/token"),
                    //Setting the Token Expired Time (30 minutes)
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                    //MyAuthorizationServerProvider class will validate the user credentials
                    Provider = new MyAuthorizationServerProvider(),
                    //For creating the refresh token and regenerate the new access token
                    RefreshTokenProvider = new RefreshTokenProvider()
                };

            
            app.UseOAuthAuthorizationServer(options);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

                HttpConfiguration config = new HttpConfiguration();
                WebApiConfig.Register(config);
            }
        }
    //}
}
