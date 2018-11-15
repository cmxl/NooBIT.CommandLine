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
            args = new[] { "--foo", "bar", "/prop", "true" };

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
