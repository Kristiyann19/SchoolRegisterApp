using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolRegisterApp.Repositories.Contracts;
using SchoolRegisterApp.Repositories.Services;
using System.Text;

namespace SchoolRegisterApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSchoolRegisterServices(this IServiceCollection services)
        {
            services
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IRegisterService, RegisterService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ISchoolService, SchoolService>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<ISettlementService, SettlementService>();

            return services;
        }

        public static IServiceCollection ConfigureJwtAuthenticationServices(this IServiceCollection services)
        {
            var keyBytes = Encoding.UTF8.GetBytes("VerySecretKeyThatNeedsToBeLongToWork");
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "http://localhost:12123",
                ValidateAudience = true,
                ValidAudience = "http://localhost:12123",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey
            };
            services
                .AddAuthentication(o => {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o => {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = tokenValidationParameters;
                    o.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = _ => Task.CompletedTask,
                        OnTokenValidated = _ => Task.CompletedTask
                    };
                });
            return services;
        }
    }
}
