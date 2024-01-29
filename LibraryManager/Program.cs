using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Configuration des services
            });
    }

    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        // Exécution du host
        host.Run();
    }
}

