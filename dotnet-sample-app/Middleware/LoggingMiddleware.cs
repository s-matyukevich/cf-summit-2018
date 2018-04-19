using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;  
using Serilog;  
using Serilog.Events;  
using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;

namespace dotnet_sample_app.Middleware
{

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            var logger = this._loggerFactory.CreateLogger<LoggingMiddleware>();
            using (logger.BeginScope(new Dictionary<string, object>{["CustomerId"] = 12345}))
            {
                logger.LogInformation("Before request");
                await this._next.Invoke(context);
                logger.LogInformation("After request");
            }
        }
    }
}
