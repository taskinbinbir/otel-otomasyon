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
    
    public partial class personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personel()
        {
            this.personel_depo = new HashSet<personel_depo>();
            this.personel_donanim = new HashSet<personel_donanim>();
        }
    
        public int id { get; set; }
        public string tc_no { get; set; }
        public string ad_soyad { get; set; }
        public string sifre { get; set; }
        public int kart_id { get; set; }
        public int pozisyon_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personel_depo> personel_depo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personel_donanim> personel_donanim { get; set; }
        public virtual pozisyon pozisyon { get; set; }
    }
}
