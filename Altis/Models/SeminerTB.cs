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
    
    public partial class SeminerTB
    {
        public int SeminerID { get; set; }
        public string SeminerBaslik { get; set; }
        public string SeminerAciklama { get; set; }
        public string HTML { get; set; }
        public string OneCikanGorsel { get; set; }
        public System.DateTime EklenmeTarih { get; set; }
        public System.DateTime SonGuncelleme { get; set; }
        public string Telefon { get; set; }
        public string Yer { get; set; }
        public System.DateTime Zaman { get; set; }
        public System.Guid UserID { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
