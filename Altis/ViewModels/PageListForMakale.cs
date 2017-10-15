using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
namespace Altis.ViewModels
{
    public class PageListForMakale
    {
        public string MakaleBaslik { get; set; }
        public string MakaleIcerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public System.DateTime SonGuncelleme { get; set; }
        public Nullable<System.DateTime> KaldirmaTarihi { get; set; }
        public int? Page { get; set; }
        public IPagedList<PageListModelForMakale> MakalelerPageList { get; set; }
    }
}