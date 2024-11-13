using Microsoft.Extensions.DependencyInjection;
using Core.AutoMapper;
using Core.Interfaces;
using Core.Services;
using Core.DTOs;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICommentService, CommentService >();
            services.AddScoped<INewsService, NewsService >();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountsService, AccountsService>();

            return services;
        }
    }
}