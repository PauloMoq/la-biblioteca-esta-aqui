using Microsoft.Extensions.Configuration;
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
            })
            .Build();
    }

    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder();
        var host = CreateHostBuilder(configuration);
        var service = new CatalogService();
        service.ShowCatalog();
        // Exécution du host
        host.Run();

    }
}