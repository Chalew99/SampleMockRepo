using System;
using Microsoft.Extensions.Logging;

namespace CustomLogger
{


    public class ColorConsoleLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }
}
