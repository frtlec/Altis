using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class PageListForSeminer
    {
        
        public string SeminerBaslik { get; set; }
        public string HTML { get; set; }
        public string OneCikanGorsel { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public System.DateTime SonGuncelleme { get; set; }
        public Nullable<System.DateTime> KaldirmaTarihi { get; set; }
        public int? Page { get; set; }
        public IPagedList<PageListModelForSeminer> SeminerPageList { get; set; }
    }
}