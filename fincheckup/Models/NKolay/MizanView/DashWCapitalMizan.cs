using fincheckup.Models.NKolay.MizanView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashWCapitalMizan : BaseModel
    {
        public static List<DashBilancoViewMizan> Get_getDataWcap1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcap2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcap3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcap4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcap5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapUc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapDort(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapBes(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM6(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM8(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMizan> Get_getDataWcapM9(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoViewMizan> Get_getDataWcapWCT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("EXEC SP_WCAPITALBYMONTH  @nyear, @companyID", new { nyear = _year, companyID = _compID }).ToList();
        }


        public static List<DashBilancoViewMizan> Get_getDataWcapFINALMain(long _compID)
        {
            return StaticQuery<DashBilancoViewMizan>("Select * from  TBLWcapitalMZN where CompanyID= @companyID  ", new { companyID = _compID }).ToList();
        }
    }
    public class DashWCapitalViewMainMizan
    {

        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashWCapitalCheckMizan nCheck = new DashWCapitalCheckMizan();

            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap1(_year, _compID), "Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap2(_year, _compID), "Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap3(_year, _compID), "Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap4(_year, _compID), "Diğer Alacaklar", "A3-Diğer Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcap5(_year, _compID), "Stoklar", "A4-Stoklar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapUc(_year, _compID), "İnşaat ve Onarım", "A4_- İnşaat ve Onarım");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapDort(_year, _compID), "Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapBes(_year, _compID), "Diğer Dönen Varlıklar", "A7-Diğer Dönen Varlıklar");

            ////////////////////////
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM1(_year, _compID), "Mali Borçlar", "C-Mali Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM2(_year, _compID), "Ticari Borçlar", "C1-Ticari Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM3(_year, _compID), "Diğer Çeşitli  Borçlar", "C2-Diğer Çeşitli  Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM4(_year, _compID), "Alınan Avanslar", "C3-Alınan Avanslar");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM5(_year, _compID), "Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM6(_year, _compID), "Ödenencek Vergi ve Diğer Yükümlülükler", "C4-Ödenencek Vergi ve Diğer Yükümlülükler");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM7(_year, _compID), "Borç ve Gider Karşılıkları", "C5- Borç ve Gider Karşılıkları");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM8(_year, _compID), "Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları");
            nCheck.SetBilancoHeaderT(DashWCapitalMizan.Get_getDataWcapM9(_year, _compID), "Diğer Kısa Vadeli Yabancı Kaynaklar", "C7-Diğer Kısa Vadeli Yabancı Kaynaklar");


            return nCheck.mrequestEntry;
        }


    }
}

public class DashWCapitalCheckMizan
{
    public DashWCapitalCheckMizan()
    {
        mrequestEntry = new List<DashBilancoViewMizan>();

    }
    public List<DashBilancoViewMizan> mrequestEntry { get; set; }

    //public void SetBilanco(List<DashBilancoViewMizan> mrequestEntryCount, string tname)
    //{
    //    int countet = mrequestEntry.Count();
    //    DashBilancoViewMizan nDash = new DashBilancoViewMizan();
    //    for (int i = 0; i < mrequestEntryCount.Count(); i++)
    //    {
    //        countet++;
    //        nDash = new DashBilancoViewMizan();
    //        nDash.CounterZone = countet;
    //        nDash.GroupName = tname;
    //        nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
    //        nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
    //        nDash.Amount = mrequestEntryCount[i].Amount;
    //        nDash.Year = mrequestEntryCount[i].Year;
    //        if (nDash.Amount != 0)
    //        {
    //            mrequestEntry.Add(nDash);
    //        }

    //    }

    //}

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
