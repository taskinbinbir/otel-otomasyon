using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceApplication.Model;

namespace WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string GetKisiler();
        
        [OperationContract]
        string SetKisiEkle(string _ad_soyad, string _tc_no, int _kisi_durum_id, int id, DateTime _cikis_tarihi, int _birey_havuz, int _cocuk_havuz);
                 
        [OperationContract]
        string SetOda(int _id);

        [OperationContract]
        string SetKart(int _id);

        [OperationContract]
        string SetOdaMekan(int _id, int _mekanId, int _masaId, List<stok> urunMiktar);

        [OperationContract]
        string SetKartMekan(int _id, int _mekanId, int _masaId, List<stok> urunMiktar);
        

        [OperationContract]
        string SetStokGrup(string _ad);
        [OperationContract]
        string GetStokGroup();

        [OperationContract]
        string SetStokAd(string _ad);

        [OperationContract]
        string GetStok();

        [OperationContract]
        string SetBirim(string _ad);

        [OperationContract]
        string GetBirim();
        
        [OperationContract]
        string GetDepolar();

        [OperationContract]
        string SetMekanDepo(int mekanId, int depoId);

        [OperationContract]
        string GetMekanDepo();

        [OperationContract]
        string SetPozisyon(string _ad);

        [OperationContract]
        string GetPozisyon();
                      
        [OperationContract]
        string GetDonanim();

        [OperationContract]
        string SetPersonel(personel p);

        [OperationContract]
        string GetPersonel();

        [OperationContract]
        string GetPersonelId(int personelID);
                
        [OperationContract]
        string GetPersonelDepo();

       
        [OperationContract]
        string GetPersonelDonanim();

        [OperationContract]
        string GetPersonelIdDonanim(int personelId);

        [OperationContract]
        string MekanStok(int mekanId);

        [OperationContract]
        string SetStok(Stok s, int depoId);

        [OperationContract]
        string GetKisilerBakiye();

        [OperationContract]
        string GetKisiDurum();

        [OperationContract]
        string GetOda();

        [OperationContract]
        string GetBosKart();

        [OperationContract]
        string GetDoluKart();

        [OperationContract]
        string SetBakiyeEkle(int _kartId, decimal _nakit_bakiye, decimal _kredi_kart_bakiye);

        [OperationContract]
        string SetMekan(string _ad);

        [OperationContract]
        string GetMekanStok(int mekanId);

        //[OperationContract]
        //string SetStockEksilt(List<stok> urunler);

        [OperationContract]
        string SetStockEksilt(stok urun);

        [OperationContract]
        string SetDepo(depo d);

        [OperationContract]
        string GetMekan();

        [OperationContract]
        string GetDoluOda();

        [OperationContract]
        string SetDepoUrun(stok ss, depo d);

        [OperationContract]
        string GetKartBakiye(int id);

        [OperationContract]
        string GetKartOdeme(kart kk, DateTime ilkTarih, DateTime sonTarih);

        [OperationContract]
        string GetOdaOdeme(oda oo, DateTime ilkTarih, DateTime sonTarih);

        [OperationContract]
        string GetKisiBakiye(kart k);
        [OperationContract]
        string SetKisiKartCikis(kart k);
        [OperationContract]
        string SetKisiOdaCikis(oda oo);
        
        [OperationContract]
        string SetPersonelDepo(personel_depo p);
        [OperationContract]
        string SetPersonelDonanim(personel_donanim p);
        [OperationContract]
        string SetDonanim(donanim d);
        [OperationContract]
        string SetDepoYeniUrun(stok s, int depoId);
        [OperationContract]
        string GetDepoUrun(int depoId);

        [OperationContract]
        string SetDepoUrunEkle(stok s);
        [OperationContract]
        string GetStokAd();
        [OperationContract]
        string GetOdaUcret(int id);
        [OperationContract]
        string GetTur();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
