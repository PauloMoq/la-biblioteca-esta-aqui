using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using LibraryManager.Hosting.Controllers;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuration des services
        builder.Services.AddScoped<ICatalogService, CatalogService>();
        builder.Services.AddScoped<ICatalogManager, CatalogManager>();
        builder.Services.AddScoped<IRepository<Library>, LibraryRepository>();
        builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
        builder.Services.AddScoped<IRepository<Book>, BookRepository>();
        builder.Services.AddDbContext<LibraryContext>(options =>{

            options.UseSqlite(
                "Data Source=" +
                 //  "C:\\Users\\moqp3\\Documents\\GitHub\\la-biblioteca-esta-aqui\\ressources\\library.db"
                 "C:\\Users\\natha\\Desktop\\Bureau\\BUT\\BUT_3\\.Net\\Projet avec Paul\\la-biblioteca-esta-aqui\\ressources\\library.db"
                );
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        var app = builder.Build();

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