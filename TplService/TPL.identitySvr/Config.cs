using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.identitySvr
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
             {
                 new ApiResource("tpl", "Customer Api For TplService")
                 {
                     Scopes={ "tplApi" }
                 }
             };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
           {
            new ApiScope(name: "tplApi",   displayName: "Read your data.")

          };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="TplVueJsclient",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("vue.js".Sha256())
                    },
                    AllowedScopes={ "tplApi_identity" }
                }
            };
        }
    }
}
