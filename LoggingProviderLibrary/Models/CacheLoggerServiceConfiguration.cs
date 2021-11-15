using Microsoft.Extensions.Logging;

namespace LoggingProviderLibrary.Models
{
    public class CacheLoggerServiceConfiguration
    {
        public uint LogSize { get; set; } = 1000;
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
    }
}
