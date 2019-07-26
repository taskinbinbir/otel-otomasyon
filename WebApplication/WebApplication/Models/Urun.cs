using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Urun
    {
        public int id { get; set; }
        public decimal fiyat { get; set; }
        public decimal miktar { get; set; }
        public string sa { get; set; }
        public string sg { get; set; }
        public string sb { get; set; }
    }
}