using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BestPetSite.WebApi.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace BestPetSite.WebApi
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/bestpetsite/api/v1/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}