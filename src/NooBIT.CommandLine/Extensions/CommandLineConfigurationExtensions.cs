using Microsoft.Extensions.Configuration;
using System;

namespace NooBIT.CommandLine.Extensions
{
    public static class CommandLineConfigurationExtensions
    {
        public static IConfigurationBuilder AddCommandLineArgs(this IConfigurationBuilder configurationBuilder, string[] args)
            => configurationBuilder.Add(new CommandLineArgsConfigurationSource { Args = args });

        public static IConfigurationBuilder AddCommandLineArgs(this IConfigurationBuilder builder, Action<CommandLineArgsConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
