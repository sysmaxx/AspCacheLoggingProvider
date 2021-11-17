using LoggingProviderLibrary.Models;
using System;
using System.Collections.Generic;

namespace LoggingProviderLibrary.Repositories
{
    public interface ILogRepository
    {
        IEnumerable<LogEntry> All();
        IEnumerable<LogEntry> FindAll(Func<LogEntry, bool> predicate);
        void Add(LogEntry entry);

    }
}
