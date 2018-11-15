using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace NooBIT.CommandLine
{
    public class CommandLineArgsConfigurationSource : IConfigurationSource
    {
        public IEnumerable<string> Args { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new CommandLineArgsConfigurationProvider(Args);
    }
}
