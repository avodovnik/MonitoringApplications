using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SimpleWebApp.Infrastructure
{
    /// <summary>
    /// This class contains all functions related to logging.
    /// </summary>
    public static class Log
    {
        public static void Initialize(ILogGateway gateway)
        {
            As = gateway;
        }

        public static ILogGateway As { get; private set; }

        /// <summary>
        /// Creates a new exception with the given message logs it, and then 
        /// return it to the caller to be thrown.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        [DebuggerHidden]
        public static Exception ANewException(string message, params object[] parameters)
        {
            var e = new Exception(String.Format(message, parameters));

            As.Error(e);

            return e;
        }
    }
}