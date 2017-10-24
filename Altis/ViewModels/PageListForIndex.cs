using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class PageListForIndex
    {

    
        public int? Page { get; set; }
        public IPagedList<AllBlog> MakalelerPageList { get; set; }
    }
}