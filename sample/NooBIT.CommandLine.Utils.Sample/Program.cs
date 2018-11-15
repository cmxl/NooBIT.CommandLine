using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NooBIT.CommandLine.Extensions;
using System.Threading.Tasks;

namespace NooBIT.CommandLine.Sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            args = new[] { "--foo", "bar" };

            await new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.AddCommandLineArgs(args);
                })
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddCommandLineArgs(args);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<Application>();
                    services.AddSingleton(PhysicalConsole.Singleton);
                    services.AddHostedService<MyService>();
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .RunConsoleAsync();
        }
    }
}
