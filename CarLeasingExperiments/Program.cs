using Microsoft.AspNetCore;

namespace CarLeasingExperiments
{
    public class Program
    {
        private static readonly string
            CurrentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(GetConfiguration())
                .UseStartup<Startup>();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{CurrentEnvironment}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            return config;
        }
    }
}