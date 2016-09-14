using Hangfire;
using Poc_HangFire.Models;
using System;
using System.Web.Mvc;

namespace Poc_HangFire.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public JsonResult Agendar()
        {
            var result = BackgroundJob.Schedule<IJob>(t => t.Execute("Valor"), TimeSpan.FromSeconds(10));

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}