using Data;
using Core;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Data.DataInitializer;
using Core.Models;
using Hangfire;
using WebNewsApi.ServiceExtensions;
using WebNewsApi.Middlewares;
using WebNewsApi;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCorsPolicies();

// Додаємо сервіси до контейнера
builder.Services.AddControllers();

// Налаштовуємо JwtOptions через окремий метод
builder.Services.AddJwtOptions(builder.Configuration);

// Отримуємо налаштування JWT
var jwtOpts = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

// Викликаємо розширення для JWT
builder.Services.AddJwtAuthentication(jwtOpts);

// Викликаємо метод для авторизаційних політик
builder.Services.AddAuthorizationPolicies();

// Налаштування Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerJWT();

builder.Services.AddHangfire(connectionString!);

// Налаштування Identity з використанням ролей
builder.Services.AddIdentityWithRoles();

// Додаємо Entity Framework і контекст бази даних
builder.Services.AddAppDbContext(connectionString!);

// Додаємо AutoMapper
builder.Services.AddMapping();

// Додаємо основні сервіси
builder.Services.AddCoreServices();

// Додаємо сервіси репозиторіїв
builder.Services.AddRepositories();

// fluent validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRoles().Wait();
    scope.ServiceProvider.SeedAdmin().Wait();

}
// Налаштування конвеєра HTTP запитів
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();

// Використовуйте CORS політику перед іншими middleware
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHangfireDashboard("/dash");
JobConfigurator.AddJobs();
app.MapControllers();
app.Run();
