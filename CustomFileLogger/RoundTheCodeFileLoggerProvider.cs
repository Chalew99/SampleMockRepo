using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFileLogger
{
    // RoundTheCodeFileLoggerProvider.cs
    [ProviderAlias("RoundTheCodeFile")]
    public class RoundTheCodeFileLoggerProvider : ILoggerProvider
    {
        public readonly RoundTheCodeFileLoggerOptions Options;

        public RoundTheCodeFileLoggerProvider(IOptions<RoundTheCodeFileLoggerOptions> _options)
        {
            Options = _options.Value;

            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new RoundTheCodeFileLogger(this);
        }

        public void Dispose()
        {
        }
    }
}
