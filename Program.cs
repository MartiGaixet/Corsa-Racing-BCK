using Microsoft.AspNetCore.Cors.Infrastructure;
using CorsaRacing.Models;
using CorsaRacing.Repositories;
using CorsaRacing.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CorsaRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar base de datos
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CorsaRacing;Integrated Security=True;TrustServerCertificate=True"));

            // Registrar repositorios y servicios en el contenedor de dependencias
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
            builder.Services.AddScoped<IChampionshipService, ChampionshipService>();
            builder.Services.AddScoped<IRacesRepository, RaceRepository>();
            builder.Services.AddScoped<IRaceService, RaceService>();
            builder.Services.AddScoped<IParticipationRaceRepository, ParticipationRaceRepository>();
            builder.Services.AddScoped<IParticipationRaceService, ParticipationRaceService>();

            // Configurar controladores y JSON para evitar referencias circulares
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.WriteIndented = true; // Mejora legibilidad del JSON
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

            // Configurar el pipeline de la aplicación
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
