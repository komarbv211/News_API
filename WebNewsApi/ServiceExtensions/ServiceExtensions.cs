using Core.Models;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace WebNewsApi.ServiceExtensions
{
    public static class ServiceExtensions
    {
        // Налаштування JWT аутентифікації
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtOptions jwtOpts)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                    {
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOpts.Issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
                            ClockSkew = TimeSpan.Zero
                        };
                    });

            return services;
        }

        // Реєстрація налаштувань JwtOptions
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(_ =>
                configuration
                    .GetSection(nameof(JwtOptions))
                    .Get<JwtOptions>()!);

            return services;
        }
        public static void AddSwaggerJWT(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
            // Налаштування авторизаційних політик
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ServiceProviderOnly", policy => policy.RequireRole("ServiceProvider"));
                options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
            });

            return services;
        }
        public static void AddHangfire(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(connectionString);
            });
            services.AddHangfireServer();
        }
        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    //policy.WithOrigins("http://localhost:4200", "http://localhost:5173", "https://white-mushroom-080d17203.5.azurestaticapps.net")
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
    }
}
