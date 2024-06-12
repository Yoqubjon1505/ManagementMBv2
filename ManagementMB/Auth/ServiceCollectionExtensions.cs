using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ManagementMB.Auth
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyAuth(this IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy",
                    policy =>
                    {
                        policy.RequireRole("Admin");
                        policy.RequireRole("Owner");
                        policy.RequireRole("Worker");
                    });
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("User"));
            });
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // указывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,

                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    };
                });
        }
    }
}
