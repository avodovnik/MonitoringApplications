using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Runtime.CompilerServices;

namespace SimpleWebApp.Infrastructure
{
    /// <summary>
    /// Implements Logging Gateway using SeriLog
    /// </summary>
    public struct SeriLogGateway : ILogGateway
    {
        private readonly ILogger _logger;

        public SeriLogGateway(string apiToken, string logLevel, string outputTemplate, string appVersion)
        {
            var loggingLevel = ResolveLogLevel(logLevel);

            _logger = new LoggerConfiguration()
                           .Enrich.With<TenantEnricher>()
                           .Enrich.WithProperty("Version", appVersion)
                           .WriteTo.Logentries(apiToken, true, 50, null, loggingLevel, outputTemplate)
                           .CreateLogger();
        }

        /// <summary>
        /// Resolves SeriLog LogEvent from string
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        private static LogEventLevel ResolveLogLevel(string logLevel)
        {
            var loggingLevel = LogEventLevel.Debug;
            switch (logLevel.ToUpper())
            {
                case "WARN":
                    loggingLevel = LogEventLevel.Warning;
                    break;
                case "ERROR":
                    loggingLevel = LogEventLevel.Error;
                    break;
                case "INFO":
                    loggingLevel = LogEventLevel.Information;
                    break;
            }
            return loggingLevel;
        }

        /// <summary>
        /// Called to log information, non-critical to the running of the application.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        public void Info(string template, params object[] objects)
        {
            _logger.Information(template, objects);
        }

        /// <summary>
        /// Called to log warnings, special conditions that seriously affect the application.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        public void Warning(string template, params object[] objects)
        {
            _logger.Warning(template, objects);
        }

        /// <summary>
        /// Called when a critical error happens (e.g. exception that isn't handled).
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        public void Error(string template, params object[] objects)
        {
            _logger.Error(template, objects);
        }

        public Exception Error(Exception e, [CallerMemberName]string methodName = "unknown")
        {
            //if (e is DbEntityValidationException)
            //{
            //    // I was really supper annoyed with the EntityException throwing
            //    // validation errors and not being able to catch them [Anže]
            //    foreach (var error in (e as DbEntityValidationException).EntityValidationErrors)
            //    {
            //        foreach (var msg in error.ValidationErrors)
            //        {
            //            this.Error(String.Format("{0}: {1}", msg.PropertyName, msg.ErrorMessage));
            //        }
            //    }
            //}
            this.Error("An exception occured at {0}: {1}", methodName, e);
            return e;
        }
    }

}