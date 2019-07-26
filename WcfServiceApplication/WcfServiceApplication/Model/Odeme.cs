using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceApplication.Model
{
    public class Odeme
    {
        public Odeme()
        {
            urunMiktar = new List<stok>();
        }

        public int kartId { get; set; }
        public int mekanId { get; set; }
        public int masaId { get; set; }
        public decimal ucret { get; set; }

        List<stok> urunMiktar { get; set; }
    }
}