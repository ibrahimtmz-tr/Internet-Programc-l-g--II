﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HaberBülteniAPİ.Auth
{
    namespace myoBlog32API.Auth
    {
        public class AuthProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }

            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {

                //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" }); // Farklı domainlerden istek sorunu yaşamamak için

                //Burada kendi authentication yöntemimizi belirleyebiliriz.Veritabanı bağlantısı vs...
                var uyeServis = new uyeService();
                var uye = uyeServis.UyeOturumAc(context.UserName, context.Password);
                List<string> uyeYetki = new List<string>();

                if (uye != null)
                {
                    string yetki = "";
                    if (uye.uyeYetki =="Admin")
                    {
                        yetki = "Admin";

                    }
                    else
                    {
                        yetki = "Uye";
                    }
                    uyeYetki.Add(yetki);

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, yetki));
                    identity.AddClaim(new Claim(ClaimTypes.PrimarySid, uye.uyeId.ToString()));

                    AuthenticationProperties propert = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "uyeId", uye.uyeId.ToString() },
                    { "uyeKadi", uye.uyeMail },
                    { "uyeYetki",Newtonsoft.Json.JsonConvert.SerializeObject(uyeYetki) }

               });
                    AuthenticationTicket ticket = new AuthenticationTicket(identity, propert);


                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("Geçersiz istek", "Hatalı kullanıcı bilgisi");
                }



            }
            public override Task TokenEndpoint(OAuthTokenEndpointContext context)
            {
                foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
                {
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
                }

                return Task.FromResult<object>(null);
            }
        }
    }
}