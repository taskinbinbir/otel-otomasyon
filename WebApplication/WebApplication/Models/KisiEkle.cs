using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class KisiEkle
    {
        public string adSoyad { get; set; }
        public string tcNo { get; set; }

        public int kisiDurumId { get; set; }
        public int Id { get; set; }
        public DateTime cikisTarihi { get; set; }
        public int bireyHavuz { get; set; }

        public int cocukHavuz { get; set; }
    }
}