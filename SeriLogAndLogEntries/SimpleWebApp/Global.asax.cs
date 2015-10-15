using SimpleWebApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // in real life, you would load these values from a configuration file, or the DB
            Log.Initialize(new SeriLogGateway("214eeb3b-8370-4cef-a336-551c617f3acc", 
                "Debug", 
                "{Timestamp:HH:mm:ss} [{Level}] (RequestId:{RequestId} | TenantId:{TenantId} | UserId:{UserId} | AppVersion:{Version}) {Message}{NewLine}{Exception}", 
                "1.0-demo"));
        }
    }
}
