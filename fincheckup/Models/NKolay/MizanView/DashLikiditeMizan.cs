using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashLikiditeMizan : BaseModel
    {
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
        //}
        public static List<DashBilancoViewMizan> Get_MAINRESULTMultiMain(long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("Select * from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID  ", new { companyID = _compID }).ToList();
        }
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVUznVdBorcKisaVadKrslk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();//103 LikiditeUznVadeBorcKisaVade - 'Uzun Vadeli Borçlanmaların Kısa Vadeli Kısımları'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVDigrFinsYukmlk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList(); //105  LikiditeDigerFinansalYuk 'Diğer Finansal Yükümlülükler'
        //}

        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVTicBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList(); //107  LikiditeTicBorc 'Ticari Borçlar'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVOdenckVergi(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();//109 LikiditeTOdenckVergi 'Ödenecek vergi ve diğer yükümlülükler'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVDigerBorclar(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();// 111 LikiditeDigerBorclar 'Diğer Borçlar '
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVErtlnmsGelirler(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();// 113 LikiditeErtlnmsGelirler 'Ertelenmiş gelirler'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVonemKarVergiYukmluluk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,115", new { nyear = _year, companyID = _compID }).ToList(); // 115 LikiditeDonemKarBergiYukmluluk 'Dönem Karı Vergi Yükümlülüğü'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVKisaVadeKarsilik(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,117", new { nyear = _year, companyID = _compID }).ToList(); // 117 LikiditeKisaVadeKarsilik 'Kısa vadeli Karşılıklar'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKVDigrKVadeYukmluluk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_BlncMizan] @companyID, @nyear,119", new { nyear = _year, companyID = _compID }).ToList(); //119 LikiditeKDigrKVadeYukmluluk 'Diğer Kısa Vadeli Yükümlülükler'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeKisaVadeToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_Header_BlnMizan] @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();// TOPLAM 101 'Toplam kısa vadeli yükümlülükler' 
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVUzunVadeBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,121", new { nyear = _year, companyID = _compID }).ToList();// 121 LikiditeUVUzunVadeBorc  'Uzun vadeli borçlanmalar'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVDigFinansYukmlulk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,123", new { nyear = _year, companyID = _compID }).ToList();// 123 LikiditeUVDigFinansYukmlulk  'Diğer Finansal Yükümlülükler (UV)'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVTicBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,125", new { nyear = _year, companyID = _compID }).ToList(); // 125 LikiditeUVTicBorc  'Ticari Borçlar (UV)'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVDigBorc(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,127", new { nyear = _year, companyID = _compID }).ToList();// 127 LikiditeUVDigBorc  'Diğer Borçlar (UV)'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVErtlenemisGelir(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,129", new { nyear = _year, companyID = _compID }).ToList();//129 LikiditeUVErtlenemisGelir  'Ertelenmiş Gelirler (UV)'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVadeKarsilik(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,131", new { nyear = _year, companyID = _compID }).ToList();//131 LikiditeUVUzunVadeKarsilik  'Uzun Vadeli Karşılıklar'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVErtlVergiYukmlulk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,133", new { nyear = _year, companyID = _compID }).ToList();//133 LikiditeUVErtlenmsVergiYukmlulk 'Ertelenmiş Vergi Yükümlülüğü'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUVDigerUzVadYukumlk(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_BlncMizan @companyID, @nyear,135", new { nyear = _year, companyID = _compID }).ToList(); // 135 LikiditeUVDigerUzunVadeYukumlk    'Diğer Uzun Vadeli Yükümlülükler'
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeUzunVadeToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header_BlnMizan @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList(); // TOPLAM 103 UZUN VADE
        //}
        //public static List<DashBilancoViewMizan> Get_MBLikiditeTUMToplamT(int _year, long _compID)
        //{
        //    return StaticQuery<DashBilancoViewMizan>("EXEC [SP_Main_Grow_HeaderMainT_BlnMizan] @companyID, @nyear,101,103", new { nyear = _year, companyID = _compID }).ToList();
        //}
        public static List<DashBilancoViewMizan> Get_MainList(long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("Select * from TBLLikiditeMZN where CompanyID=@companyID ", new { companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
        }

        public static List<DashYearlyResultMizan> Get_LikiditeORANT(long _compID)
        {
            return StaticQuery<DashYearlyResultMizan>("Select * from  TTZDashBoardOranMzn where CompanyID=@companyID and Description='Likidite Oranı'", new { companyID = _compID }).ToList();
        }


    }
    public class DashLikiditeViewMainMizan
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashLikiditeCheckMizan nCheck = new DashLikiditeCheckMizan();

            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap1(_year, _compID), "A-Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap2(_year, _compID), "A1-Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap3(_year, _compID), "A2-Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap4(_year, _compID), "A3-Diğer Alacaklar", "A3-Diğer Alacaklar");
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", "Kısa vadeli yükümlülükler");
            // - 
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansUT(_year, _compID), "D4-Maddi Duran Varlıklar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", "Uzun vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", "Uzun vadeli yükümlülükler");
            return nCheck.mrequestEntry;
        }


    }
    public class DashLikiditeCheckMizan
    {
        public DashLikiditeCheckMizan()
        {
            mrequestEntry = new List<DashBilancoViewMizan>();

        }
        public List<DashBilancoViewMizan> mrequestEntry { get; set; }

        public void SetBilanco(List<DashBilancoViewMizan> mrequestEntryCount, string tname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewMizan();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.Year = mrequestEntryCount[i].Year;
                if (nDash.Amount != 0)
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

        public void SetBilancoHeaderT(List<DashBilancoViewMizan> mrequestEntryCount, string tname, string mainname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewMizan();
                nDash.CounterZone = countet;
                nDash.GroupName = mainname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Amount = mrequestEntryCount[i].Amount;
                nDash.Year = mrequestEntryCount[i].Year;
                if (nDash.Amount != 0)
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

    }
}
