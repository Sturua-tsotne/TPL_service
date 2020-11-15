using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.identitySvr
{
    public class Config
    {

        public static List<TestUser> GetUser()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="tsotne1",
                    Password="tsotne"
                },
                 new TestUser
                {
                    SubjectId="2",
                    Username="tsotne2",
                    Password="tsotne"
                },
                  new TestUser
                {
                    SubjectId="3",
                    Username="tsotne3",
                    Password="tsotne"
                }
            };
        }


        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
             {
                 new ApiResource("tplApi", "Customer Api For TplService")
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
                    ClientId="client1",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "tplApi" }
                },

                new Client
                {
                    ClientId="client2",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "tplApi" }
                },
                 new Client
                {
                    ClientId="client3",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "tplApi" }
                }
            };
        }
    }
}
