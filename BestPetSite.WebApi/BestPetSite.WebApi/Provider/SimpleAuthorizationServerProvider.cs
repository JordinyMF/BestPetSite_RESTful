using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BestPetSite.UnitOfWork;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace BestPetSite.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUnitOfWork _unit;
        public SimpleAuthorizationServerProvider()
        {
            _unit = new BestPetSiteUnitOfWork();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _unit.Users.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuario o password incorrecto");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));

            //Response Custom
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "id", user.Id.ToString()
                },
                {
                    "email", user.Email
                },
                {
                    "firstName", user.FirstName
                },
                {
                    "lastName", user.LastName
                },
                {
                    "password", user.Password
                },
                {
                    "status", user.Status.ToString()
                }
            });

            var ticket = new AuthenticationTicket(identity, properties);
            context.Validated(ticket);
            
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                //removed .issued and .expires parameter
                if (!property.Key.StartsWith("."))
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
