using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class DashLikidite : BaseModel
    {

        public static List<DashBilancoView> Get_MainList(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("Select * from TBLLikidite  where CompanyID=@companyID and Year= @nyear ", new { nyear = _year, companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
        }


        //public static List<DashBilancoView> Get_MBLikiditeKVBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVUznVdBorcKisaVadKrslk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103 LikiditeUznVadeBorcKisaVade - 'Uzun Vadeli Borçlanmaların Kısa Vadeli Kısımları'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVDigrFinsYukmlk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList(); //105  LikiditeDigerFinansalYuk 'Diğer Finansal Yükümlülükler'
        //}

        //public static List<DashBilancoView> Get_MBLikiditeKVTicBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); //107  LikiditeTicBorc 'Ticari Borçlar'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVOdenckVergi(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();//109 LikiditeTOdenckVergi 'Ödenecek vergi ve diğer yükümlülükler'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVDigerBorclar(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();// 111 LikiditeDigerBorclar 'Diğer Borçlar '
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVErtlnmsGelirler(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();// 113 LikiditeErtlnmsGelirler 'Ertelenmiş gelirler'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVonemKarVergiYukmluluk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList(); // 115 LikiditeDonemKarBergiYukmluluk 'Dönem Karı Vergi Yükümlülüğü'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVKisaVadeKarsilik(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,117", new { nyear = _year, companyID = _compID }).ToList(); // 117 LikiditeKisaVadeKarsilik 'Kısa vadeli Karşılıklar'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKVDigrKVadeYukmluluk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Blnc] @companyID, @nyear,119", new { nyear = _year, companyID = _compID }).ToList(); //119 LikiditeKDigrKVadeYukmluluk 'Diğer Kısa Vadeli Yükümlülükler'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeKisaVadeToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_Header_Bln] @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();// TOPLAM 101 'Toplam kısa vadeli yükümlülükler' 
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVUzunVadeBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,121", new { nyear = _year, companyID = _compID }).ToList();// 121 LikiditeUVUzunVadeBorc  'Uzun vadeli borçlanmalar'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVDigFinansYukmlulk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,123", new { nyear = _year, companyID = _compID }).ToList();// 123 LikiditeUVDigFinansYukmlulk  'Diğer Finansal Yükümlülükler (UV)'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVTicBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,125", new { nyear = _year, companyID = _compID }).ToList(); // 125 LikiditeUVTicBorc  'Ticari Borçlar (UV)'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVDigBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,127", new { nyear = _year, companyID = _compID }).ToList();// 127 LikiditeUVDigBorc  'Diğer Borçlar (UV)'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVErtlenemisGelir(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,129", new { nyear = _year, companyID = _compID }).ToList();//129 LikiditeUVErtlenemisGelir  'Ertelenmiş Gelirler (UV)'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVadeKarsilik(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,131", new { nyear = _year, companyID = _compID }).ToList();//131 LikiditeUVUzunVadeKarsilik  'Uzun Vadeli Karşılıklar'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVErtlVergiYukmlulk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,133", new { nyear = _year, companyID = _compID }).ToList();//133 LikiditeUVErtlenmsVergiYukmlulk 'Ertelenmiş Vergi Yükümlülüğü'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUVDigerUzVadYukumlk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Blnc @companyID, @nyear,135", new { nyear = _year, companyID = _compID }).ToList(); // 135 LikiditeUVDigerUzunVadeYukumlk    'Diğer Uzun Vadeli Yükümlülükler'
        //}
        //public static List<DashBilancoView> Get_MBLikiditeUzunVadeToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header_Bln @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList(); // TOPLAM 103 UZUN VADE
        //}
        //public static List<DashBilancoView> Get_MBLikiditeTUMToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoView>("EXEC [SP_Main_Grow_HeaderMainT_Bln] @companyID, @nyear,101,103", new { nyear = _year, companyID = _compID }).ToList();
        //}
        public static List<DashBilancoView> Get_LikiditeORANT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC [SP_RasyoLikiditeOran] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }


    }
    public class DashLikiditeViewMain
    {
        public static List<DashBilancoView> getList(int _year, long _compID)
        {
            DashLikiditeCheck nCheck = new DashLikiditeCheck();

            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap1(_year, _compID), "A-Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap2(_year, _compID), "A1-Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap3(_year, _compID), "A2-Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap4(_year, _compID), "A3-Diğer Alacaklar", "A3-Diğer Alacaklar");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVBorc(_year, _compID), "Kısa Vadeli Borçlanmalar", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVUznVdBorcKisaVadKrslk(_year, _compID), "Uzun Vadeli Borçlanmaların Kısa Vadeli Kısımları", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigrFinsYukmlk(_year, _compID), "Diğer Finansal Yükümlülükler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVTicBorc(_year, _compID), "Ticari Borçlar", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVOdenckVergi(_year, _compID), "Ödenecek Vergi Ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigerBorclar(_year, _compID), "Diğer Borçlar ", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVErtlnmsGelirler(_year, _compID), "Ertelenmiş gelirler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVonemKarVergiYukmluluk(_year, _compID), "Dönem Karı Vergi Yükümlülüğü", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVKisaVadeKarsilik(_year, _compID), "Kısa vadeli Karşılıklar", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigrKVadeYukmluluk(_year, _compID), "Diğer Kısa Vadeli Yükümlülükler", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKisaVadeToplamT(_year, _compID), "Toplam kısa vadeli yükümlülükler", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVUzunVadeBorc(_year, _compID), "Uzun vadeli borçlanmalar", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigFinansYukmlulk(_year, _compID), "Diğer Finansal Yükümlülükler (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVTicBorc(_year, _compID), "Ticari Borçlar (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigBorc(_year, _compID), "Diğer Borçlar (UV)", "Uzun vadeli yükümlülükler");


            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVErtlenemisGelir(_year, _compID), "Ertelenmiş Gelirler (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVadeKarsilik(_year, _compID), "Uzun Vadeli Karşılıklar", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVErtlVergiYukmlulk(_year, _compID), "Ertelenmiş Vergi Yükümlülüğü", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigerUzVadYukumlk(_year, _compID), "Diğer Uzun Vadeli Yükümlülükler", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUzunVadeToplamT(_year, _compID), "Toplam uzun vadeli yükümlülükler", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeTUMToplamT(_year, _compID), "Yükümlülükler toplamı", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", "Kısa vadeli yükümlülükler");
            // - 
            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_AlinanAvansUT(_year, _compID), "D4-Maddi Duran Varlıklar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", "Uzun vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", "Uzun vadeli yükümlülükler");
            return nCheck.mrequestEntry;
        }


    }

    public class DashLikiditeCheck
    {
        public DashLikiditeCheck()
        {
            mrequestEntry = new List<DashBilancoView>();

        }
        public List<DashBilancoView> mrequestEntry { get; set; }

        public void SetBilanco(List<DashBilancoView> mrequestEntryCount, string tname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
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
                mrequestEntry.Add(nDash);
            }

        }

        public void SetBilancoHeaderT(List<DashBilancoView> mrequestEntryCount, string tname, string mainname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = mainname;
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
                if (nDash.OverViewTotal != 0)
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

    }
}
