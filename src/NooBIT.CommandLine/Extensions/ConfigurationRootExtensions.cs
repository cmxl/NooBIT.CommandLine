using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace NooBIT.CommandLine.Extensions
{
    public static class ConfigurationRootExtensions
    {
        public static IEnumerable<T> GetConfigurationProviders<T>(this IConfigurationRoot configurationRoot) where T : IConfigurationProvider
            => configurationRoot.Providers.Where(x => x.GetType() == typeof(T)).Cast<T>();
    }
}
