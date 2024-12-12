using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;

namespace Coban.Identity.Extensions;

public static class ClaimsExtension
{
    public static void AddEmail(this ICollection<Claim> claims, string email) =>
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));

    public static void AddName(this ICollection<Claim> claims, string name) 
        => claims.Add(new Claim(ClaimTypes.Name, name));

    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier) =>
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));

    public static void AddRoles(this ICollection<Claim> claims, string[] roles) =>
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

    public static string? GetClaimValue(this HttpContext httpContext, string claimType)
        => httpContext?.User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;

    public static string? GetUserId(this HttpContext httpContext) 
        => httpContext.GetClaimValue(ClaimTypes.NameIdentifier);
  
    public static string? GetUserName(this HttpContext httpContext)
        => httpContext.GetClaimValue(ClaimTypes.Name);
}
