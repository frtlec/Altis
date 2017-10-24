using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Altis.Controllers
{
    public class HomeController : Controller
    {
        AltisEntities db = new AltisEntities();
        public ActionResult Index()
        {
            List<Hizmetlerimiz> hz = db.Hizmetlerimiz.ToList();
            ViewBag.SideBar = "0";
            return View(hz);
        }
        /*
        public ActionResult Creazpa()
        {
            string fullPath = Request.MapPath(@"/App_Data");
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return View();
        }*/
       
     

 
    }
}