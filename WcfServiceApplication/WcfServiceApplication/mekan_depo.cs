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
    
    public partial class mekan_depo
    {
        public int id { get; set; }
        public int mekan_id { get; set; }
        public int depo_id { get; set; }
    
        public virtual depo depo { get; set; }
        public virtual mekan mekan { get; set; }
    }
}
