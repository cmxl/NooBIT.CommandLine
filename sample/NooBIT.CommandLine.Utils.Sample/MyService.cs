using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NooBIT.CommandLine.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NooBIT.CommandLine.Sample
{
    public class MyService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public MyService(
            ILogger<IHostedService> logger,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            var args = _configuration.GetCommandLineArgs().ToArray();
            var app = new CommandLineApplication<Application>();
            app.Conventions.UseDefaultConventions().UseConstructorInjection(_serviceProvider);
            var exitcode = app.Execute(args);
            return Task.FromResult(exitcode);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Stopping.");
            return Task.CompletedTask;
        }
    }
}