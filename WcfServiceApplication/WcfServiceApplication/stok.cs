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
    
    public partial class stok
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stok()
        {
            this.depo_stok = new HashSet<depo_stok>();
        }
    
        public int id { get; set; }
        public int stok_grup_id { get; set; }
        public int stok_ad_id { get; set; }
        public int stok_birim_id { get; set; }
        public decimal fiyat { get; set; }
        public decimal miktar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<depo_stok> depo_stok { get; set; }
        public virtual stok_grup stok_grup { get; set; }
        public virtual stok_ad stok_ad { get; set; }
        public virtual stok_birim stok_birim { get; set; }
    }
}
