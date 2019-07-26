using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Stok
    {
        public int stokId { get; set; }
        public int grupId { get; set; }
        public int adId { get; set; }
        public int birimId { get; set; }
        public decimal fiyat { get; set; }
        public decimal miktar { get; set; }
    }
}