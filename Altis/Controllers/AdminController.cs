using Altis.AppClass;
using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Altis.Controllers
{
    public class AdminController : Controller
    {
        AltisEntities db = new AltisEntities();

        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici k)
        {
            MembershipCreateStatus durum;
            Membership.CreateUser(k.KullaniciAdi, k.Parola, k.Email, k.GizliSoru, k.GizliCevap, true, out durum);
            string mesaj = "";
            switch (durum)
            {
                case MembershipCreateStatus.Success:

                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "Geçersiz kullanıcı adı hatası";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += "Geçesiz Parola";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "Geçersiz gizli soru";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "Geçersiz Gizli Cevap";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "Geçersiz Mail Adresi";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "Bu Kullanıcı adı zaten var!";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "Bu mail adresi zaten var !";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += "Kullanıcı engellenmiş!";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += "Geçersiz kullanıcı Key hatası";

                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += "Geçersiz kullanıcı Key hatası";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += "Üye Yönetimi sağlayıcısı hatası";
                    break;
                default:
                    break;
            }
            ViewBag.Mesaj = mesaj;
            aspnet_Users ek = (from p in db.aspnet_Users where p.UserName == k.KullaniciAdi select p).SingleOrDefault();
            ek.Ad = k.Ad;
            ek.Soyad = k.Soyad;


            db.SaveChanges();

            

           

            
            


            if (durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {


                return View();

            }

        }
    }
}