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
    
    public partial class Etkinlik
    {
        public int EtkinlikID { get; set; }
        public string EtkinlikBaslik { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }
        public System.DateTime Zaman { get; set; }
        public string EtkinlikAciklama { get; set; }
        public System.Guid UserID { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}