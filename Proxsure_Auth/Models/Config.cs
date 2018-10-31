using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Proxsure_Auth.Models {
    public class Config {
        public static List<TestUser> GetUsers () {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "1",
                        Username = "alice",
                        Password = "password"
                },
                new TestUser {
                    SubjectId = "2",
                        Username = "bob",
                        Password = "password"
                }
            };
        }
        public static IEnumerable<ApiResource> GetApiResources () {
            return new List<ApiResource> {
                new ApiResource ("Proxsure_API1", "Proxsure First API")
            };
        }

        public static IEnumerable<Client> GetClients () {
            return new List<Client> {
                new Client {
                    ClientId = "Proxsure_SPA",
                        ClientName = "Proxsure Angular SPA",

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.Implicit,

                        // secret for authentication
                        ClientSecrets = {
                            new Secret ("secret".Sha256 ())
                            },

                            RedirectUris = {
                            "http://localhost:4200/dashboard"
                            },

                            PostLogoutRedirectUris = {
                            "http://localhost:4200/"
                            },

                            AllowedCorsOrigins = {
                            "http://localhost:4200"
                            },

                            AllowAccessTokensViaBrowser = true,

                            // scopes that client has access to
                            AllowedScopes = { "openid", "profile", "Proxsure_API1" }
                            }
            };
        }
    }
}