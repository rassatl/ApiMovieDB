using ApiMovieDB.Models.DataManager;
using ApiMovieDB.Models.EntityFramework;
using ApiMovieDB.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApiMovieDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FilmRatingDBContexts>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("FilmsDbContext")));
            builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}