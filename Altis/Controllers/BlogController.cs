using Altis.Models;
using Altis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Text;

namespace Altis.Controllers
{
    public class BlogController : Controller
    {
        AltisEntities db = new AltisEntities();
     
        // GET: Blog
        public ActionResult Index()
        {
          List<AllBlog> all = new List<AllBlog>();


            var query = (from mak in db.MakalelerTB

                         select new AllBlog
                         {
                             Id = mak.MakeleID,
                             Baslik = mak.MakaleBaslik,
                             Onyazi = mak.MakaleOnyazi,
                             HTML = mak.HTML,
                             EklenmeTarihi = mak.EklenmeTarihi,
                             OneCikanGorsel = mak.OneCikanGorsel,
                             SonGuncelleme = mak.SonGuncelleme,
                             Kategori = "Makale"

                         }).ToList();

            all.AddRange(query);

            var query2 = (from hb in db.HaberlerTB
                          select new AllBlog
                          {
                              Id = hb.HaberID,
                              Baslik = hb.HaberBaslik,
                              Onyazi = hb.HaberOnyazi,
                              HTML = hb.HTML,
                              EklenmeTarihi = hb.EklenmeTarihi,
                              OneCikanGorsel = hb.OneCikanGorsel,
                              SonGuncelleme = hb.SonGuncelleme,
                              Kategori = "Haber"

                          }).ToList();


            all.AddRange(query2);

            var query3 = (from ft in db.Fotograf
                          select new AllBlog
                          {
                              Id = ft.FotoID,
                              Baslik = ft.FotoBaslik,
                              Onyazi = ft.FotoAciklama,
                              EklenmeTarihi =ft.EklenmeTarihi,
                              OneCikanGorsel = ft.FotoURLID,
                              SonGuncelleme =ft.SonGuncelleme,
                              Kategori = "Fotograf"

                          }).ToList();


            all.AddRange(query3);
            /*
            var query4 = (from sm in db.SeminerTB
                          select new AllBlog
                          {
                              Id = sm.SeminerID,
                              Baslik = sm.SeminerBaslik,
                              Onyazi = sm.SeminerAciklama,
                              EklenmeTarihi = sm.EklenmeTarih,
                              OneCikanGorsel = sm.OneCikanGorsel,
                              SonGuncelleme = sm.SonGuncelleme,
                              Kategori = "Seminer"

                          }).ToList();
            */

            all.AddRange(query3);


            var s = all.OrderByDescending(f => f.SonGuncelleme);
            return View(s);




            //    //Makale
            //    var query = (from mak in db.MakalelerTB

            //               select new AllBlog
            //               {
            //                   Id = mak.MakeleID,
            //                   Baslik = mak.MakaleBaslik,
            //                   Onyazi = mak.MakaleOnyazi,
            //                   HTML = mak.HTML,
            //                   EklenmeTarihi = mak.EklenmeTarihi,
            //                   OneCikanGorsel = mak.OneCikanGorsel,
            //                   SonGuncelleme = mak.SonGuncelleme


            //               }).ToList();

            //    all.AddRange(query);
            //    //Haber
            //    var query2 = (from hb in db.HaberlerTB

            //               select new AllBlog
            //               {
            //                   Id = hb.HaberID,
            //                   Baslik = hb.HaberBaslik,
            //                   Onyazi = hb.HaberOnyazi,
            //                   HTML = hb.HTML,
            //                   EklenmeTarihi = hb.EklenmeTarihi,
            //                   OneCikanGorsel = hb.OneCikanGorsel,
            //                   SonGuncelleme = hb.SonGuncelleme



            //               }).ToList();



            //    all.AddRange(query2);






            //return View(all.OrderByDescending(f=>f.SonGuncelleme));




        }
        public ActionResult Makaleler(PageListForMakale model)
        {
            //List<MakalelerTB> mak = db.MakalelerTB.ToList();
                
            int pageIndex = model.Page ?? 1;

            model.MakalelerPageList = (from mak in db.MakalelerTB.OrderByDescending(f => f.SonGuncelleme)

                                       select new PageListModelForMakale
                                       {
                                           MakeleID = mak.MakeleID,
                                           MakaleBaslik = mak.MakaleBaslik,
                                           MakaleOnyazi = mak.MakaleOnyazi,
                                           HTML=mak.HTML,
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
        //Haberler
        public ActionResult Haberler(PageListForHaber model)
        {

            //List<HaberlerTB> haberler = db.HaberlerTB.ToList();
            int pageIndex = model.Page ?? 1;

            model.haberlerPageList = (from haber in db.HaberlerTB.OrderByDescending(f => f.SonGuncelleme)

                                       select new PageListModelForHaber
                                       {
                                         HaberID=haber.HaberID,
                                         HaberBaslik=haber.HaberBaslik,
                                         HaberIcerik=haber.HaberOnyazi,
                                         Ad=haber.aspnet_Users.Ad,
                                         Soyad=haber.aspnet_Users.Soyad,
                                         OneCikanGorsel=haber.OneCikanGorsel,
                                         EklenmeTarihi=haber.EklenmeTarihi,
                                         SonGuncelleme=haber.SonGuncelleme,
                                         HaberAciklama =haber.HaberOnyazi
                                      
                                       

                                       }).ToPagedList(pageIndex, 2);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Haberler", model);

            }
            else
            {
                return View(model);
            }
            

        }
        public ActionResult Haber(int id )
        {
            HaberlerTB haber = db.HaberlerTB.FirstOrDefault(f => f.HaberID == id);
   


            return View(haber);
        }
        //Fotoğraflar
        public ActionResult Foto()
        {
            try
            {
                List<Fotograf> foto = db.Fotograf.ToList();
                return View(foto);
            }
            catch (Exception ex)
            {
                ViewBag.Mesaj = ex;
                return View();
            }
          





            
        }
        public PartialViewResult FotografKategori()
        {
            List<FotoKategori> fotokat = db.FotoKategori.ToList();

            return PartialView(fotokat);
        }
        //Video
        public ActionResult Video()
        {

            return View();
        }
        //Seminer
        public ActionResult Seminerler(PageListForSeminer model)
        {
            int pageIndex = model.Page ?? 1;

            model.SeminerPageList = (from sams in db.SeminerTB.OrderByDescending(f => f.SonGuncelleme)

                                     select new PageListModelForSeminer
                                     {
                                         SeminerID = sams.SeminerID,
                                         SeminerBaslik=sams.SeminerBaslik,
                                         SeminerAciklama=sams.SeminerAciklama,
                                         OneCikanGorsel=sams.OneCikanGorsel,
                                         HTML=sams.HTML,
                                         Telefon=sams.Telefon,
                                         Yer=sams.Yer,
                                         EklenmeTarih=sams.EklenmeTarih,
                                         SonGuncelleme=sams.SonGuncelleme,
                                         Zaman=sams.Zaman

                                       }).ToPagedList(pageIndex, 2);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Seminerler", model);

            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult Seminer(int id)
        {
            SeminerTB sem = db.SeminerTB.FirstOrDefault(f => f.SeminerID == id);
            return View(sem);
        }
        //Etkinlik
        public ActionResult Etkinlikler()
        {
            List<Models.Etkinlik> etk = db.Etkinlik.ToList();
            return View(etk);
        }
        public ActionResult Etkinlik()
        {
            return View();
        }
   

        public PartialViewResult Takvim()
        {
           
            return PartialView();

        }
        public ActionResult jsonEtkinlikDetay(string Date)
        {
            StringBuilder _builder = new StringBuilder("Etkinlik Tarihi : " + Date);
            _builder.Append("<ul>");
            _builder.Append("<li>Etkinlik 1</li>");
            _builder.Append("<li>Etkinlik 2</li>");
            _builder.Append("<li>Etkinlik 3</li>");

            _builder.Append("</ul>");
            return Content(_builder.ToString());
        }
        public ActionResult jsonEtkinlikler()
        {
            string[] arry = { "2017-11-01", "2017-11-02", "2017-11-03", "2017-11-24" };
            return Json(arry, JsonRequestBehavior.AllowGet);
        }


    }
}