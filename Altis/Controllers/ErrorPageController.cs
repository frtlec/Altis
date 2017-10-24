using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Altis.Controllers
{
    [OutputCache(Duration = 360)]
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ErrorMessage()
        {
            ViewBag.ErrorMessage ="BİR SORUNLA KARŞILAŞILDI";

            return View();
        }
    }
}