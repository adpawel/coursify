using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Coursify.Areas.Identity.Data;

namespace Coursify.Middleware
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<AppUser> userManager)
        {
            // Sprawdź tylko endpointy API
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                var username = context.Request.Headers["X-Username"].FirstOrDefault();
                var token = context.Request.Headers["X-Api-Key"].FirstOrDefault();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Missing username or API key.");
                    return;
                }

                var user = await userManager.FindByNameAsync(username);

                if (user == null || user.ApiToken != token)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Invalid token.");
                    return;
                }

                // Przypisz użytkownika do HttpContext
                var identity = new ClaimsIdentity("ApiKey");
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                var principal = new ClaimsPrincipal(identity);
                context.User = principal;
            }

            await _next(context);
        }
    }

}
