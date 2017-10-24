using Altis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altis.ViewModels
{
    public class AllBlog
    {
        /*
         *     public List<MakalelerTB> makaleler { get; set; }
        public List<HaberlerTB> haberler { get; set; }
     */
     //Makale
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Onyazi { get; set; }
        public string HTML { get; set; }
        public string OneCikanGorsel { get; set; }
        public string Kategori { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public System.DateTime SonGuncelleme { get; set; }

        //Haber


        //Foto



        //Video




        //Seminer



    }
}