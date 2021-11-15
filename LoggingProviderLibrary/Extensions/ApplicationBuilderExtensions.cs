using LoggingProviderLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingProviderLibrary.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCacheLoggerService(this ILoggerFactory loggerFactory, IServiceProvider provider)
        {
            loggerFactory.AddProvider(new CacheLoggerProvider(provider.GetRequiredService<ICacheLoggerService>()));
        }
    }
}
