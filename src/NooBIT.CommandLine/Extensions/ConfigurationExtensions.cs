using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace NooBIT.CommandLine.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IEnumerable<T> GetConfigurationProviders<T>(this IConfiguration configuration) where T : IConfigurationProvider
            => configuration is IConfigurationRoot root
                ? root.GetConfigurationProviders<T>()
                : Enumerable.Empty<T>();

        public static IEnumerable<string> GetCommandLineArgs(this IConfiguration configuration) 
            => configuration.GetConfigurationProviders<CommandLineArgsConfigurationProvider>().SingleOrDefault()?.Args ?? Enumerable.Empty<string>();
    }
}
