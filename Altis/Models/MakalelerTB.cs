//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Altis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MakalelerTB
    {
        public int MakeleID { get; set; }
        public System.Guid UserID { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleIcerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
        public System.DateTime SonGuncelleme { get; set; }
        public string HTML { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}