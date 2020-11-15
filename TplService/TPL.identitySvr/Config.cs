using IdentityServer4;
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

        public static IEnumerable<ApiResource> GetAllApi()
        {
            return new List<ApiResource>  {
                 new ApiResource("TplApi", "Customer Api for TplApi")
                 {
                     Scopes={ "CarInfo" }
                 }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
              new ApiScope(name: "CarInfo",   displayName: "Read your data.")

             };

        //client_id უნდა იყოს გნსხვავებული და რიცხვები
        public static IEnumerable<Client> GetClients() =>
           new List<Client>
               {
                   new Client
                  {
                    ClientId="1121",
                    ClientSecrets =    { new Secret("client_secrets".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "CarInfo" }
                   },
                     new Client
                   {
                    ClientId="1122",
                    ClientSecrets =    { new Secret("client_secrets".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "CarInfo" }
                     },

             };

    }

}


