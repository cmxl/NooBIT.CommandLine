using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NooBIT.CommandLine.Sample
{
    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger<IHostedService> logger)
        {
            _logger = logger;
        }

        [Option]
        public string Foo { get; set; }

        public Task OnExecuteAsync()
        {
            _logger.LogInformation($"Foo: {Foo}");
            return Task.CompletedTask;
        }
    }
}