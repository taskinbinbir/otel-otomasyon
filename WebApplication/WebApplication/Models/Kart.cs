using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Kart
    {
        public int id { get; set; }

        public int kisi_id { get; set; }

        public DateTime verilis_tarihi { get; set; }

        public DateTime son_kullanma_tarihi { get; set; }

        public int birey_havuz { get; set; }

        public int cocuk_havuz { get; set; }
    }
}