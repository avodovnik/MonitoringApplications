using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.ApplicationInsights;
using System.Text;
using System.Reflection;

namespace AppInsights.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var tc = new TelemetryClient();
            tc.TrackEvent("ContactInitiated", new Dictionary<string, string>()
            {
                { "Name", "Test" },
                { "PricingPlan", "A" }
            });            

            return View();
        }

        public IActionResult GenerateEvents(int n = 100)
        {
            var tc = new TelemetryClient();

            for (int i = 0; i < n; i++)
            {
                tc.TrackEvent("ActionPerformed");
            }

            tc.Flush();

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public virtual ActionResult Status()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Request.QueryString.ToString());

            var version = typeof(HomeController).Assembly.GetName().Version;
            

            sb.AppendFormat("\r\nApplication version: {0}\r\n", version);
            return Content(sb.ToString());
        }
    }
}
