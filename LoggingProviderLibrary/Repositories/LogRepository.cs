using LoggingProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggingProviderLibrary.Repositories
{
    internal class LogRepository : ILogRepository
    {
        private readonly IList<LogEntry> _logEntryCache;
        private readonly uint _logSize;
        private uint _entryCount = 0;
        private uint _currentId = 0;

        public LogRepository(CacheLoggerServiceConfiguration options)
        {
            _logEntryCache = new List<LogEntry>();
            _logSize = options.LogSize;
        }

        public void Add(LogEntry entry)
        {
            entry.Id = ++_currentId;

            _logEntryCache.Add(entry);
            _entryCount++;

            if (_entryCount > _logSize)
            {
                _logEntryCache.RemoveAt(0);
                _entryCount = _logSize;
            }
        }

        public IEnumerable<LogEntry> All() => _logEntryCache;
        public IEnumerable<LogEntry> FindAll(Func<LogEntry, bool> predicate) => _logEntryCache.Where(predicate);
    }
}
