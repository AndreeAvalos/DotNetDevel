using System.Text;
using DotNetDevel.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DotNetDevel.Providers
{
    public static class JwtInjections
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, Root root)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = root.JwtSettings.Issuer,
                        ValidAudience = root.JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(root.JwtSettings.Key))
                    };
                });
            return services;
        }
    }
}
