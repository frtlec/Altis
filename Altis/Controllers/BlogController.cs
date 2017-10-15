using Altis.Models;
using Altis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace Altis.Controllers
{
    public class BlogController : Controller
    {
        AltisEntities db = new AltisEntities();

        // GET: Blog
        public ActionResult Index(PageListForMakale model)
        {
            //List<MakalelerTB> mak = db.MakalelerTB.ToList();

            int pageIndex = model.Page ?? 1;
            
            model.MakalelerPageList = (from mak in db.MakalelerTB.OrderByDescending(f => f.MakeleID)
                                       
                                       select new PageListModelForMakale
                                       {
                                           MakeleID = mak.MakeleID,
                                           MakaleBaslik = mak.MakaleBaslik,
                                           MakaleIcerik=mak.MakaleIcerik,
                                           EklenmeTarihi=mak.EklenmeTarihi,
                                           OneCikanGorsel=mak.OneCikanGorsel,
                                           Ad=mak.aspnet_Users.Ad,
                                           Soyad=mak.aspnet_Users.Soyad

                                       }).ToPagedList(pageIndex, 2);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Makaleler",model);

            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult Makaleler(PageListForMakale model)
        {
            //List<MakalelerTB> mak = db.MakalelerTB.ToList();

            int pageIndex = model.Page ?? 1;

            model.MakalelerPageList = (from mak in db.MakalelerTB.OrderByDescending(f => f.MakeleID)

                                       select new PageListModelForMakale
                                       {
                                           MakeleID = mak.MakeleID,
                                           MakaleBaslik = mak.MakaleBaslik,
                                           MakaleIcerik = mak.MakaleIcerik,
                                           EklenmeTarihi = mak.EklenmeTarihi,
                                           OneCikanGorsel = mak.OneCikanGorsel,
                                           Ad = mak.aspnet_Users.Ad,
                                           Soyad = mak.aspnet_Users.Soyad

                                       }).ToPagedList(pageIndex, 2);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Makaleler", model);

            }
            else
            {
                return View(model);
            }
        }
        /* Makale Devamını oku*/
       
        public ActionResult Makale(int id)
        {
            MakalelerTB mak = db.MakalelerTB.FirstOrDefault(f=>f.MakeleID==id);
           

            return View(mak);


        }
        public ActionResult Haberler()
        {
            return View();

        }
        }
}