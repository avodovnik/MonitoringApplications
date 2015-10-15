using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace SimpleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            var someData = new
            {
                Left = 100,
                Right = 500,
                Top = 504,
                Bottom = 143
            };


            Infrastructure.Log.As.Info("Our first log entry {@SomeData}.", someData);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}