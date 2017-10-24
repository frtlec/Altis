using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class PageListModelForHaber
    {
        public int HaberID { get; set; }
        public string HaberBaslik { get; set; }
        public string HaberIcerik { get; set; }
        public string HaberAciklama { get; set; }
        public string OneCikanGorsel { get; set; }

        public System.DateTime EklenmeTarihi { get; set; }
        public System.DateTime SonGuncelleme { get; set; }
        public System.Guid UserID { get; set; }
        public string HTML { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}