using Serilog.Core;
using Serilog.Events;
using System;

namespace SimpleWebApp.Infrastructure
{
    public class TenantEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var rnd = new Random();
            int fakeTenantId = rnd.Next(1, 20);
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("RequestId", Guid.NewGuid().ToString("N")));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TenantId", fakeTenantId));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserId", "Annonymous Koala"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Version", "1.0")); // in real life, you would get this from the DLL
        }
    }
}
