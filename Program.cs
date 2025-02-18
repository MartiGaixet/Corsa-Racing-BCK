using Microsoft.AspNetCore.Cors.Infrastructure;
using CorsaRacing.Models;
using CorsaRacing.Repositories;
using CorsaRacing.Services;
using Microsoft.EntityFrameworkCore;

namespace CorsaRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CorsaRacing;Integrated Security=True;TrustServerCertificate=True"));

            // Registrar repositorios y servicios en el contenedor de dependencias
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
            builder.Services.AddScoped<IChampionshipService, ChampionshipService>();

            // Registrar RaceRepository y RaceService
            builder.Services.AddScoped<IRacesRepository, RaceRepository>();
            builder.Services.AddScoped<IRaceService, RaceService>();

            builder.Services.AddScoped<IParticipationRaceRepository, ParticipationRaceRepository>();
            builder.Services.AddScoped<IParticipationRaceService, ParticipationRaceService>();


            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                });

            // Agregar servicio CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Usar CORS
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
