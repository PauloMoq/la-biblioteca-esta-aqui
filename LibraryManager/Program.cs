using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;

public class Program
{

    private static IHost CreateHostBuilder(IConfigurationBuilder configuration)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Configuration des services
                services.AddScoped<ICatalogService, CatalogService>();
                services.AddScoped<ICatalogManager, CatalogManager>();

                services.AddScoped<IRepository<Library>, LibraryRepository>();
                services.AddScoped<IRepository<Author>, AuthorRepository>();
                services.AddScoped<IRepository<Book>, BookRepository>();

                services.AddDbContext<LibraryContext>();
                
            })
            .Build();
    }

    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder();
        var host = CreateHostBuilder(configuration);
        var service = host.Services.GetRequiredService<ICatalogService>();
        // Exécution du host
        host.Run();

    }
}