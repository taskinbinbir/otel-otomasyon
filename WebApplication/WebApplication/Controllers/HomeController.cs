using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication.Models;
using WebApplication.ServiceReference1;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult kisiEkle()
        {

            return View();
        }


        [HttpGet]
        public ActionResult Kisiler()
        {
            List<Kisi> kisiler;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kisiler = jss.Deserialize<List<Kisi>>(svc.GetKisiler());
            }

            return Json(new { data = kisiler }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KisiDurum()
        {
            List<KisiDurum> kisiDurum;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kisiDurum = jss.Deserialize<List<KisiDurum>>(svc.GetKisiDurum());
            }

            return Json(new { data = kisiDurum }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BosKart()
        {
            List<Kart> kisiDurum;
            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kisiDurum = jss.Deserialize<List<Kart>>(svc.GetBosKart());
            }

            return Json(new { data = kisiDurum }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BosOda()
        {
            List<Oda> kisiDurum;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kisiDurum = jss.Deserialize<List<Oda>>(svc.GetOda());
            }

            return Json(new { data = kisiDurum }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult KisiEkle(KisiEkle k)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetKisiEkle(k.adSoyad, k.tcNo, k.kisiDurumId, k.Id, k.cikisTarihi, k.bireyHavuz, k.cocukHavuz);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DoluKartlar()
        {
            List<Kart> kartId;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kartId = jss.Deserialize<List<Kart>>(svc.GetDoluKart());
            }

            return Json(new { data = kartId }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DoluOdalar()
        {
            List<oda> kartId;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                kartId = jss.Deserialize<List<oda>>(svc.GetDoluOda());
            }

            return Json(new { data = kartId }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetKartBakiyeEkle(Bakiye b)
        {
            using (var svc = new Service1Client())
            {
                svc.SetBakiyeEkle(b.kartId, b.nakitBakiye, b.krediKartBakiye);
            }

            return Json(new { data = "eklendi" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KartBakiyeEkle(Bakiye b)
        {
            return View();
        }

        public ActionResult SetKart(Kart kart)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetKart(kart.id);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetOda(Oda oda)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetOda(oda.id);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetMekan(Mekan mekan)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetMekan(mekan.ad);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDepo(depo depo)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetDepo(depo);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMekan()
        {
            List<mekan> mekan;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                mekan = jss.Deserialize<List<mekan>>(svc.GetMekan());
            }

            return Json(new { data = mekan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMekanStok(mekan m)
        {
            List<MekanStokDepo> mekan;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                mekan = jss.Deserialize<List<MekanStokDepo>>(svc.GetMekanStok(m.id));
            }

            return Json(new { data = mekan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetKartMekan(Odeme o)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetKartMekan(o.id, o.mekanId, o.masaId, o.urunMiktar.ToArray<stok>());
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetOdaMekan(Odeme o)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetOdaMekan(o.id, o.mekanId, o.masaId, o.urunMiktar.ToArray<stok>());
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetStokAd(stok_ad stockAd)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetStokAd(stockAd.ad);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetStokGroup(stok_grup stockGrup)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetStokGrup(stockGrup.ad);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetBirim(stok_birim stockBirim)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetBirim(stockBirim.ad);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDepoUrun(stok s, depo d)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetDepoUrun(s, d);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepoUrun(int depoId)
        {
            List<Urun> urunler;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                urunler = jss.Deserialize<List<Urun>>(svc.GetDepoUrun(depoId));
            }

            return Json(new { data = urunler }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepolar()
        {
            List<depo> depolar;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                depolar = jss.Deserialize<List<depo>>(svc.GetDepolar());
            }

            return Json(new { data = depolar }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStokGroup()
        {
            List<stok_grup> stokGrup;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                stokGrup = jss.Deserialize<List<stok_grup>>(svc.GetStokGroup());
            }

            return Json(new { data = stokGrup }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStokAd()
        {
            List<stok_ad> stokAd;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                stokAd = jss.Deserialize<List<stok_ad>>(svc.GetStokAd());
            }

            return Json(new { data = stokAd }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBirim()
        {
            List<stok_birim> stokBirim;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                stokBirim = jss.Deserialize<List<stok_birim>>(svc.GetBirim());
            }

            return Json(new { data = stokBirim }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDepoYeniUrun(stok s, int depoId)
        {

            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetDepoYeniUrun(s, depoId);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDepoUrunEkle(stok s)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetDepoUrunEkle(s);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetKartBakiye(kart k)
        {
            List<bakiye> b;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                b = jss.Deserialize<List<bakiye>>(svc.GetKartBakiye(k.id));
            }
            return Json(new { data = b }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetKisiKartCikis(kart k)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetKisiKartCikis(k);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetKisiOdaCikis(oda o)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetKisiOdaCikis(o);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOdaUcret(int id)
        {
            List<oda> query;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                query = jss.Deserialize<List<oda>>(svc.GetOdaUcret(id));
            }
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPozisyon()
        {
            List<pozisyon> query;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                query = jss.Deserialize<List<pozisyon>>(svc.GetPozisyon());
            }
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTur()
        {
            List<tur> query;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                query = jss.Deserialize<List<tur>>(svc.GetTur());
            }
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPersonel()
        {
            List<personel> query;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                query = jss.Deserialize<List<personel>>(svc.GetPersonel());
            }
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDonanim()
        {
            List<donanim> query;

            using (var svc = new Service1Client())
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                query = jss.Deserialize<List<donanim>>(svc.GetDonanim());
            }
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SetPersonel(personel p)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetPersonel(p);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetDonanim(donanim d)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetDonanim(d);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetPersonelDonanim(personel_donanim d)
        {
            string query;

            using (var svc = new Service1Client())
            {
                query = svc.SetPersonelDonanim(d);
            }

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KartEkle()
        {
            return View();
        }

        public ActionResult OdaEkle()
        {
            return View();
        }

        public ActionResult MekanEkle()
        {
            return View();
        }

        public ActionResult DepoEkle()
        {
            return View();
        }

        public ActionResult MekanOdeme()
        {
            return View();
        }

        public ActionResult MekanStok()
        {
            return View();
        }

        public ActionResult StokOzellikleriEkle()
        {
            return View();
        }

        public ActionResult DepoUrunler()
        {
            return View();
        }

        public ActionResult DepoUrunEkle()
        {
            return View();
        }
        public ActionResult KartliCikis()
        {
            return View();
        }

        public ActionResult OdaliCikis()
        {
            return View();
        }

        public ActionResult PersonelEkle()
        {
            return View();
        }

        public ActionResult DonanimEkle()
        {
            return View();
        }

        public ActionResult PersonelDonanim()
        {
            return View();
        }


    }
}