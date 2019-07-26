using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using WcfServiceApplication.Model;

namespace WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        otelEntities OtelEntities = new otelEntities();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetKisilerBakiye()
        {
            var data = (from k in OtelEntities.kisi
                        join ka in OtelEntities.kart
                        on k.id equals ka.kisi_id
                        join b in OtelEntities.bakiye
                        on ka.id equals b.kart_id
                        select new
                        {
                            k.id,
                            k.tc_no

                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string GetKisiler()
        {
            var data = (from k in OtelEntities.kisi
                        join kd in OtelEntities.kisi_durum
                        on k.kisi_durum_id equals kd.id
                        select new
                        {
                            k.id,
                            k.tc_no,
                            k.ad_soyad,
                            kd.ad
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetKartBakiye(int id)
        {
            var data = (from k in OtelEntities.kart
                        join b in OtelEntities.bakiye
                        on k.id equals b.kart_id
                        where k.id == id
                        select new
                        {
                            b.kredi_kart_bakiye,
                            b.nakit_bakiye
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetKisiEkle(string _ad_soyad, string _tc_no, int _kisi_durum_id, int _id, DateTime _cikis_tarihi, int _birey_havuz, int _cocuk_havuz)
        {

            var sorgu = OtelEntities.kisi.Where(ki => ki.tc_no == _tc_no).FirstOrDefault<kisi>();


            if (sorgu == null)
            {
                kisi k = new kisi()
                {
                    ad_soyad = _ad_soyad,
                    tc_no = _tc_no,
                    kisi_durum_id = _kisi_durum_id
                };


                OtelEntities.kisi.Add(k);

                OtelEntities.SaveChanges();
            }

            kisi queryKisi = OtelEntities.kisi.Where(ki => ki.tc_no == _tc_no).FirstOrDefault<kisi>();


            //oda, kart, günü birlik
            if (_kisi_durum_id == 1)
            {
                DateTime cikis_tarihi_edit = new DateTime(_cikis_tarihi.Year, _cikis_tarihi.Month, _cikis_tarihi.Day,
                                        23, 59, 0, 0, DateTime.Now.Kind);


                var result = OtelEntities.oda.SingleOrDefault(o => o.id == _id);
                if (result != null)
                {
                    result.kisi_id = queryKisi.id;
                    result.giris_tarihi = DateTime.Now;
                    result.cikis_tarihi = cikis_tarihi_edit;

                    OtelEntities.SaveChanges();
                }


            }
            else if (_kisi_durum_id == 2)
            {
                DateTime cikis_tarihi = new DateTime(_cikis_tarihi.Year, _cikis_tarihi.Month, _cikis_tarihi.Day,
                                        23, 59, 0, 0, DateTime.Now.Kind);

                var result = OtelEntities.kart.SingleOrDefault(k => k.id == _id);
                if (result != null)
                {
                    result.kisi_id = queryKisi.id;
                    result.verilis_tarihi = DateTime.Now;
                    result.son_kullanma_tarihi = cikis_tarihi;
                    result.birey_havuz = _birey_havuz;
                    result.cocuk_havuz = _cocuk_havuz;

                    OtelEntities.SaveChanges();
                }

                kart queryKart = OtelEntities.kart.Where(ka => ka.kisi_id == queryKisi.id).FirstOrDefault<kart>();

                bakiye Bakiye = new bakiye()
                {
                    kart_id = queryKart.id,
                    kredi_kart_bakiye = 0,
                    nakit_bakiye = 0,
                    deposito = 30
                };

                OtelEntities.bakiye.Add(Bakiye);
                OtelEntities.SaveChanges();

            }
            else
            {

                DateTime cikis_tarihi = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                        20, 0, 0, 0, DateTime.Now.Kind);


                var result = OtelEntities.kart.SingleOrDefault(k => k.id == _id);
                if (result != null && result.kisi_id == null)
                {
                    result.kisi_id = queryKisi.id;
                    result.verilis_tarihi = DateTime.Now;
                    result.son_kullanma_tarihi = cikis_tarihi;
                    result.birey_havuz = _birey_havuz;
                    result.cocuk_havuz = _cocuk_havuz;

                    OtelEntities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("hata");
                }

                kart queryKart = OtelEntities.kart.Where(ka => ka.kisi_id == queryKisi.id).FirstOrDefault<kart>();

                bakiye Bakiye = new bakiye()
                {
                    kart_id = queryKart.id
                };

                OtelEntities.bakiye.Add(Bakiye);
                OtelEntities.SaveChanges();
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Kişi eklendi");
        }

        public string SetOda(int _id)
        {
            oda queryOda = OtelEntities.oda.Where(k => k.id == _id).FirstOrDefault<oda>();

            oda oda = new oda()
            {
                id = _id
            };
            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (queryOda == null)
            {
                OtelEntities.oda.Add(oda);
                OtelEntities.SaveChanges();

                return jss.Serialize(oda.id + " numaralı oda eklendi. ");
            }


            return jss.Serialize("Oda mevcut olduğu için eklenemedi.");
        }


        public string GetOda()
        {
            var data = (from o in OtelEntities.oda
                        where o.kisi_id == null
                        select new
                        {
                            o.id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetKart(int _id)
        {
            kart queryKart = OtelEntities.kart.Where(k => k.id == _id).FirstOrDefault<kart>();

            kart kart = new kart()
            {
                id = _id
            };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            if (queryKart == null)
            {

                OtelEntities.kart.Add(kart);
                OtelEntities.SaveChanges();

                return jss.Serialize(kart.id + " numaralı kart eklendi. ");
            }

            return jss.Serialize("Kart mevcut olduğu için eklenemedi.");
        }


        public string GetBosKart()
        {
            var data = (from k in OtelEntities.kart
                        where k.kisi_id == null
                        select new
                        {
                            k.id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string SetOdaMekan(int _id, int _mekanId, int _masaId, List<stok> urunMiktar)
        {
            decimal ucret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            var data = (from k in OtelEntities.kisi
                        join o in OtelEntities.oda
                        on k.id equals o.kisi_id
                        where o.id == _id
                        select new
                        {
                            k.id
                        }).ToList();


            StringBuilder urunler = new StringBuilder();
            foreach (stok u in urunMiktar)
            {
                ucret += u.fiyat * u.miktar;

                var query = (from s in OtelEntities.stok
                             join sa in OtelEntities.stok_ad
                             on s.stok_ad_id equals sa.id
                             where s.id == u.id
                             select new
                             {
                                 sa.ad
                             }).SingleOrDefault();

                urunler.Append(query.ad + " ");
            }

            ucret Ucret = new ucret()
            {
                kisi_id = data[0].id,
                mekan_id = _mekanId,
                masa = _masaId,
                urunler = urunler.ToString(),
                ucret1 = ucret,
                tarih = DateTime.Now
            };

            OtelEntities.ucret.Add(Ucret);
            OtelEntities.SaveChanges();


            var result = OtelEntities.oda.Where(o => o.id == _id).First();

            if (result != null)
            {
                result.ucret = result.ucret + ucret;

                OtelEntities.SaveChanges();
            }


            foreach (stok urun in urunMiktar)
            {
                var result2 = OtelEntities.stok.SingleOrDefault(k => k.id == urun.id);
                if (result2 != null)
                {
                    result2.id = urun.id;
                    result2.miktar = result2.miktar - urun.miktar;

                    OtelEntities.SaveChanges();
                }
            }


            return jss.Serialize("başarılı");
        }

        public string SetKartMekan(int _id, int _mekanId, int _masaId, List<stok> urunMiktar)
        {
            decimal ucret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            var data = (from ki in OtelEntities.kisi
                        join ka in OtelEntities.kart
                        on ki.id equals ka.kisi_id
                        where ka.id == _id
                        select new
                        {
                            ki.id
                        }).ToList();


            StringBuilder urunler = new StringBuilder();
            foreach (stok u in urunMiktar)
            {
                ucret += u.fiyat * u.miktar;

                //stok query = OtelEntities.stok.SingleOrDefault(k => k.id == u.id);

                var query = (from s in OtelEntities.stok
                             join sa in OtelEntities.stok_ad
                             on s.stok_ad_id equals sa.id
                             where s.id == u.id
                             select new
                             {
                                 sa.ad
                             }).SingleOrDefault();


                urunler.Append(query.ad + " ");
            }


            int dataKisiId = data[0].id;

            var data2 = (from k in OtelEntities.kart
                         join b in OtelEntities.bakiye
                         on k.id equals b.kart_id
                         where k.kisi_id == dataKisiId
                         select new
                         {
                             b.kredi_kart_bakiye,
                             b.nakit_bakiye,
                             b.kart_id
                         }).ToList();


            decimal toplamBakiye = Convert.ToDecimal(data2[0].kredi_kart_bakiye) + Convert.ToDecimal(data2[0].nakit_bakiye);
            int kartId = (int)data2[0].kart_id;

            decimal kb = 0, nb = 0;
            if (ucret > toplamBakiye)
            {
                return jss.Serialize("bakiye yetersiz");
            }
            else
            {
                kb = Convert.ToDecimal(data2[0].kredi_kart_bakiye) - ucret;

                if (kb < 0)
                {
                    nb = Convert.ToDecimal(data2[0].nakit_bakiye) + kb;
                    kb = 0;
                }
            }


            var result = OtelEntities.bakiye.SingleOrDefault(b => b.kart_id == kartId);
            if (result != null)
            {
                result.kredi_kart_bakiye = kb;
                result.nakit_bakiye = nb;

                OtelEntities.SaveChanges();
            }



            ucret Ucret = new ucret()
            {
                kisi_id = data[0].id,
                mekan_id = _mekanId,
                masa = _masaId,
                urunler = urunler.ToString(),
                ucret1 = ucret,
                tarih = DateTime.Now
            };

            OtelEntities.ucret.Add(Ucret);
            OtelEntities.SaveChanges();


            foreach (stok urun in urunMiktar)
            {
                var result2 = OtelEntities.stok.SingleOrDefault(k => k.id == urun.id);
                if (result2 != null)
                {
                    result2.id = urun.id;
                    result2.miktar = result2.miktar - urun.miktar;

                    OtelEntities.SaveChanges();
                }
            }


            return jss.Serialize("başarılı");
        }

        public string SetStokGrup(string _ad)
        {
            stok_grup stokGrup = new stok_grup()
            {
                ad = _ad
            };

            OtelEntities.stok_grup.Add(stokGrup);
            OtelEntities.SaveChanges();


            return "ok";
        }

        public string GetStokGroup()
        {
            var data = (from s in OtelEntities.stok_grup
                        select new
                        {
                            s.id,
                            s.ad
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetStokAd()
        {
            var data = (from s in OtelEntities.stok_ad
                        select new
                        {
                            s.id,
                            s.ad
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetStokAd(string _ad)
        {
            stok_ad stokAd = new stok_ad()
            {
                ad = _ad
            };

            OtelEntities.stok_ad.Add(stokAd);
            OtelEntities.SaveChanges();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("eklendi");
        }

        public string GetStok()
        {
            var data = (from s in OtelEntities.stok
                        join sa in OtelEntities.stok_ad
                        on s.stok_ad_id equals sa.id
                        select new
                        {
                            s.id,
                            sa.ad,
                            s.miktar,
                            s.fiyat
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetBirim(string _ad)
        {
            stok_birim birim = new stok_birim()
            {
                ad = _ad
            };

            OtelEntities.stok_birim.Add(birim);
            OtelEntities.SaveChanges();

            return "ok";
        }

        public string GetBirim()
        {
            var data = (from s in OtelEntities.stok_birim
                        select new
                        {
                            s.id,
                            s.ad
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string SetDepo(depo d)
        {
            depo queryDepo = OtelEntities.depo.Where(k => k.ad == d.ad).FirstOrDefault<depo>();

            depo depo = new depo()
            {
                ad = d.ad
            };
            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (queryDepo == null)
            {
                OtelEntities.depo.Add(depo);
                OtelEntities.SaveChanges();

                return jss.Serialize(depo.ad + " adında depo oda eklendi. ");
            }

            return jss.Serialize("Depo mevcut olduğu için eklenemedi.");
        }

        public string GetDepolar()
        {
            var data = (from d in OtelEntities.depo
                        select new
                        {
                            d.id,
                            d.ad
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetMekanDepo(int mekanId, int depoId)
        {
            mekan_depo MekanDepo = new mekan_depo()
            {
                mekan_id = mekanId,
                depo_id = depoId
            };

            OtelEntities.mekan_depo.Add(MekanDepo);
            OtelEntities.SaveChanges();

            return "ok";
        }

        public string GetMekanDepo()
        {
            var data = (from md in OtelEntities.mekan_depo
                        select new
                        {
                            md.id,
                            md.mekan_id,
                            md.depo_id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetPozisyon(string _ad)
        {
            pozisyon Pozisyon = new pozisyon()
            {
                ad = _ad
            };

            OtelEntities.pozisyon.Add(Pozisyon);
            OtelEntities.SaveChanges();

            return "ok";
        }

        public string GetPozisyon()
        {
            var data = (from p in OtelEntities.pozisyon
                        select new
                        {
                            p.id,
                            p.ad
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        //public string SetPersonel(Personel p)
        //{
        //    personel Personel = new personel()
        //    {
        //        tc_no = p.tcNo,
        //        ad_soyad = p.adSoyad,
        //        sifre = p.sifre,
        //        kart_id = p.kartId,
        //        pozisyon_id = p.pozisyonId
        //    };

        //    OtelEntities.personel.Add(Personel);
        //    OtelEntities.SaveChanges();

        //    return "ok";
        //}

        public string GetPersonel()
        {
            var data = (from p in OtelEntities.personel
                        select new
                        {
                            p.id,
                            p.ad_soyad,
                            p.sifre,
                            p.kart_id,
                            p.pozisyon_id
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetPersonelId(int personelID)
        {
            var data = (from p in OtelEntities.personel
                        where p.id == personelID
                        select new
                        {
                            p.id,
                            p.ad_soyad,
                            p.sifre,
                            p.kart_id,
                            p.pozisyon_id
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string GetDonanim()
        {
            var data = (from d in OtelEntities.donanim
                        select new
                        {
                            d.id,
                            d.ad
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetPersonelDepo(int personelId, int depoId)
        {
            personel_depo PersonelDepo = new personel_depo()
            {
                personel_id = personelId,
                depo_id = depoId
            };

            OtelEntities.personel_depo.Add(PersonelDepo);
            OtelEntities.SaveChanges();

            return "ok";
        }

        public string GetPersonelDepo()
        {
            var data = (from p in OtelEntities.personel_depo
                        select new
                        {
                            p.id,
                            p.personel_id,
                            p.depo_id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string GetPersonelDonanim()
        {
            var data = (from p in OtelEntities.personel_donanim
                        select new
                        {
                            p.id,
                            p.personel_id,
                            p.donanim_id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetPersonelIdDonanim(int personelId)
        {
            var data = (from p in OtelEntities.personel_donanim
                        where p.personel_id == personelId
                        select new
                        {
                            p.id,
                            p.personel_id,
                            p.donanim_id
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string MekanStok(int mekanId)
        {
            var data = (from md in OtelEntities.mekan_depo
                        join d in OtelEntities.depo
                        on md.depo_id equals d.id
                        join ds in OtelEntities.depo_stok
                        on d.id equals ds.depo_id
                        join s in OtelEntities.stok
                        on ds.stok_id equals s.id
                        where md.mekan_id == mekanId
                        select new
                        {
                            s.stok_grup_id,
                            s.stok_ad_id,
                            s.stok_birim_id,
                            s.miktar,
                            s.fiyat
                        }).ToList();

            List<MekanStok> ms = new List<MekanStok>();

            for (int i = 0; i < data.Count; i++)
            {
                int stokGrupId = data[i].stok_grup_id;
                int stokAdId = data[i].stok_ad_id;
                int stokBirimId = data[i].stok_birim_id;
                decimal miktar = data[i].miktar;
                decimal fiyat = data[i].fiyat;

                stok_grup grup = OtelEntities.stok_grup.Where(s => s.id == stokGrupId).FirstOrDefault<stok_grup>();
                stok_ad ad = OtelEntities.stok_ad.Where(s => s.id == stokAdId).FirstOrDefault<stok_ad>();
                stok_birim birim = OtelEntities.stok_birim.Where(s => s.id == stokBirimId).FirstOrDefault<stok_birim>();

                ms.Add(new MekanStok
                {
                    grup = grup.ad,
                    ad = ad.ad,
                    birim = birim.ad,
                    miktar = miktar,
                    fiyat = fiyat
                });

            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(ms);
        }

        public string SetStok(Stok s, int depoId)
        {
            stok Stok = new stok()
            {
                stok_grup_id = s.grupId,
                stok_ad_id = s.adId,
                stok_birim_id = s.birimId,
                fiyat = s.fiyat,
                miktar = s.miktar
            };

            OtelEntities.stok.Add(Stok);
            OtelEntities.SaveChanges();

            var max = OtelEntities.stok.DefaultIfEmpty().Max(r => r == null ? 0 : r.id);

            depo_stok depoStok = new depo_stok()
            {
                depo_id = depoId,
                stok_id = max
            };

            OtelEntities.depo_stok.Add(depoStok);
            OtelEntities.SaveChanges();


            return "ok";
        }

        public string GetKisiDurum()
        {
            var data = (from k in OtelEntities.kisi_durum
                        select new
                        {
                            k.id,
                            k.ad
                        });

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string GetDoluKart()
        {
            var data = (from k in OtelEntities.kart
                        where k.kisi_id != null
                        select new
                        {
                            k.id
                        }).OrderBy(x => x.id).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetDoluOda()
        {
            var data = (from o in OtelEntities.oda
                        where o.kisi_id != null
                        select new
                        {
                            o.id
                        }).OrderBy(x => x.id).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetBakiyeEkle(int _kartId, decimal _nakit_bakiye, decimal _kredi_kart_bakiye)
        {
            var result = OtelEntities.bakiye.SingleOrDefault(o => o.kart_id == _kartId);
            if (result != null)
            {
                result.nakit_bakiye = result.nakit_bakiye + _nakit_bakiye;
                result.kredi_kart_bakiye = result.kredi_kart_bakiye + _kredi_kart_bakiye;

                OtelEntities.SaveChanges();
            }

            return "ok";
        }

        public string SetMekan(string _ad)
        {
            mekan queryMekan = OtelEntities.mekan.Where(m => m.ad.Equals(_ad)).FirstOrDefault<mekan>();

            mekan mekan = new mekan()
            {
                ad = _ad
            };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            if (queryMekan == null)
            {

                OtelEntities.mekan.Add(mekan);
                OtelEntities.SaveChanges();

                return jss.Serialize(mekan.ad + " eklendi. ");
            }

            return jss.Serialize("Mekan mevcut olduğu için eklenemedi.");
        }


        public string GetMekanStok(int mekanId)
        {
            var data = (from md in OtelEntities.mekan_depo
                        join d in OtelEntities.depo
                        on md.depo_id equals d.id
                        join ds in OtelEntities.depo_stok
                        on d.id equals ds.depo_id
                        join s in OtelEntities.stok
                        on ds.stok_id equals s.id
                        where md.mekan_id == mekanId
                        select new
                        {
                            d.ad,
                            s.id,
                            s.stok_grup_id,
                            s.stok_ad_id,
                            s.stok_birim_id,
                            s.miktar,
                            s.fiyat
                        }).ToList();

            List<MekanDepoStok> ms = new List<MekanDepoStok>();

            for (int i = 0; i < data.Count; i++)
            {
                string depoAdi = data[i].ad;
                int stokId = data[i].id;
                int stokGrupId = data[i].stok_grup_id;
                int stokAdId = data[i].stok_ad_id;
                int stokBirimId = data[i].stok_birim_id;
                decimal miktar = data[i].miktar;
                decimal fiyat = data[i].fiyat;

                stok_grup grup = OtelEntities.stok_grup.Where(s => s.id == stokGrupId).FirstOrDefault<stok_grup>();
                stok_ad ad = OtelEntities.stok_ad.Where(s => s.id == stokAdId).FirstOrDefault<stok_ad>();
                stok_birim birim = OtelEntities.stok_birim.Where(s => s.id == stokBirimId).FirstOrDefault<stok_birim>();

                ms.Add(new MekanDepoStok
                {
                    depoAdi = depoAdi,
                    stokId = stokId,
                    grup = grup.ad,
                    ad = ad.ad,
                    birim = birim.ad,
                    miktar = miktar,
                    fiyat = fiyat
                });

            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(ms);
        }

        //public string SetStockEksilt(List<stok> urunler)
        //{

        //    foreach(stok u in urunler)
        //    {
        //        var result = OtelEntities.stok.SingleOrDefault(k => k.id == u.id);
        //        if (result != null)
        //        {
        //            result.id = u.id;
        //            result.miktar = result.miktar - u.miktar;

        //            OtelEntities.SaveChanges();
        //        }
        //    }

        //    return "ok";
        //}

        public string SetStockEksilt(stok urun)
        {
            var result = OtelEntities.stok.SingleOrDefault(k => k.id == urun.id);
            if (result != null)
            {
                result.id = urun.id;
                result.miktar = result.miktar - urun.miktar;

                OtelEntities.SaveChanges();
            }

            return "ok";
        }

        public string GetMekan()
        {
            var data = (from m in OtelEntities.mekan
                        select new
                        {
                            m.id,
                            m.ad
                        }).OrderBy(x => x.id).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


        public string SetDepoUrun(stok ss, depo d)
        {
            var data = (from ds in OtelEntities.depo_stok
                        join s in OtelEntities.stok
                        on ds.stok_id equals s.id
                        join sa in OtelEntities.stok_ad
                        on s.stok_ad_id equals sa.id
                        where sa.id == ss.stok_ad_id
                        select new
                        {
                            s.id
                        }).SingleOrDefault();

            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (data == null)
            {
                OtelEntities.stok.Add(ss);
                OtelEntities.SaveChanges();

                var max = OtelEntities.stok.DefaultIfEmpty().Max(r => r == null ? 0 : r.id);

                depo_stok depoStok = new depo_stok()
                {
                    depo_id = d.id,
                    stok_id = max
                };

                OtelEntities.SaveChanges();

                return jss.Serialize("yeni ürün eklendi.");
            }
            else
            {
                stok query = OtelEntities.stok.SingleOrDefault(k => k.id == data.id);

                if (query != null)
                {
                    query.miktar = query.miktar + ss.miktar;
                    query.fiyat = ss.fiyat;
                };

                OtelEntities.SaveChanges();

                return jss.Serialize("mevcut ürün güncellendi.");
            }


        }

        public string GetKartOdeme(kart kk, DateTime ilkTarih, DateTime sonTarih)
        {
            var data = (from k in OtelEntities.kisi
                        join ka in OtelEntities.kart
                        on k.id equals ka.kisi_id
                        join u in OtelEntities.ucret
                        on k.id equals u.kisi_id
                        where ka.id == kk.id && u.tarih > ilkTarih && u.tarih < sonTarih
                        select new
                        {
                            u.mekan_id,
                            u.masa,
                            u.urunler,
                            u.ucret1,
                            u.tarih
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetOdaOdeme(oda oo, DateTime ilkTarih, DateTime sonTarih)
        {
            var data = (from k in OtelEntities.kisi
                        join o in OtelEntities.oda
                        on k.id equals o.kisi_id
                        join u in OtelEntities.ucret
                        on k.id equals u.kisi_id
                        where o.kisi_id == oo.kisi_id && u.tarih > ilkTarih && u.tarih < sonTarih
                        select new
                        {
                            u.mekan_id,
                            u.masa,
                            u.urunler,
                            u.ucret1,
                            u.tarih
                        }).ToList();


            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetKisiBakiye(kart k)
        {
            var data = (from ki in OtelEntities.kisi
                        join ka in OtelEntities.kart
                        on ki.id equals ka.kisi_id
                        join b in OtelEntities.bakiye
                        on k.id equals b.kart_id
                        where ka.id == k.id
                        select new
                        {
                            b.nakit_bakiye,
                            b.kredi_kart_bakiye
                        }).ToList();


            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetKisiKartCikis(kart k)
        {
            var data = (from ki in OtelEntities.kisi
                        join ka in OtelEntities.kart
                        on ki.id equals ka.kisi_id
                        join ba in OtelEntities.bakiye
                        on k.id equals ba.kart_id
                        where ka.id == k.id
                        select new
                        {
                            kisi_id = ki.id,
                            bakiye_id = ba.id,
                            kart_id = k.id
                        }).FirstOrDefault();
            

            bakiye result3 = OtelEntities.bakiye.Where(bb => bb.kart_id == k.id).First();
         
            OtelEntities.bakiye.Remove(result3);
                    
            OtelEntities.SaveChanges();
            
            
            var result = OtelEntities.kart.Where(o => o.id == k.id).First();

            if (result != null)
            {
                result.kisi_id = null;
                result.verilis_tarihi = null;
                result.son_kullanma_tarihi = null;
                result.birey_havuz = 0;
                result.cocuk_havuz = 0;

                OtelEntities.SaveChanges();
            }



            var result2 = OtelEntities.kisi.Where(o => o.id == k.kisi_id).First();
            if (result2 != null)
            {
                result2.kisi_durum_id = 0;

                OtelEntities.SaveChanges();
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Çıkış yapıldı.");
        }

        public string SetKisiOdaCikis(oda oo)
        {
            var data = (from ki in OtelEntities.kisi
                        join o in OtelEntities.oda
                        on ki.id equals o.kisi_id
                        where o.id == oo.id
                        select new
                        {
                            kisi_id = ki.id,
                            oda_id = o.id
                        }).FirstOrDefault();

            var result = OtelEntities.oda.SingleOrDefault(o => o.id == data.oda_id);
            if (result != null)
            {
                result.kisi_id = null;
                result.giris_tarihi = null;
                result.cikis_tarihi = null;
                result.ucret = 0;

                OtelEntities.SaveChanges();
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Çıkış yapıldı.");
        }

        public string SetPersonel(personel p)
        {
            
            OtelEntities.personel.Add(p);
            OtelEntities.SaveChanges();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Personel eklendi.");
        }

        public string SetPersonelDepo(personel_depo p)
        {
            OtelEntities.personel_depo.Add(p);
            OtelEntities.SaveChanges();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("İlişkilendirildi");
        }

        public string SetPersonelDonanim(personel_donanim p)
        {
            OtelEntities.personel_donanim.Add(p);
            OtelEntities.SaveChanges();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("İlişkilendirildi");
        }


        public string SetDonanim(donanim d)
        {
            OtelEntities.donanim.Add(d);
            OtelEntities.SaveChanges();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Donanım eklendi.");
        }


        public string SetDepoYeniUrun(stok s, int depoId)
        {

            stok Stok = new stok()
            {
                stok_grup_id = s.stok_grup_id,
                stok_ad_id = s.stok_ad_id,
                stok_birim_id = s.stok_birim_id,
                fiyat = s.fiyat,
                miktar = s.miktar
            };


            OtelEntities.stok.Add(Stok);
            OtelEntities.SaveChanges();

            var max = OtelEntities.stok.DefaultIfEmpty().Max(r => r == null ? 0 : r.id);

            depo_stok depoStok = new depo_stok()
            {
                depo_id = depoId,
                stok_id = max
            };

            OtelEntities.depo_stok.Add(depoStok);
            OtelEntities.SaveChanges();


            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Donanım eklendi.");
        }

        public string GetDepoUrun(int depoId)
        {
            var data = (from d in OtelEntities.depo
                        join ds in OtelEntities.depo_stok
                        on d.id equals ds.depo_id
                        join s in OtelEntities.stok
                        on ds.stok_id equals s.id
                        join sa in OtelEntities.stok_ad
                        on s.stok_ad_id equals sa.id
                        join sg in OtelEntities.stok_grup
                        on s.stok_ad_id equals sg.id
                        join sb in OtelEntities.stok_birim
                        on s.stok_ad_id equals sb.id
                        where d.id == depoId
                        select new
                        {
                            s.id,
                            s.fiyat,
                            s.miktar,
                            sa = sa.ad,
                            sg = sg.ad,
                            sb = sb.ad
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string SetDepoUrunEkle(stok s)
        {

            var query = OtelEntities.stok.Where(st => st.id == s.id).FirstOrDefault<stok>();
            if (query != null)
            {
                query.miktar = query.miktar + s.miktar;

                OtelEntities.SaveChanges();
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize("Donanım eklendi.");
        }

        public string GetOdaUcret(int id)
        {
            var data = (from s in OtelEntities.oda
                        where s.id == id
                        select new
                        {
                            s.ucret
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public string GetTur()
        {
            var data = (from s in OtelEntities.tur
                        select new
                        {
                            s.id,
                            s.ad                          
                        }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }


    }
}
