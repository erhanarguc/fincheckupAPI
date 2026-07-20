using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class ReportDash : BaseModel
    {
        public static IEnumerable<YearlyReportDash> Get_Data_GrossProfitMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and AccountMainID in ('600','601','602') group by [Year],[CompanyID]", new { companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_BrutKarZararMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and TypeID in ('222') group by [Year],[CompanyID]", new { companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and AccountMainID in ('300','400')  group by [Year],[CompanyID]", new { companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMultiMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_BFINANCEDeptMONTHMIZAN @companyID", new { companyID = _compID });
        }

        //SP_BFINANCEDeptMONTHMIZAN
        public static IEnumerable<YearlyReportDash> Get_Data_FinancialCariOrANMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>(" SELECT * FROM [EDEFTERDB].[dbo].TTZDashBoardOranMzn  where  CompanyID=@companyID  and TypeID=2  and Description='Cari Oran' ", new {companyID = _compID });
        }

        //SP_WCAPITALBYMONTHV21Mizan
        public static IEnumerable<YearlyReportDash> Get_Data_WorkingCapitalMIZAN(long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_WCAPITALBYMONTHV21Mizan @companyID ", new {companyID = _compID });
        }
        public static IEnumerable<ReportMainItem> DataReportMainKapakMIZAN(long _compID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            string sql = @"Select * from [dbo].[TBMLREPOR01MZN] where   CompanyID=@companyID ";

            return StaticQuery<ReportMainItem>(sql, new { companyID = _compID });

        }
        public static IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktifMIZAN(long _compID)
        {
            List <DashBilancoViewMarj> nmarJ= StaticQuery<DashBilancoViewMarj>("SELECT top 1 * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn]  where  CompanyID=@companyID  and TypeID in ('2221')  order by Year desc ", new { companyID = _compID }).ToList();
            List<DashBilancoViewMarj> nmarJ1 = StaticQuery<DashBilancoViewMarj>("SELECT top 1 * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn]  where  CompanyID=@companyID  and TypeID in ('3333')  order by Year desc   ", new { companyID = _compID }).ToList();
            nmarJ.AddRange(nmarJ1);

            return nmarJ;
        }
        public static IEnumerable<YearlyReportDash> Get_Data_RevenueMizan(  long _compID)
        {
            return StaticQuery<YearlyReportDash>("SELECT [Amount] ,[CompanyID]  ,[Year] FROM [EDEFTERDB].[dbo].[TBLWcapNetSatisMizan] where CompanyID=@companyID ", new {  companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_DonemselKarzararMIZAN( long _compID)
        {
            return StaticQuery<YearlyReportDash>("Select * from  [TBLWcapBrutKarZararMizan]  where   CompanyID=@companyID  ", new { companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_EbitMarjinMIZAN( long _compID)
        {
            return StaticQuery<YearlyReportDash>("Select * from  [TBLWcapEsasMaliyetKarZararMizan]  where   CompanyID=@companyID ", new { companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_GrossProfit(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_BRUTKARZBYMONTHV3 @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        //SELECT   SUM([Amount])   ,[CompanyID] ,[Year]  FROM [EDEFTERDB].[dbo].TBLMSampleBlncoMzn where CompanyID =9  and AccountMainID in ('300','400' ) group by [Year],[CompanyID] 
        public static IEnumerable<YearlyReportDash> Get_Data_FinancialDebit(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_BFINANCEMONTH @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMulti(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_BFINANCEDeptMONTH @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
      
        public static IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            string sql = @"Select * from [dbo].[TBMLREPOR01] where   CompanyID=@companyID and  [Year]=@nyear";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

        }
        public static DashBilancoViewMarj Get_Data_FinancialCariOrAN(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMarj>(" SELECT * FROM [EDEFTERDB].[dbo].TTZDashBoardOran  where  CompanyID=@companyID and  Year=@nyear and TypeID=2  and Description='Cari Oran' ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktif(int _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMarj>("SELECT * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoRasT]  where  CompanyID=@companyID and  Year=@nyear and TypeID in ('3333','2121')   ", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_Revenue(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_GELIRLERBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDashGraphic> Get_Data_GrossProfitGraphic(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDashGraphic>("EXEC SP_BRUTKARZBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }

        public static IEnumerable<YearlyReportDash> Get_Data_DonemselKarzarar(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_DONEMNTKARZBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        //SP_WCAPITALBYMONTHV21Mizan
        public static DashYearlyResultWorkingCapital Get_Data_WorkingCapital(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResultWorkingCapital>("EXEC SP_WCAPITALBYMONTHV21 @companyID,@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static int Get_LastMonthYear(int _year, long _compID)
        {
            return StaticQuery<int>("Select TOP 1  MONTH(DocumentDate) from TBLXml where CompanyID=@companyID and Year=@nyear order by DocumentDate Desc", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static IEnumerable<YearlyReportDash> Get_Data_BLNC(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_WCAPITALBYMONTBLNC @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_CRORN(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_WCAPITALBYMONTCRORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_NKTORN(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_WCAPITALBYMONTNKTORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDash> Get_Data_EbitMarjin(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDash>("EXEC SP_EBITMARGINBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
    }
    //public class ReportDashViewMarkupMarjin
    //{

    //    public IEnumerable<YearlyReportMarkupMarjin> mrequestResult { get; set; }
    //    public string EntryCountTotal { get; set; }

    //    public string EntryCountLast { get; set; }

    //    public string EntryCountBefore { get; set; }

    //    public static IEnumerable<YearlyReportMarkupMarjin> getMarkupMarjin(IEnumerable<YearlyReportDash> mResultBrutKarZarar, IEnumerable<YearlyReportDash> mResultRevenue)
    //    {
    //        List<YearlyReportMarkupMarjin> nlist = new List<YearlyReportMarkupMarjin>();
    //        YearlyReportMarkupMarjin ndash = new YearlyReportMarkupMarjin();
    //        YearlyReportDash nBrutKarZarar = new YearlyReportDash();
    //        YearlyReportDash nRevenue = new YearlyReportDash();
    //        for (int i = 1; i <= 12; i++)
    //        {
    //            ndash = new YearlyReportMarkupMarjin();
    //            nBrutKarZarar = mResultBrutKarZarar.Where(x => x.MainMonth == i).FirstOrDefault();
    //            nRevenue = mResultRevenue.Where(x => x.MainMonth == i).FirstOrDefault();
    //            ndash.DocumentMonth = nBrutKarZarar.DocumentMonth;
    //            ndash.DocumentMonthTr = nBrutKarZarar.DocumentMonthTr;
    //            ndash.MainMonth = nBrutKarZarar.MainMonth;
    //            ndash.MainYear = nBrutKarZarar.MainYear;
    //            ndash.TotalGelir = nRevenue.TotalGelir == 0 ? 0 : Convert.ToDecimal(nBrutKarZarar.TotalGelir) / Convert.ToDecimal(nRevenue.TotalGelir);
    //            ndash.TGelir = nRevenue.TGelir == 0 ? 0 : Convert.ToDecimal(nBrutKarZarar.TGelir) / Convert.ToDecimal(nRevenue.TGelir);
    //            ndash.TGider = nRevenue.TGider == 0 ? 0 : Convert.ToDecimal(nBrutKarZarar.TGider) / Convert.ToDecimal(nRevenue.TGider);
    //            ndash.TotalGelirTx = Math.Round(ndash.TotalGelir, 2);
    //            nlist.Add(ndash);
    //        }
    //        return nlist;


    //    }

    //}
    public class ReportDashViewWCap
    {

        public static DashRep getRealyVal(IEnumerable<YearlyReportDash> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.TotalGelir != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.TotalGelir != 0).Max(x => x.MainMonth);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountLast = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth == lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountBefore = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth != lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            return ndash;
        }
        public static List<DashDepth> getRealyValDashDepth(IEnumerable<YearlyReportDash> xSetter)
        {
            List<DashDepth> ndash = new List<DashDepth>();
            DashDepth ndash1 = new DashDepth();
            var nlist1 = xSetter.Where(x => x.TypeZone == 1);
            var nlist3 = xSetter.Where(x => x.TypeZone == 3);
            var nlist5 = xSetter.Where(x => x.TypeZone == 5);
            var nlist7 = xSetter.Where(x => x.TypeZone == 7);

            for (int i = 1; i < 13; i++)
            {
                ndash1 = new DashDepth();
                ndash1.MainMonth = i;
                ndash1.KisaVadeBanka = nlist1.Where(x => x.MainMonth == i).Select(x=>x.TotalGelir).FirstOrDefault();
                ndash1.UzunVadeBanka = nlist3.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.KisaVadeMali =  nlist5.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.UzunVadeMali =  nlist7.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.DocumentMonthTr = nlist1.Where(x => x.MainMonth == i).Select(x => x.DocumentMonthTr).FirstOrDefault();
                ndash.Add(ndash1);

            }

            return ndash;
        }
        public static List<DashDepth> getRealyValDashDepthMizan(IEnumerable<YearlyReportDash> xSetter)
        {
            List<DashDepth> ndash = new List<DashDepth>();
            DashDepth ndash1 = new DashDepth();
            var nlist1 = xSetter.Where(x => x.TypeZone == 1);
            var nlist3 = xSetter.Where(x => x.TypeZone == 3);
            var nlist5 = xSetter.Where(x => x.TypeZone == 5);
            var nlist7 = xSetter.Where(x => x.TypeZone == 7);

            List<int> nlist = xSetter.Select(x=>x.MainYear).Distinct().ToList();

            for (int i = 0; i < nlist.Count(); i++)
            {
                ndash1 = new DashDepth();
                ndash1.MainMonth = nlist[i];
                ndash1.KisaVadeBanka = nlist1.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.UzunVadeBanka = nlist3.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.KisaVadeMali = nlist5.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.UzunVadeMali = nlist7.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault(); 
                ndash.Add(ndash1);

            }

            return ndash;
        }
        public static DashRep getRealyValT(IEnumerable<DashYearlyResultMain> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.Value != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.Value != 0).Max(x => x.SortVal);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => x.SortVal == lastNum).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            if (lastNum > 1)
            {
                ndash.EntryCountLast = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => (lastNum != 1) && x.SortVal == lastNum - 1).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            }
            else
            {
                ndash.EntryCountLast = ndash.EntryCountTotal;
            }

            if (lastNum > 2)
            {
                ndash.EntryCountBefore = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => (lastNum != 2) && x.SortVal == lastNum - 2).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            }
            else
            {
                ndash.EntryCountBefore = ndash.EntryCountLast;
            }

            return ndash;
        }
        public static DashRep getRealyValGraphic(IEnumerable<YearlyReportDashGraphic> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.TotalGelir != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.TotalGelir != 0).Max(x => x.MainMonth);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountLast = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth == lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountBefore = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth != lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            return ndash;
        }

    }

    public class DashRep
    {
        
        public string EntryCountTotal { get; set; }
        public string EntryCountLast { get; set; }
        public string EntryCountBefore { get; set; }

    }
    public class DashDepth
    {
        public float KisaVadeBanka { get; set; }
        public float UzunVadeBanka { get; set; }
        public float KisaVadeMali { get; set; }
        public float UzunVadeMali { get; set; }
        public string DocumentMonthTr { get; set; }
        public int MainMonth { get; set; }
        public string MainMonthTx { get; set; }
        public string MainMonthTxa => MainMonth.ToString();
    }
    //public class ReportDashViewGross
    //{

    //    public IEnumerable<YearlyReportDash> mrequestResult { get; set; }
    //    public string EntryCountTotal => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountLast => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth == mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountBefore => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth != mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";



    //}

    //public class ReportDashViewRevenue
    //{

    //    public IEnumerable<YearlyReportDash> mrequestResult { get; set; }
    //    public string EntryCountTotal => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountLast => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth == mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountBefore => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth != mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";



    //}

    //public class ReportDashViewWorkingCap
    //{

    //    public IEnumerable<YearlyReportDash> mrequestResult { get; set; }
    //    public string EntryCountTotal => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountLast => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth == mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountBefore => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth != mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";



    //}

    //public class ReportDashViewEbit
    //{

    //    public IEnumerable<YearlyReportDash> mrequestResult { get; set; }
    //    public string EntryCountTotal => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountLast => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth == mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";

    //    public string EntryCountBefore => mrequestResult.Sum(x => x.TotalGelir) != 0 ? mrequestResult.Where(x => x.MainMonth != mrequestResult.Where(x => x.TGelir != 0).Max(x => x.MainMonth)).Sum(x => x.TotalGelir).ToString("N0") : "1";



    //}
    public class YearlyReportMarkupMarjin
    {
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public decimal TGelir { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public decimal TGider { get; set; }
        public decimal TotalGelir { get; set; }
        public decimal TotalGelirTx { get; set; }
    }
    public class YearlyReportDash
    {
        public YearlyReportDash() { }
        public YearlyReportDash(int mainMonth, long totalGelir,string documentMonthTr) { MainMonth = mainMonth; TotalGelir = totalGelir; DocumentMonthTr = documentMonthTr; }

        public string Description { get; set; }
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public long TGelir { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public long TGider { get; set; }
        public long TotalGelir { get; set; }
        public float Amount { get; set; }
        public int TypeZone { get; set; }
        public int  Year { get; set; }
        public string AmountTx =>Amount.ToString("n0");
        public string YearTx => Year.ToString();
    }

    public class YearlyReportDashMain
    {
        
        public DashRep dashRep { get; set; }
        public IEnumerable< YearlyReportDash> yearlyReportDash { get; set; }
        public int ChartTypeID { get; set; }
      
    }
    public class YearlyReportDashGraphic
    {
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public Decimal TotalGelir { get; set; }
    }
}
