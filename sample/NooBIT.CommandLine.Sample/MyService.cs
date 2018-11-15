using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NooBIT.CommandLine.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.CommandLine.Sample
{
    public class MyService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public MyService(
            ILogger<IHostedService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            var args = _configuration.GetCommandLineArgs();
            _logger.LogInformation($"Starting with arguments: [{string.Join(' ', args)}]");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Stopping.");
            return Task.CompletedTask;
        }
    }
}