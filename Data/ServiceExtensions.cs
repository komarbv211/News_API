using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
namespace Data
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                return services;
        }

        // Налаштування Identity з ролями та базою даних
        public static IServiceCollection AddIdentityWithRoles(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        // Налаштування Entity Framework і контексту бази даних
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }

    }

}
