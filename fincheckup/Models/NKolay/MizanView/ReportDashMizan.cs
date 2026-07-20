using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class ReportDashMizan : BaseModel
    {
        public static IEnumerable<YearlyReportDashMizan> Get_Data_GrossProfit(long _compID)
        {
            IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("SELECT TOP (1000) CAST([Amount] as bigint) as 'Amount',[CompanyID] ,[Year] FROM [EDEFTERDB].[dbo].[TBLWcapBrutKarZararMizan]  where CompanyID=@companyID", new { companyID = _compID });
            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizan>();
            }
            return nval;
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_Revenue(long _compID)
        {
            IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("Select * from  TBLWcapNetSatisMizan where CompanyID=@companyID  ", new { companyID = _compID });
            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizan>();
            }
            return nval;
        }
        public static IEnumerable<YearlyReportDashMizanGrap> Get_Data_GrossProfitGraphic(long _compID)
        {
            IEnumerable<YearlyReportDashMizanGrap> nval = StaticQuery<YearlyReportDashMizanGrap>("EXEC SP_BRUTKARZBYMONTHV1Mizan  @companyID", new { companyID = _compID });
            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizanGrap>();
            }
            return nval;
        }

        public static IEnumerable<YearlyReportDashMizan> Get_Data_DonemselKarzarar(long _compID)
        {
            IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("Select * from   TBLWcapDonemKarZararMizan where CompanyID=@companyID  ", new { companyID = _compID });

            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizan>();
            }
            return nval;
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_WorkingCapital(long _compID)
        {
            IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTHV21Mizan @companyID ", new { companyID = _compID });



            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizan>();
            }
            return nval;
        }
        public static int Get_LastMonthYear(int _year, long _compID)
        {
            return StaticQuery<int>("Select TOP 1  MONTH(DocumentDate) from TBLXml where CompanyID=@companyID and Year=@nyear order by DocumentDate Desc", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_BLNC(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTBLNC @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_CRORN(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTCRORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_NKTORN(int _year, long _compID)
        {
            return StaticQuery<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTNKTORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyReportDashMizan> Get_Data_EbitMarjin(long _compID)
        {
            IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("Select * from  TBLWcapEsasMaliyetKarZararMizan where CompanyID=@companyID  ", new { companyID = _compID });


            if (nval == null || nval.Count() < 1)
            {
                nval = new List<YearlyReportDashMizan>();
            }
            return nval;
        }
    }
    public class YearlyReportDashMizan
    {

        public string Yeartx => Year.ToString();

        public int Year { get; set; }
        public long CompanyID { get; set; }
        public long Amount { get; set; }
        public YearlyReportDashMizan()
        {
        }
        public YearlyReportDashMizan(int year, long companyID, long amount)
        {
            Year = year;
            CompanyID = companyID;
            Amount = amount;
        }
    }

    public class YearlyReportDashMizanMain
    { 
        public IEnumerable<YearlyReportDashMizan> yearlyReportDashMizan { get; set; }
        public int ChartTypeID { get; set; }

        public YearlyReportDashMizanMain(IEnumerable<YearlyReportDashMizan> yearlyReportDashMizan, int chartTypeID)
        {
            this.yearlyReportDashMizan = yearlyReportDashMizan;
            ChartTypeID = chartTypeID;
        }
    }
    public class YearlyReportDashMizanGrap
    {
        public string Yeartx => Year.ToString();

        public int Year { get; set; }
        public long CompanyID { get; set; }
        public float Amount { get; set; }

    }
}
