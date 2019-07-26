using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceApplication.Model
{
    public class MekanStok
    {
        public string grup { get; set; }
        public string ad { get; set; }
        public string birim { get; set; }
        public decimal miktar { get; set; }
        public decimal fiyat { get; set; }
    }
}