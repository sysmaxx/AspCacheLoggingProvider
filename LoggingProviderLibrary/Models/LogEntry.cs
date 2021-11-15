using Microsoft.Extensions.Logging;
using System;

namespace LoggingProviderLibrary.Models
{
   public class LogEntry
    {
        public uint Id { get; set; }
        public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;
        public LogLevel LogLevel { get; set; }
        public EventId EventId { get; set; }
        public string Message { get; set; }
        public ErrorEntry Error { get; set; }
        public string CategoryName { get; set; }
    }
}
