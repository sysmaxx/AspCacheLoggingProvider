using Microsoft.Extensions.Logging;
using System;

namespace LoggingProviderLibrary.Services
{
    public class CacheLoggerProvider : ILoggerProvider
    {

        private readonly ICacheLoggerService _cacheLoggerService;

        public CacheLoggerProvider(ICacheLoggerService cacheLoggerService)
        {
            _cacheLoggerService = cacheLoggerService ?? throw new ArgumentNullException(nameof(cacheLoggerService));
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CacheLogger(categoryName, _cacheLoggerService); 

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
