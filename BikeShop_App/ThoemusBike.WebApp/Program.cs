using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ThoemusBike.WebApp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var authority = builder.Configuration.GetValue<string>("Auth:Authority");
// doesn't really work since it's under :0 and a new Uri won't easily resolve it.
//var discAuthority = builder.Configuration.GetValue<string>("services:thoemusbike-identity:https");

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies", options => options.AccessDeniedPath = "/AccessDenied")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = authority;
    options.ClientId = "thoemusbike-webapp";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.Scope.Add("role");
    options.Scope.Add("thoemusbikeapi");
    options.Scope.Add("offline_access");
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClaimActions.MapJsonKey("role", "role", "role");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "email",
        RoleClaimType = "role"
    };
    options.SaveTokens = true;
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddScoped<IEmailSender, EmailService>();

var app = builder.Build();

app.MapDefaultEndpoints();
        
app.UseExceptionHandler("/Error");

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
