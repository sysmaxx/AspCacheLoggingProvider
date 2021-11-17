using LoggingProviderLibrary.Models;
using LoggingProviderLibrary.Repositories;
using LoggingProviderLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoggingProviderLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCacheLoggerService(
            this IServiceCollection services, 
            Action<CacheLoggerServiceConfiguration> options = null)
        {
            var _options = new CacheLoggerServiceConfiguration();

            if (options is not null)
                options.Invoke(_options);

            services.AddSingleton(_options);

            services.AddSingleton<ILogRepository, LogRepository>();
            services.AddSingleton<ICacheLoggerService, CacheLoggerService>();
        }

    }
}
