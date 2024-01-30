using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
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
                services.AddScoped<IRepository<Book>, BookRepository>();
                
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