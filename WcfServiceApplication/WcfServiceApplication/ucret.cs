//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class ucret
    {
        public int id { get; set; }
        public int kisi_id { get; set; }
        public int mekan_id { get; set; }
        public int masa { get; set; }
        public string urunler { get; set; }
        public Nullable<decimal> ucret1 { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual kisi kisi { get; set; }
        public virtual mekan mekan { get; set; }
    }
}
