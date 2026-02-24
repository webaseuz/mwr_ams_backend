using Microsoft.AspNetCore;

namespace AutoPark.Jobs;
public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hosting.json", optional: true)
            .AddCommandLine(args)
            .Build();

        return WebHost.CreateDefaultBuilder(args)
                      //.UseUrls("http://localhost:5001")
                      .UseConfiguration(config)
                      .UseStartup<Startup>()
                      .Build();
    }
}