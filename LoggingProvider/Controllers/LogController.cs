using LoggingProviderLibrary.Models;
using LoggingProviderLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingProvider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ICacheLoggerService _cacheLoggerService;

        public LogController(ICacheLoggerService cacheLoggerService)
        {
            _cacheLoggerService = cacheLoggerService;
        }

        [HttpGet("allEntries")]
        public IEnumerable<LogEntry> Get() => _cacheLoggerService.GetAllEntries();



        [HttpPut("setloglevel/{loglevel:int}")]
        public string SetLoglevel(int loglevel)
        {
            _cacheLoggerService.LogLevel = (LogLevel)loglevel;
            return _cacheLoggerService.LogLevel.ToString();
        }
    }
}
