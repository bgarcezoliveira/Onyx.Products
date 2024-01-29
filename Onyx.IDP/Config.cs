using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Onyx.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "Your role(s)", new[] { "role" }),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("onyxproductsapi.read")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("onyxproductsapi", "Onyx Products API",
                new[] { "role" })
            {
                Scopes =
                {
                    "onyxproductsapi.read"
                }
            }
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientName = "Onyx Products API Client",
                ClientId = "onyxproductsapi-client",
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                AccessTokenType = AccessTokenType.Jwt,
                UpdateAccessTokenClaimsOnRefresh = true,
                RedirectUris =
                {
                    "https://localhost:7078/signin-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    "onyxproductsapi.read"
                },
                ClientSecrets =
                {
                    new Secret("secret123".Sha256())
                },
                RequireConsent = true
            }
        };
}