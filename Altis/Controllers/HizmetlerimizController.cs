using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Altis.Controllers
{
    public class HizmetlerimizController : Controller
    {
        AltisEntities db = new AltisEntities();
        // GET: Hizmetlerimiz
        public ActionResult Index()
        {
           List<Hizmetlerimiz> hz = db.Hizmetlerimiz.ToList();




            return View(hz);
        }
        public ActionResult Hizmet(int id)
        {
            Hizmetlerimiz hz = db.Hizmetlerimiz.FirstOrDefault(f => f.HizmetlerimizID == id);


            return View(hz);
        }
    }
}