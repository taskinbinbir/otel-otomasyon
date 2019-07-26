using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.ServiceReference1;

namespace WebApplication.Models
{
    public class Odeme
    {

        public Odeme()
        {
            urunMiktar = new List<stok>();
        }
        public int id { get; set; }
        public int mekanId { get; set; }
        public int masaId { get; set; }
        public List<stok> urunMiktar { get; set; }
    }
}