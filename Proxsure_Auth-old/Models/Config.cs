
// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Proxsure_Auth.Models
{
    public class Config
{
        public static string customSecret { get; set; }

        public Config(IOptions<InternalConfig> internalConfig)
    {
            customSecret = internalConfig.Value.Secret;
        }
    
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Proxsure_API", "Proxsure")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            
            // client credentials client
            return new List<Client>
            {
                // new Client
                // {
                //     ClientId = "client",
                //     AllowedGrantTypes = GrantTypes.ClientCredentials,

                //     ClientSecrets = 
                //     {
                //         new Secret("secret".Sha256())
                //     },
                //     AllowedScopes = { "Proxsure_API" }
                // },

                // // resource owner password grant client
                new Client
                {
                      ClientId = "Proxsure_SPA",
                    ClientName = "Proxsure",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = false,

                    ClientSecrets = 
                    {
                        new Secret(customSecret.Sha256())
                    },

                    RedirectUris = { "http://localhost:4200/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Proxsure_API"
                    },
                    AllowOfflineAccess = true
                },

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "TestMvcClient",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = true,

                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Proxsure_API"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}