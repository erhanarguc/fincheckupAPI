using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class DashWCapital : BaseModel
    {

        public static List<DashBilancoView> Get_getDataWcap1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcap2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcap3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcap4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcap5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapUc(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapDort(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapBes(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM1(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM2(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM3(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM4(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM5(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM6(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM7(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM8(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_getDataWcapM9(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_getDataWcapWCT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_WCAPITALBYMONTH  @nyear, @companyID", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_getDataWcapFINAL(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("Select * from  TBLWcapital where CompanyID= @companyID and Year=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    //SP_A_MIZANHEADERChk

    public class DashWCapitalViewMain
    {

        public static List<DashBilancoView> getList(int _year, long _compID)
        {
            DashWCapitalCheck nCheck = new DashWCapitalCheck();

            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap1(_year, _compID), "Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap2(_year, _compID), "Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap3(_year, _compID), "Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap4(_year, _compID), "Diğer Alacaklar", "A3-Diğer Alacaklar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcap5(_year, _compID), "Stoklar", "A4-Stoklar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapUc(_year, _compID), "İnşaat ve Onarım", "A4_- İnşaat ve Onarım");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapDort(_year, _compID), "Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapBes(_year, _compID), "Diğer Dönen Varlıklar", "A7-Diğer Dönen Varlıklar");

            ////////////////////////
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM1(_year, _compID), "Mali Borçlar", "C-Mali Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM2(_year, _compID), "Ticari Borçlar", "C1-Ticari Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM3(_year, _compID), "Diğer Çeşitli  Borçlar", "C2-Diğer Çeşitli  Borçlar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM4(_year, _compID), "Alınan Avanslar", "C3-Alınan Avanslar");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM5(_year, _compID), "Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM6(_year, _compID), "Ödenencek Vergi ve Diğer Yükümlülükler", "C4-Ödenencek Vergi ve Diğer Yükümlülükler");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM7(_year, _compID), "Borç ve Gider Karşılıkları", "C5- Borç ve Gider Karşılıkları");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM8(_year, _compID), "Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları");
            nCheck.SetBilancoHeaderT(DashWCapital.Get_getDataWcapM9(_year, _compID), "Diğer Kısa Vadeli Yabancı Kaynaklar", "C7-Diğer Kısa Vadeli Yabancı Kaynaklar");


            return nCheck.mrequestEntry;
        }


    }
    public class DashWCapitalShortViewList
    {
        public static List<DashWCapitalShortView> getListDashWC(DashBilancoView coord)
        {
            List<DashWCapitalShortView> nlist = new List<DashWCapitalShortView>();
            DashWCapitalShortView nvWC = new DashWCapitalShortView();

            if (coord.January != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ocak Ayı(W/C)"; nvWC.mValue = coord.January.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.February != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Şubat Ayı(W/C)"; nvWC.mValue = coord.February.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.March != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Mart Ayı(W/C)"; nvWC.mValue = coord.March.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.April != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Nisan Ayı(W/C)"; nvWC.mValue = coord.April.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.May != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Mayıs Ayı(W/C)"; nvWC.mValue = coord.May.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.June != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Haziran Ayı(W/C)"; nvWC.mValue = coord.June.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.July != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Temmuz Ayı(W/C)"; nvWC.mValue = coord.July.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.August != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ağustos Ayı(W/C)"; nvWC.mValue = coord.August.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.September != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Eylül Ayı(W/C)"; nvWC.mValue = coord.September.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.October != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ekim Ayı(W/C)"; nvWC.mValue = coord.October.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.November != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Kasım Ayı(W/C)"; nvWC.mValue = coord.November.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.December != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Aralık Ayı(W/C)"; nvWC.mValue = coord.December.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            return nlist;
        }
        public static List<DashWCapitalShortViewChart> getListDashWChart(DashBilancoView coord)
        {
            List<DashWCapitalShortViewChart> nlist = new List<DashWCapitalShortViewChart>();
            DashWCapitalShortViewChart nvWC = new DashWCapitalShortViewChart();

            if (coord.January != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ocak"; nvWC.mValue = Convert.ToInt32(coord.January); nlist.Add(nvWC); }
            if (coord.February != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Şubat"; nvWC.mValue = Convert.ToInt32(coord.February); nlist.Add(nvWC); }
            if (coord.March != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Mart"; nvWC.mValue = Convert.ToInt32(coord.March); nlist.Add(nvWC); }
            if (coord.April != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Nisan"; nvWC.mValue = Convert.ToInt32(coord.April); nlist.Add(nvWC); }
            if (coord.May != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Mayıs"; nvWC.mValue = Convert.ToInt32(coord.May); nlist.Add(nvWC); }
            if (coord.June != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Haziran"; nvWC.mValue = Convert.ToInt32(coord.June); nlist.Add(nvWC); }
            if (coord.July != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Temmuz"; nvWC.mValue = Convert.ToInt32(coord.July); nlist.Add(nvWC); }
            if (coord.August != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ağustos"; nvWC.mValue = Convert.ToInt32(coord.August); nlist.Add(nvWC); }
            if (coord.September != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Eylül"; nvWC.mValue = Convert.ToInt32(coord.September); nlist.Add(nvWC); }
            if (coord.October != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ekim"; nvWC.mValue = Convert.ToInt32(coord.October); nlist.Add(nvWC); }
            if (coord.November != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Kasım"; nvWC.mValue = Convert.ToInt32(coord.November); nlist.Add(nvWC); }
            if (coord.December != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Aralık"; nvWC.mValue = Convert.ToInt32(coord.December); nlist.Add(nvWC); }
            return nlist;
        }
    }
    public class DashWCapitalShortViewChart
    {
        public string mText { get; set; }
        public long mValue { get; set; }
    }
    public class DashWCapitalShortView
    {
        public string mText { get; set; }
        public string mValue { get; set; }
    }
    public class DashWCapitalCheck
    {
        public DashWCapitalCheck()
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
                if (nDash.OverViewTotal != 0)
                {
                    mrequestEntry.Add(nDash);
                }

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
                nDash.March = mrequestEntryCount[i].March;
                nDash.May = mrequestEntryCount[i].May;
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
