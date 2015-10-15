using System;
using System.Runtime.CompilerServices;

namespace SimpleWebApp.Infrastructure
{
    /// <summary>
    /// Abstracts the required functionality of a logging gateway.
    /// </summary>
    public interface ILogGateway
    {
        /// <summary>
        /// Called to log information, non-critical to the running of the application.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        void Info(string template, params object[] objects);

        /// <summary>
        /// Called to log warnings, special conditions that seriously affect the application.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        void Warning(string template, params object[] objects);

        /// <summary>
        /// Called when a critical error happens (e.g. exception that isn't handled).
        /// </summary>
        /// <param name="template"></param>
        /// <param name="objects"></param>
        void Error(string template, params object[] objects);

        /// <summary>
        /// Logs an exception with a predefined message.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="methodName"></param>
        Exception Error(Exception e, [CallerMemberName]string methodName = "Unknown");
    }
}
