﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class PageListForHaber
    {
       
        public int? Page { get; set; }
        public IPagedList<PageListModelForHaber> haberlerPageList { get; set; }
    }
}