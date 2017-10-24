using Altis.AppClass;
using Altis.Models;
using Altis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Altis.Controllers
{
    public class MailController : Controller
    {
        AltisEntities db = new AltisEntities();
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MailGonder()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MailGonder(string Email,string[] job)
        {
          

            var mesaj = "";
            if (Email == "" || job == null)
            {
                mesaj = "Lütfen alanları doldurunuz!";
                return Json(mesaj);
            }

            var body = new StringBuilder();
                body.AppendLine("Email: " + Email);
                var meslek = "";
                foreach (var item in job)
                {
                    meslek += item+",";

                }
                body.AppendLine("Meslek:" + meslek);

               

                Mail.MailSender(body.ToString());

                mesaj = "Mail adresiniz başarıyla kayıt edildi.";

            Mails mail = new Mails();
            mail.MailAdres = Email;
            mail.Meslek = meslek;
            db.Mails.Add(mail);
            db.SaveChanges();




            
            return Json(mesaj);

        }
       

    }
}