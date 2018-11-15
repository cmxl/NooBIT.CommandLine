using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace NooBIT.CommandLine
{
    public class CommandLineArgsConfigurationProvider : ConfigurationProvider
    {
        public CommandLineArgsConfigurationProvider(IEnumerable<string> args)
        {
            Args = args;
        }

        public IEnumerable<string> Args { get; }
    }
}
