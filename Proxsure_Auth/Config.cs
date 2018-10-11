// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Proxsure_Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("ProxsureAPI1", "Proxsure API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {

                 new Client
                {
                    ClientId = "ProxsureClient",
                    ClientName="Proxsure Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = 
                    {
                        new Secret("LP-SUND-4K4£-3GW@-0LU)-4K3!-18".Sha256())
                    },
                    AllowedScopes = { "ProxsureAPI1" }
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "ProxsureSPA",
                    ClientName="Proxsure SPA Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets = 
                    {
                        new Secret("LP-SUND-4K4£-3GW@-0LU)-4K3!-18".Sha256())
                    },
                    AllowedCorsOrigins=
                    {

                    },
                    AllowedScopes = { "ProxsureAPI1" }
                },

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets = 
                    {
                        new Secret("LP-SUND-4K4£-3GW@-0LU)-4K3!-18".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ProxsureAPI1"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}
