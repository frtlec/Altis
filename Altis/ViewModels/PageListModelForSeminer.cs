using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class PageListModelForSeminer
    {
        public int SeminerID { get; set; }
        public string SeminerBaslik { get; set; }
        public string SeminerAciklama { get; set; }
        public string Yer { get; set; }
        public System.DateTime Zaman { get; set; }
        public System.Guid UserID { get; set; }
        public string HTML { get; set; }
        public string OneCikanGorsel { get; set; }
        public string Telefon { get; set; }
        public System.DateTime EklenmeTarih { get; set; }
        public System.DateTime SonGuncelleme { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}