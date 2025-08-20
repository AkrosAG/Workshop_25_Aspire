using Duende.IdentityServer.Models;

namespace ThoemusBike.Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email(),
        new IdentityResource("role", ["role"]) 
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new ApiScope("thoemusbikeapi"),
    ];

    public static IEnumerable<Client> Clients =>
    [
        new Client
        {
            ClientId = "thoemusbike-swaggerui", // interactive.public,
            ClientName = "ThoemusBike public client (Code with PKCE)",

            RedirectUris = { "https://localhost:7213/swagger/oauth2-redirect.html" },
            PostLogoutRedirectUris = { "https://notused" },
            AllowedCorsOrigins = { "https://localhost:7213" },

            RequireClientSecret = false,

            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes = ["openid", "email", "profile", "thoemusbikeapi", "role"],

            AllowOfflineAccess = true,
            RefreshTokenUsage = TokenUsage.OneTimeOnly,
            RefreshTokenExpiration = TokenExpiration.Sliding
        },
        new Client
        {
            ClientId = "thoemusbike-webapp", //interactive.confidential
            ClientName = "ThoemusBike confidential client (Code with PKCE)",

            RedirectUris = { "https://localhost:7224/signin-oidc" },
            PostLogoutRedirectUris = { "https://notused" },

            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
            AllowedScopes = ["openid", "email", "profile", "thoemusbikeapi", "role"],

            AllowOfflineAccess = true,
            RefreshTokenUsage = TokenUsage.ReUse,
            RefreshTokenExpiration = TokenExpiration.Sliding
        },
    ];
}
