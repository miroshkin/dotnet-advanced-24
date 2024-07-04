using Duende.IdentityServer.Models;

namespace IdentityServer
    {
    public static class Config
        {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("catalogapi")
            {
                Scopes = new List<string> {"catalogapi.read", "catalogapi.write"},
                ApiSecrets = new List<Secret> {new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("catalogapi.read"),
                new ApiScope("catalogapi.write"),
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "manager",
                    ClientName = "Client Credentials Client",
                    Claims = new List<ClientClaim>() {
                        new ClientClaim("access", "create"),
                        new ClientClaim("access", "read"),
                        new ClientClaim("access", "update"),
                        new ClientClaim("access", "delete")
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "catalogapi.read", "catalogapi.write" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:12345/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:12345/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:12345/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "catalogapi.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },
            };
        }
    }