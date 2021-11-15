using LoggingProviderLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LoggingProviderLibrary.Services
{
    public interface ICacheLoggerService
    {
        LogLevel LogLevel { get; set; }
        void Add(LogEntry logEntry);
        IEnumerable<LogEntry> GetAllEntries();
        IEnumerable<LogEntry> GetFilteredEntries(Func<LogEntry, bool> predicate);
    }
}
