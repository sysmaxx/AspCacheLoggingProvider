using LoggingProviderLibrary.Models;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingProviderLibrary.Services
{
    class CacheLogger : ILogger
    {

        private readonly string _categoryName;
        private readonly ICacheLoggerService _cacheLoggerService;

        public CacheLogger(string categoryName, ICacheLoggerService cacheLoggerService)
        {
            _categoryName = categoryName;
            _cacheLoggerService = cacheLoggerService;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = string.Empty;
            if (formatter is not null)
            {
                message += formatter(state, exception);
            }

            ErrorEntry error = null;
            if(exception is not null)
            {
                error = new ErrorEntry
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                };
            }

            var logEntry = new LogEntry
            {
                EventId = eventId,
                LogLevel = logLevel,
                Message = message,
                CategoryName = _categoryName,
                Error = error
            };

            _cacheLoggerService.Add(logEntry);
        }
    }

    public class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }

}
