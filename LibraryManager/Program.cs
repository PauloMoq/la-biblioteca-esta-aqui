using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

    public static void Main(IConfigurationBuilder configuration)
    {
        var host = CreateHostBuilder(configuration);
        // Exécution du host
        host.Run();
    }
}

