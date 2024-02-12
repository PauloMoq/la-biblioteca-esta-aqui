using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

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
        builder.Services.AddDbContext<LibraryContext>();

        // Ajoutez le support pour les contrôleurs (si vous utilisez MVC) ou les endpoints minimals
        builder.Services.AddControllers();

        // Autres configurations, telles que CORS, si nécessaire
        // builder.Services.AddCors(...);

        var app = builder.Build();

        // Middleware pour utiliser les contrôleurs MVC
        app.UseAuthorization();

        // Map les contrôleurs si vous utilisez MVC
        app.MapControllers();

        app.Run();
    }
}