using LoggingProviderLibrary.Models;
using LoggingProviderLibrary.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LoggingProviderLibrary.Services
{
    public class CacheLoggerService : ICacheLoggerService
    {
        public LogLevel LogLevel { get; set; } 

        private readonly ILogRepository _logRepository;


        public CacheLoggerService(ILogRepository logRepository, CacheLoggerServiceConfiguration options)
        {
            _logRepository = logRepository;
            LogLevel = options.LogLevel;
        }

        public void Add(LogEntry logEntry)
        {
            if (logEntry.LogLevel >= LogLevel)
                _logRepository.Add(logEntry);
        }
        public IEnumerable<LogEntry> GetAllEntries() => _logRepository.All();
        public IEnumerable<LogEntry> GetFilteredEntries(Func<LogEntry, bool> predicate) => _logRepository.FindAll(predicate);

    }
}
