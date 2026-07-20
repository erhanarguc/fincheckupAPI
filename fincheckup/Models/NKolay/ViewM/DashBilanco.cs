using fincheckup.Models.NKolay.ViewM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public static class reportZone
    {

        public static List<DashBilancoViewQnb> getReverse(List<DashBilancoViewQnb> chkList, double setValue)
        {
            if (setValue == 0)
            {
                return chkList;
            }
            chkList.ForEach(i => i.percentageChk = (Math.Abs(i.Amount) / Math.Abs(setValue)) * 100);
            return chkList;
        }

        public static DashBilancoViewQnb getReverseSingle(DashBilancoViewQnb chkList, double setValue)
        {
            if (setValue == 0)
            {
                return chkList;
            }

            chkList.percentageChk = ((Math.Abs(chkList.Amount) / Math.Abs(setValue)) * 100);
            return chkList;
        }
    }

    //(current / maximum) * 100
    public class DashBilanco : BaseModel
    {
        public static List<DashBilancoView> Get_MAINRESULT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("Select * from  TBLMRevenue Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static DashBilancoViewMarj Get_MAINBrutKarZarar(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMarj>("SELECT TOP 1 *  FROM [dbo].[TBLWcapBrutKarZarar] Where [CompanyID]=@companyID and[Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }

        public static DashBilancoViewMarj Get_MAINNetSatis(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMarj>("SELECT  TOP 1 *  FROM [dbo].[TBLWcapNetSatis] Where [CompanyID]=@companyID and[Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
    }
    public class DashBilancoViewMainQnbGelir
    {
        public static List<DashBilancoViewQnb> getList(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_1(_year, _compID), "1.1", "Toplam Satış Gelirleri", 97, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_3(_year, _compID), "1.2", "Yurtiçi Satış Gelirleri", 99, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_5(_year, _compID), "1.3", "Yurtdışı Satış Gelirleri", 101, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_7(_year, _compID), "1.3.1", "Diğer Gelirler", 103, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_9(_year, _compID), "1.3.2", "Satış İadeleri(-)", 105, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelir.Get_11(_year, _compID), "1.3.3", "Toplam Satış Maliyeti", 107, 1);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListA(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirA.Get_1(_year, _compID), "2.1", "Brüt Kar", 109, 1);


            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListB(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirB.Get_1(_year, _compID), "3.0", "Faaliyet Giderleri", 111, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirB.Get_3(_year, _compID), "4.1", "Esas Faaliyet Karı (Zararı)", 113, 1);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListC(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirC.Get_1(_year, _compID), "4.1", "Finansman Gideri", 115, 1);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListD(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirD.Get_1(_year, _compID), "5.1", "Kambiyo Karı (Zararı)", 117, 1);


            return nCheck.mrequestEntry;
        }

        public static List<DashBilancoViewQnb> getListE(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirE.Get_1(_year, _compID), "5.1", "Toplam Diğer Faaliyetlerden Olağan Gelir / Gider", 119, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirE.Get_3(_year, _compID), "5.2", "Diğer Faaliyetlerden Olağan Gelir Ve Karlar", 121, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirE.Get_5(_year, _compID), "5.3", "Diğer Faaliyetlerden Olağan Gider Ve Zararlar(-)", 123, 1);


            return nCheck.mrequestEntry;
        }

        public static List<DashBilancoViewQnb> getListF(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirF.Get_1(_year, _compID), "4.1", "Vergi Öncesi Kar (Zarar)", 125, 1);

            return nCheck.mrequestEntry;
        }
        //
        public static List<DashBilancoViewQnb> getListG(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirG.Get_1(_year, _compID), "4.1", "Toplam Olağandışı Gelir Ve Karlar /Gider Ve Zararlar ", 127, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirG.Get_3(_year, _compID), "4.1", "Olağandışı Gelir Ve Karlar", 129, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirG.Get_5(_year, _compID), "4.1", "Olağandışı Gider Ve Zararlar (-) ", 131, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirG.Get_7(_year, _compID), "4.1", "Dönem Karı Vergi Ve Diğ.Yasal Yükümlülük Karşılığı", 132, 1);
            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListH(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirH.Get_1(_year, _compID), "4.1", "Dönem Karı (Zararı)", 133, 1);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListI(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbGelirI.Get_1(_year, _compID), "4.1", "FAVÖK (EBITDA)", 135, 1);

            return nCheck.mrequestEntry;
        }

        public static void setListSektor(int _year, long _compID,int chkMizn=0)
        {
            if (chkMizn==0)
            {
                DashBilancoSetQnbGelirI.SetSektor(_year, _compID);
            }
            else
            {
                DashBilancoSetQnbGelirI.SetSektorMizan(_year, _compID);
            }


        }
    }
    public class DashBilancoViewMainQnb
    {
        public static List<DashBilancoViewQnb> getList(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_HazirDegerT(_year, _compID), "1.1", "Hazır Değerler", 1, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_MenkulKiymetT(_year, _compID), "1.2", "Menkul Kıymetler", 3, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_TicariAlacakT(_year, _compID), "1.3", "Ticari Alacaklar", 5, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_AlicilarT(_year, _compID), "1.3.1", "Alıcılar", 7, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_AlinanCeklerT(_year, _compID), "1.3.2", "Alınan Çekler", 9, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_SupheliTicariT(_year, _compID), "1.3.3", "Şüpheli Ticari Alacaklar Karşılığı (-)", 11, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_StoklarT(_year, _compID), "1.4", "Stoklar", 13, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_HammaddeT(_year, _compID), "1.4.1", "Hammadde ve Malzeme", 15, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_YariMamulT(_year, _compID), "1.4.2", "Yarımamul ve Mamuller", 17, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_TicariMalT(_year, _compID), "1.4.3", "Ticari Mallar", 19, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_VerilenSiparisT(_year, _compID), "1.4.4", "Verilen Sipariş  Avansları", 21, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_insaatT(_year, _compID), "1.5", "İnşaat ve Onarım ", 23, 1);


            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_OrtakalacakT(_year, _compID), "1.6", "Ortaklardan Alacaklar  / Bağlı Ortaklıklar ", 25, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_DigerAlacakT(_year, _compID), "1.7", "Diğer Alacaklar ", 27, 1);

            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_GelecekAyT(_year, _compID), "1.8", "Gelecek Aylara ait Giderler ve Gelir Tahakkukları", 29, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_DigerDonenT(_year, _compID), "1.9", "Toplam Diğer Dönen Varlıklar", 31, 1);
            return nCheck.mrequestEntry;
        }

        public static List<DashBilancoViewQnb> getListToplam(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnb.Get_Toplam(_year, _compID), string.Empty, "Toplam Dönen Varlıklar", 311, 1);
            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListA(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_1(_year, _compID), "2.1", "Net Maddi Duran Varlıklar", 33, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_2(_year, _compID), "2.2", "Net Maddi Olmayan Varlıklar", 35, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_3(_year, _compID), "2.3", "İştirak ve Bağlı ortaklıklar/Ortaklardan Alacaklar", 37, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_4(_year, _compID), "2.4", "Ticari Alacaklar", 39, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_5(_year, _compID), "2.5", "Diğer Alacaklar ", 41, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_6(_year, _compID), "2.6", "Diğer Bağlı Kıymetler", 43, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_7(_year, _compID), "2.7", "Özel Tükenmeye Tabi Varlıklar", 45, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_8(_year, _compID), "2.8", "Diğer Duran Varlıklar ", 47, 1);
            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListAToplam(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_Toplam(_year, _compID), string.Empty, "Toplam Duran Varlıklar", 471, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbA.Get_ToplamA(_year, _compID), string.Empty, "Toplam Varlıklar", 473, 1);

            return nCheck.mrequestEntry;
        }

        public static List<DashBilancoViewQnb> getListB(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_1(_year, _compID), "3.0", "Kısa Vadeli Mali Borçlar", 49, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_2(_year, _compID), "3.1", "Uzun Vadeli Borç Cari Yıl Taksidi", 51, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_3(_year, _compID), "3.2", "Ticari Boçlar", 53, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_4(_year, _compID), "3.2.1", "Senetli Borçlar", 55, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_5(_year, _compID), "3.2.2", "Ticari Borçlar", 57, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_6(_year, _compID), "3.3", "Ortaklara ve Bağlı Şirketlere Borçlar", 59, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_7(_year, _compID), "3.3", "Diğer Borçlar", 61, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_8(_year, _compID), "3.4", "Alınan Sipariş Avansları", 63, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_9(_year, _compID), "3.5", "Yıllara Yaygın İnşat ve Onarım Hakedişleri", 65, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_10(_year, _compID), "3.6", "Ödenecek Vergiler", 67, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_11(_year, _compID), "3.7", "Borç ve Gider Karşılıkları", 69, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_12(_year, _compID), "3.8", "Gelecek Ayllara Ait Gelir ve Gider Tahakkukları", 71, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_13(_year, _compID), "3.9", "Diğer Kısa Vadeli Borçlar", 711, 1);
            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListBToplam(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbB.Get_Toplam(_year, _compID), string.Empty, "Toplam Kısa Vadeli Borçlar", 713, 1);


            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListC(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_1(_year, _compID), "4.1", "Uzun Vadeli Mali Borçlar", 73, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_2(_year, _compID), "4.2", "Ticari Borçlar ", 75, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_3(_year, _compID), "4.3", "Ortaklara ve Bağlı Şirketlere  Borçlar", 77, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_4(_year, _compID), "4.4", "Diğer Borçlar", 79, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_5(_year, _compID), "4.5", "Alınan Sipariş Avansları", 81, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_6(_year, _compID), "4.6", "Borç ve Gider Karşılıkları ", 83, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_7(_year, _compID), "4.7", "Toplam Diğer Uzun Vadeli Borçlar", 85, 1);
            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListCToplam(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbC.Get_Toplam(_year, _compID), string.Empty, "Toplam Uzun Vadeli Borçlar", 851, 1);

            return nCheck.mrequestEntry;
        }
        public static List<DashBilancoViewQnb> getListD(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_1(_year, _compID), "5.1", "Ödenmiş Sermaye", 87, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_2(_year, _compID), "5.2", "İhtiyatlar ve Yedekler", 89, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_3(_year, _compID), "5.3", "Özel Fonlar", 91, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_4(_year, _compID), "5.4", "Geçmiş Yıl Karları / Zararları", 93, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_5(_year, _compID), "5.5", "Dönem Karı / Zararı", 95, 1);
            return nCheck.mrequestEntry;
        }

        public static List<DashBilancoViewQnb> getListDToplam(int _year, long _compID)
        {
            DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_Toplam(_year, _compID), string.Empty, "Toplam Özkaynaklar", 951, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_ToplamA(_year, _compID), string.Empty, "Toplam Borçlar", 953, 1);
            nCheck.SetBilancoHeaderT(DashBilancoSetQnbD.Get_ToplamB(_year, _compID), string.Empty, "Toplam Borç ve Özkaynak", 955, 1);
            return nCheck.mrequestEntry;
        }

        //Toplam Borçlar
    }
    public class DashBilancoViewMain
    {
        public static List<DashBilancoView> getList(int _year, long _compID)
        {
            DashBilancoViewCheck nCheck = new DashBilancoViewCheck();
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_Stok(_year, _compID), "A4-Stoklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2121, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
            // -
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
            nCheck.SetBilanco(DashBilancoSet.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

            ///

            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMOzKaynakUT(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSet.Get_TOPLAMPasif(_year, _compID), "NTT- TOPLAM PASİFLER", 4141, 0);

            //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





            return nCheck.mrequestEntry;
        }


    }


    public class DashBilancoViewCheckQnb
    {
        public DashBilancoViewCheckQnb()
        {
            mrequestEntry = new List<DashBilancoViewQnb>();
            countet = 0;
        }
        public List<DashBilancoViewQnb> mrequestEntry { get; set; }
        public int countet { get; set; }




        public void SetBilanco(List<DashBilancoViewQnb> mrequestEntryCount, string tname, int hidden_)
        {
            var mrequest = mrequestEntryCount.OrderBy(x => x.AccountMainID).ToList();
            DashBilancoViewQnb nDash = new DashBilancoViewQnb();
            for (int i = 0; i < mrequest.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewQnb();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequest[i].AccountMainDescription;
                nDash.AccountMainID = mrequest[i].AccountMainID;
                nDash.Amount = mrequest[i].Amount;
                nDash.Year = mrequest[i].Year;
                nDash.IsHidden = hidden_;
                mrequestEntry.Add(nDash);


            }

        }

        public void SetBilancoHeaderT(List<DashBilancoViewQnb> mrequestEntryCount, string tnameCode, string tname, int typeid_, int hidden_)
        {

            DashBilancoViewQnb nDash = new DashBilancoViewQnb();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewQnb();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = tnameCode;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = typeid_;
                nDash.IsHidden = hidden_;
                mrequestEntry.Add(nDash);

            }

        }

    }
    public class DashBilancoViewCheck
    {
        public DashBilancoViewCheck()
        {
            mrequestEntry = new List<DashBilancoView>();
            countet = 0;
        }
        public List<DashBilancoView> mrequestEntry { get; set; }
        public int countet { get; set; }




        public void SetBilanco(List<DashBilancoView> mrequestEntryCount, string tname, int hidden_)
        {
            var mrequest = mrequestEntryCount.OrderBy(x => x.AccountMainID).ToList();
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequest.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequest[i].AccountMainDescription;
                nDash.AccountMainID = mrequest[i].AccountMainID;
                nDash.Acilis = mrequest[i].Acilis;
                nDash.April = mrequest[i].April;
                nDash.August = mrequest[i].August;
                nDash.CompanyID = mrequest[i].CompanyID;
                nDash.DebitCreditCode = mrequest[i].DebitCreditCode;
                nDash.December = mrequest[i].December;
                nDash.February = mrequest[i].February;
                nDash.January = mrequest[i].January;
                nDash.July = mrequest[i].July;
                nDash.June = mrequest[i].June;
                nDash.May = mrequest[i].May;
                nDash.March = mrequest[i].March;
                nDash.November = mrequest[i].November;
                nDash.October = mrequest[i].October;
                nDash.September = mrequest[i].September;
                nDash.Year = mrequest[i].Year;
                nDash.IsHidden = hidden_;
                if (nDash.getStatue())
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

        public void SetBilancoHeaderT(List<DashBilancoView> mrequestEntryCount, string tname, int typeid_, int hidden_)
        {

            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Acilis = mrequestEntryCount[i].Acilis;
                nDash.April = mrequestEntryCount[i].April;
                nDash.August = mrequestEntryCount[i].August;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.December = mrequestEntryCount[i].December;
                nDash.February = mrequestEntryCount[i].February;
                nDash.January = mrequestEntryCount[i].January;
                nDash.July = mrequestEntryCount[i].July;
                nDash.June = mrequestEntryCount[i].June;
                nDash.May = mrequestEntryCount[i].May;
                nDash.March = mrequestEntryCount[i].March;
                nDash.November = mrequestEntryCount[i].November;
                nDash.October = mrequestEntryCount[i].October;
                nDash.September = mrequestEntryCount[i].September;
                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = typeid_;
                nDash.IsHidden = hidden_;
                if (nDash.getStatue())
                {
                    mrequestEntry.Add(nDash);
                }
            }

        }

    }


    public class DashYearlyBilancoChart
    {
        public DashYearlyBilancoChart()
        {
            nresult = new List<DashYearlyBilancoMain>();
        }
        public List<DashYearlyBilancoMain> nresult { get; set; }

        public void SetResult(List<DashBilancoView> tdash, int nyear)
        {
            DashYearlyBilancoMain nv = new DashYearlyBilancoMain();
            List<DashBilancoViewTx> nlist = DashBilancoViewTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in nlist)
            {
                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/01/15");
                nv.SortVal = 1;
                nv.Value = item.January;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/02/15");
                nv.SortVal = 2;
                nv.Value = item.February;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/03/15");
                nv.SortVal = 3;
                nv.Value = item.March;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/04/15");
                nv.SortVal = 4;
                nv.Value = item.April;
                nv.GroupName = item.GroupName;
                nv.TypeID = item.TypeID;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/05/15");
                nv.SortVal = 5;
                nv.Value = item.May;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/06/15");
                nv.SortVal = 6;
                nv.Value = item.June;
                nv.GroupName = item.GroupName;
                nv.TypeID = item.TypeID;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/07/15");
                nv.SortVal = 7;
                nv.Value = item.July;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/08/15");
                nv.SortVal = 8;
                nv.Value = item.August;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/09/15");
                nv.SortVal = 9;
                nv.Value = item.September;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/10/15");
                nv.SortVal = 10;
                nv.Value = item.October;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/11/15");
                nv.SortVal = 11;
                nv.Value = item.November;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyBilancoMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/12/15");
                nv.SortVal = 12;
                nv.Value = item.December;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CounterZone = item.CounterZone;
                nresult.Add(nv);

            }


        }

    }


    public class DashYearlyBilancoMain
    {
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public double Value { get; set; }
        public int SortVal { get; set; }
        public int TypeID { get; set; }
        public int CounterZone { get; set; }
        public string GroupName { get; set; }
    }
    public class DashBilancoViewTx
    {
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double Acilis { get; set; }
        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public int IsHidden { get; set; }

        public double JanuaryTx => January;
        public double FebruaryTx => February != 0 ? January + February : 0;
        public double MarchTx => March != 0 ? January + February + March : 0;
        public double AprilTx => April != 0 ? January + February + March + April : 0;
        public double MayTx => May != 0 ? January + February + March + April + May : 0;
        public double JuneTx => June != 0 ? January + February + March + April + May + June : 0;
        public double JulyTx => July != 0 ? January + February + March + April + May + June + July : 0;
        public double AugustTx => August != 0 ? January + February + March + April + May + June + July + August : 0;
        public double SeptemberTx => September != 0 ? January + February + March + April + May + June + July + August + September : 0;
        public double OctoberTx => October != 0 ? January + February + March + April + May + June + July + August + September + October : 0;
        public double NovemberTx => November != 0 ? January + February + March + April + May + June + July + August + September + October + November : 0;
        public double DecemberTx => December != 0 ? January + February + March + April + May + June + July + August + September + October + November + December : 0;




        public static List<DashBilancoViewTx> setDashBilanco(List<DashBilancoView> mdash)
        {
            List<DashBilancoViewTx> nlist = new List<DashBilancoViewTx>();

            nlist = mdash.Select(x => new DashBilancoViewTx()
            {
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                DebitCreditCode = x.DebitCreditCode,
                Acilis = x.Acilis,
                January = x.January,
                February = x.February,
                March = x.March,
                April = x.April,
                May = x.May,
                June = x.June,
                July = x.July,
                August = x.August,
                September = x.September,
                October = x.October,
                November = x.November,
                December = x.December,
                CompanyID = x.CompanyID,
                Year = x.Year,
                GroupName = x.GroupName,
                CounterZone = x.CounterZone,
                TypeID = x.TypeID,
                IsHidden = x.IsHidden
            }).ToList();
            return nlist;

        }

    }
    public class DashBilancoViewMulti
    {

        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double Amount { get; set; }


        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }



    }


    public class DashBilancoViewQnb
    {

        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        private double amount { get; set; }
        public double Amount
        {
            get { return amount; }
            set
            {
                if (value < 1 && value > 0)
                {
                    value = 1;
                }
                amount = value;
            }
        }
        private double amount1 { get; set; }
        public double Amount1
        {
            get { return amount1; }
            set
            {
                if (value < 1 && value > 0)
                {
                    value = 1;
                }
                amount1 = value;
            }
        }
        private double amount2 { get; set; }
        public double Amount2
        {
            get { return amount2; }
            set
            {
                if (value < 1 && value > 0)
                {
                    value = 1;
                }
                amount2 = value;
            }
        }
        private double amount3 { get; set; }
        public double Amount3
        {
            get { return amount3; }
            set
            {
                if (value < 1 && value > 0)
                {
                    value = 1;
                }
                amount3 = value;
            }
        }
        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public byte MainTypeID { get; set; }
        public double percentageChk { get; set; }
        public double percentageChka { get; set; }
        public double percentageChkb { get; set; }
        public double percentageChkc { get; set; }
    }

    public class DashBilancoView
    {
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double Acilis { get; set; }
        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }

        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public string QnbDescription { get; set; }
        public Int64 OverViewTotal => Convert.ToInt64(September + October + November + May + March + June + July + January + February + December + August + April);
        public Int64 getTotalInt()
        {

            return Convert.ToInt64(September + October + November + May + March + June + July + January + February + December + August + April);
        }
        public double getTotaldecimal()
        {

            return September + October + November + May + March + June + July + January + February + December + August + April;
        }

        public bool getStatue()
        {
            int ncoun = 0;
            Boolean chk = true;
            if (September != 0) { ncoun++; }
            if (October != 0) { ncoun++; }
            if (November != 0) { ncoun++; }
            if (May != 0) { ncoun++; }
            if (March != 0) { ncoun++; }
            if (June != 0) { ncoun++; }
            if (July != 0) { ncoun++; }
            if (January != 0) { ncoun++; }
            if (February != 0) { ncoun++; }
            if (December != 0) { ncoun++; }
            if (August != 0) { ncoun++; }
            if (April != 0) { ncoun++; }
            if (ncoun == 0)
            {
                chk = false;
            }

            return chk;
        }

        public string getAvaerageString()
        {
            int ncoun = 0;
            if (September != 0) { ncoun++; }
            if (October != 0) { ncoun++; }
            if (November != 0) { ncoun++; }
            if (May != 0) { ncoun++; }
            if (March != 0) { ncoun++; }
            if (June != 0) { ncoun++; }
            if (July != 0) { ncoun++; }
            if (January != 0) { ncoun++; }
            if (February != 0) { ncoun++; }
            if (December != 0) { ncoun++; }
            if (August != 0) { ncoun++; }
            if (April != 0) { ncoun++; }
            if (ncoun == 0)
            {
                return "0";
            }
            else
            {
                return ((September + October + November + May + March + June + July + January + February + December + August + April) / Convert.ToDouble(ncoun)).ToString("0.00");
            }

        }

    }
    //,[MainDescription]
    //  ,[ColorDesc]
    //  ,[Description]
    //  ,[CompanyID]
    //  ,[Year]
    //  ,[CreatedDate]
    //  ,[Amount]

    public class DashBilancoViewMznShort
    {
        public string AccountMainID { get; set; }
        public string AccountMainIDTxt
        {
            get
            {
                return AccountMainID + " - " + AccountMainDescription;
            }
        }
        public string AccountMainDescription { get; set; }
        public long SmmBefore { get; set; }
        public long SmmAfter { get; set; }
        public long AktarmaOnce => SmmBefore;
        public long AktarmaSonra => SmmAfter;
        public long Diff { get; set; }
        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
    }
    public class DashBilancoViewMarj
    {
        public string AccountMainDescription { get; set; }
        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }


        public Int64 OverViewTotal => Convert.ToInt64(September + October + November + May + March + June + July + January + February + December + August + April);


    }
}
