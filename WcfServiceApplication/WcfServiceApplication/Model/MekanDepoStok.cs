using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceApplication.Model
{
    public class MekanDepoStok
    {
        public string depoAdi { get; set; }
        public int stokId { get; set; }
        public string grup { get; set; }
        public string ad { get; set; }
        public string birim { get; set; }
        public decimal miktar { get; set; }
        public decimal fiyat { get; set; }
    }
}