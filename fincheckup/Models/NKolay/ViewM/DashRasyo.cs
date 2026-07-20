using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public static class DashRasyo
    {
        public static bool GetDashLikiditeRiskTrend(int _year, long _compID)
        {

            DashLikiditeRiskTrend.LikiditeRiskTrend21(_year, _compID);
            return true;
        }

        public static bool GetDashOzetMali(int _year, long _compID, int monthid_)
        {

            DashOzetMali.OzetMali8(_year, _compID);

            return true;
        }

        public static bool GetDashRasyoAnalizBeyanname(int _year, long _compID)
        {

            RasyoAnalizMain.RasyoAnalizBFinalMBeyanname(_year, _compID);

            RasyoAnalizMain.RasyoAnalizCFinalM(_year, _compID);
            RasyoAnalizMain.RasyoAnalizDFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizEFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizFFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizGFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizHFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizH1Final(_year, _compID);
            //RasyoAnalizMain.RasyoAnalizIFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalKarT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT1(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT2(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT3(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT5(_year, _compID);



            return true;
        }
        public static bool GetDashRasyoAnaliz(int _year, long _compID)
        {

            RasyoAnalizMain.RasyoAnalizBFinalM(_year, _compID);

            RasyoAnalizMain.RasyoAnalizCFinalM(_year, _compID);
            RasyoAnalizMain.RasyoAnalizDFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizEFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizFFinal(_year, _compID);

            RasyoAnalizMain.RasyoAnalizGFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizHFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizH1Final(_year, _compID);
            //RasyoAnalizMain.RasyoAnalizIFinal(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalKarT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT1(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT2(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT3(_year, _compID);
            RasyoAnalizMain.RasyoAnalizIFinalAktifKarT5(_year, _compID);



            return true;
        }
    }
    #region LikiditeRiskTrend 
    public class DashLikiditeRiskTrend : BaseModel
    {

        public static List<DashYearlyResult> LikiditeRiskTrend21(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResult>("EXEC TTZDashBoardOzetLikiditeSPM @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> LikiditeRiskTrend21Final(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResult>("Select *  FROM [TTZDashBoardOzetLikidite] where [CompanyID]=@companyID and [Year]=@nyear   ", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    #endregion


    #region Ozet Mali
    public class DashOzetMali : BaseModel
    {


        public static List<DashYearlyResult> OzetMali8(int _year, long _compID)
        {

            return StaticQuery<DashYearlyResult>("EXEC TTZDashBoardOzetMaliSPM @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> OzetMaliFinal(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResult>("Select * from  [TTZDashBoardOzetMali] where [CompanyID]=@companyID and [Year]=@nyear   ", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static void SetErrored(int _year, long _compID, int _monthID)
        {
            StaticQuery<int>("EXEC SPGRO_TBLDataErrored @companyID, @nyear, @nmonth", new { nyear = _year, companyID = _compID, nmonth = _monthID });
        }
    }
    #endregion

    #region Rasyo Analiz
    public class RasyoAnalizMain : BaseModel
    {
        public static List<SourceOneT> MizanAnalizStart(int _year, long _compID)
        {
            var sql = @"SELECT ID, AccountMainID, AccountSubID, AccountSubDescription, CompanyID,
                       Year, AmountBakiye, DebitCreditCode
                FROM TBLXMLSourceOneT WITH (NOLOCK)
                WHERE CompanyID = @companyID AND Year = @nyear   and AccountMainID in ('120', '133','333','136' ,'127' ,'131' ,'159' ,'231','181' ,'281','132','195','242' ,'220','236','259' ,'320','329','331','336','340','381','431' ,'481','339','440' ,'439','436','420' ,'429' ) ";

            return StaticQuery<SourceOneT>(sql, new { nyear = _year, companyID = _compID }).ToList();

        }
        public static List<DashYearlyResult> RasyoAnalizBFinalMBeyanname(int _year, long _compID)
        { //SP_RasyoFinansalBorclar
            StaticQuery<int>("EXEC [SPO_TBLMSampleBlncoRasTBeyanname] @companyID, @nyear", new { nyear = _year, companyID = _compID });

            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizBFinalM(int _year, long _compID)
        { //SP_RasyoFinansalBorclar
            StaticQuery<int>("EXEC SPO_TBLMSampleBlncoRasT @companyID, @nyear", new { nyear = _year, companyID = _compID });

            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }


        public static List<DashYearlyResult> RasyoAnalizCFinalM(int _year, long _compID)
        {//SP_RasyoFinansalKaldirac
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalKaldirac @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizDFinal(int _year, long _compID)
        {//SP_RasyoKisaVadeliBorclar
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoKisaVadeliBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }


        public static List<DashYearlyResult> RasyoAnalizEFinal(int _year, long _compID)
        {//SP_RasyoLikiditeOran
            return StaticQuery<DashYearlyResult>("EXEC  SP_RasyoLikiditeOran  @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizFFinal(int _year, long _compID)
        {//SP_RasyoDuranVarlkOzSermye
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoDuranVarlkOzSermye @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizGFinal(int _year, long _compID)
        {//SP_RasyoNakiOran
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoNakiOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizHFinal(int _year, long _compID)
        {//SP_RasyoIsltmeSermyeAktif
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoIsltmeSermyeAktif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizH1Final(int _year, long _compID)
        {//SP_RasyoCari
            return StaticQuery<DashYearlyResult>("EXEC SP_RasyoCari @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        // return StaticQuery<DashBilancoView>("EXEC MainZZCariOranTM @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //public static List<DashYearlyResult> RasyoAnalizIFinal(int _year, long _compID)
        //{//SP_RasyoSermOzSermyeOran
        //    return StaticQuery<DashYearlyResult>("EXEC SP_RasyoSermOzSermyeOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        //}
        public static List<DashYearlyResult> RasyoAnalizIFinalT(int _year, long _compID)
        {//SP_RasyoOzsermayeDevirHizi
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoOzsermayeDevirHizi] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalKarT(int _year, long _compID)
        {//SP_RasyoOzsermayeKarlilikT
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoOzsermayeKarlilikT] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalAktifKarT(int _year, long _compID)
        {//SP_RasyoAktifKarlilik
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoAktifKarlilik] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalAktifKarT1(int _year, long _compID)
        {//SP_RasyoEkonomikRantabilite
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoEkonomikRantabilite] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalAktifKarT2(int _year, long _compID)
        {//SP_RasyoAktifDevirHiz
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoAktifDevirHiz] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalAktifKarT3(int _year, long _compID)
        {//SP_RasyoFaizKarsilamaT
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoFaizKarsilamaT] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResult> RasyoAnalizIFinalAktifKarT5(int _year, long _compID)
        {//SP_RasyoLikiditeOran
            return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoLikiditeOran] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResult> RasyoAnalizTOTALFinal(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResult>("Select * from TTZDashBoardOran   where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL102(int _year, long _compID)
        {
            string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='102' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL102T(int _year, long _compID)
        {
            string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='102' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL103T(int _year, long _compID)
        {
            string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='103' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL120T(int _year, long _compID)
        {
            string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='120' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL320T(int _year, long _compID)
        {
            string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='320' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL103(int _year, long _compID)
        {
            string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='103' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL101(int _year, long _compID)
        {
            string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='101' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL101T(int _year, long _compID)
        {
            string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='101' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL120(int _year, long _compID)
        {
            string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='120' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }

      
        public static List<DashYearlyResultCRMMain> CRMAnalizTOTAL320(int _year, long _compID)
        {
            string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='320' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

            return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    public class DashYearlyResultChart
    {
        public DashYearlyResultChart()
        {
            nresult = new List<DashYearlyResultMain>();
        }
        public List<DashYearlyResultMain> nresult { get; set; }

        public void SetResult(List<DashYearlyResult> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultMain nv = new DashYearlyResultMain();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/01/15");
                nv.SortVal = 1;
                nv.Value = item.January;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/02/15");
                nv.SortVal = 2;
                nv.Value = item.February;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/03/15");
                nv.SortVal = 3;
                nv.Value = item.March;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/04/15");
                nv.SortVal = 4;
                nv.Value = item.April;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/05/15");
                nv.SortVal = 5;
                nv.Value = item.May;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/06/15");
                nv.SortVal = 6;
                nv.Value = item.June;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/07/15");
                nv.SortVal = 7;
                nv.Value = item.July;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/08/15");
                nv.SortVal = 8;
                nv.Value = item.August;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/09/15");
                nv.SortVal = 9;
                nv.Value = item.September;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/10/15");
                nv.SortVal = 10;
                nv.Value = item.October;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/11/15");
                nv.SortVal = 11;
                nv.Value = item.November;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/12/15");
                nv.SortVal = 12;
                nv.Value = item.December;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ocak"; Date = DateTime.Parse("2013/01/06")
                //nv.SortVal = 1;
                //nv.Value = item.January;

                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Şubat";
                //nv.SortVal = 2;
                //nv.Value = item.February;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Mart";
                //nv.SortVal = 3;
                //nv.Value = item.March;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Nisan";
                //nv.SortVal = 4;
                //nv.Value = item.April;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Mayıs";
                //nv.SortVal = 5;
                //nv.Value = item.May;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Haziran";
                //nv.SortVal = 6;
                //nv.Value = item.June;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Temmuz"; 
                // nv.SortVal = 7;
                //nv.Value = item.July;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ağustos";
                //nv.SortVal = 8;
                //nv.Value = item.August;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Eylül";
                //nv.SortVal = 9;
                //nv.Value = item.September;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ekim";
                //nv.SortVal = 10;
                //nv.Value = item.October;
                //nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Kasım";
                //nv.SortVal = 11;
                //nv.Value = item.November;
                //nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Aralık";
                //nv.SortVal = 12;
                //nv.Value = item.December;
                //nresult.Add(nv);
            }


        }
        public static List<DashYearlyResultMain> SetResultMain(DashYearlyResultWorkingCapital tdash, int nyearr)
        {
            if (tdash == null)
            {
                return new List<DashYearlyResultMain>();
            }

            DashYearlyResultMain nv = new DashYearlyResultMain();
            List<DashYearlyResultMain> nreesult1 = new List<DashYearlyResultMain>();

            string txyear = nyearr.ToString();

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/01/15");
            nv.SortVal = 1;
            nv.Value = tdash.January;
            nv.DocumentMonthTr = "Ocak";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/02/15");
            nv.SortVal = 2;
            nv.Value = tdash.February;
            nv.DocumentMonthTr = "Şubat";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/03/15");
            nv.SortVal = 3;
            nv.Value = tdash.March;
            nv.DocumentMonthTr = "Mart";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/04/15");
            nv.SortVal = 4;
            nv.Value = tdash.April;
            nv.DocumentMonthTr = "Nisan";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/05/15");
            nv.SortVal = 5;
            nv.Value = tdash.May;
            nv.DocumentMonthTr = "Mayıs";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/06/15");
            nv.SortVal = 6;
            nv.Value = tdash.June;
            nv.DocumentMonthTr = "Haziran";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/07/15");
            nv.SortVal = 7;
            nv.Value = tdash.July;
            nv.DocumentMonthTr = "Temmuz";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/08/15");
            nv.SortVal = 8;
            nv.Value = tdash.August;
            nv.DocumentMonthTr = "Ağustos";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/09/15");
            nv.SortVal = 9;
            nv.Value = tdash.September;
            nv.DocumentMonthTr = "Eylül";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/10/15");
            nv.SortVal = 10;
            nv.Value = tdash.October;
            nv.DocumentMonthTr = "Ekim";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/11/15");
            nv.SortVal = 11;
            nv.Value = tdash.November;
            nv.DocumentMonthTr = "Kasım";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/12/15");
            nv.SortVal = 12;
            nv.DocumentMonthTr = "Aralık";
            nv.Value = tdash.December;
            nreesult1.Add(nv);



            return nreesult1;
        }
    }

    public class DashYearlyResultChartCRM
    {
        public DashYearlyResultChartCRM()
        {
            nresult = new List<DashYearlyResultCRM>();
        }
        public List<DashYearlyResultCRM> nresult { get; set; }

        public void SetResult(List<DashYearlyResultCRMMain> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultCRM nv = new DashYearlyResultCRM();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 1;
                nv.ValueType = "Debit";
                nv.Value = item.Debit;
                nresult.Add(nv);

                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 2;
                nv.ValueType = "Credit";
                nv.Value = item.Credit;
                nresult.Add(nv);


            }


        }
        public void SetResultA(List<DashYearlyResultCRMMain> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultCRM nv = new DashYearlyResultCRM();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 1;
                nv.ValueType = "Debit";
                nv.Value = item.Debit;
                nresult.Add(nv);
                 


            }


        }
        public static List<DashYearlyResultMain> SetResultMain(DashYearlyResultWorkingCapital tdash, int nyearr)
        {
            if (tdash == null)
            {
                return new List<DashYearlyResultMain>();
            }

            DashYearlyResultMain nv = new DashYearlyResultMain();
            List<DashYearlyResultMain> nreesult1 = new List<DashYearlyResultMain>();

            string txyear = nyearr.ToString();

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/01/15");
            nv.SortVal = 1;
            nv.Value = tdash.January;
            nv.DocumentMonthTr = "Ocak";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/02/15");
            nv.SortVal = 2;
            nv.Value = tdash.February;
            nv.DocumentMonthTr = "Şubat";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/03/15");
            nv.SortVal = 3;
            nv.Value = tdash.March;
            nv.DocumentMonthTr = "Mart";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/04/15");
            nv.SortVal = 4;
            nv.Value = tdash.April;
            nv.DocumentMonthTr = "Nisan";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/05/15");
            nv.SortVal = 5;
            nv.Value = tdash.May;
            nv.DocumentMonthTr = "Mayıs";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/06/15");
            nv.SortVal = 6;
            nv.Value = tdash.June;
            nv.DocumentMonthTr = "Haziran";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/07/15");
            nv.SortVal = 7;
            nv.Value = tdash.July;
            nv.DocumentMonthTr = "Temmuz";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/08/15");
            nv.SortVal = 8;
            nv.Value = tdash.August;
            nv.DocumentMonthTr = "Ağustos";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/09/15");
            nv.SortVal = 9;
            nv.Value = tdash.September;
            nv.DocumentMonthTr = "Eylül";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/10/15");
            nv.SortVal = 10;
            nv.Value = tdash.October;
            nv.DocumentMonthTr = "Ekim";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/11/15");
            nv.SortVal = 11;
            nv.Value = tdash.November;
            nv.DocumentMonthTr = "Kasım";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/12/15");
            nv.SortVal = 12;
            nv.DocumentMonthTr = "Aralık";
            nv.Value = tdash.December;
            nreesult1.Add(nv);



            return nreesult1;
        }
    }
    public class DashYearlyRevenueChart
    {
        public DashYearlyRevenueChart()
        {
            nresult = new List<DashYearlyRevenueMain>();
        }
        public List<DashYearlyRevenueMain> nresult { get; set; }

        public void SetResult(List<DashBilancoView> tdash, int nyear)
        {
            DashYearlyRevenueMain nv = new DashYearlyRevenueMain();


            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/01/15");
                nv.SortVal = 1;
                nv.Value = item.January;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/02/15");
                nv.SortVal = 2;
                nv.Value = item.February;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/03/15");
                nv.SortVal = 3;
                nv.Value = item.March;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/04/15");
                nv.SortVal = 4;
                nv.Value = item.April;
                nv.GroupName = item.GroupName;
                nv.TypeID = item.TypeID;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/05/15");
                nv.SortVal = 5;
                nv.Value = item.May;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/06/15");
                nv.SortVal = 6;
                nv.Value = item.June;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/07/15");
                nv.SortVal = 7;
                nv.Value = item.July;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/08/15");
                nv.SortVal = 8;
                nv.Value = item.August;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/09/15");
                nv.SortVal = 9;
                nv.Value = item.September;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/10/15");
                nv.SortVal = 10;
                nv.Value = item.October;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/11/15");
                nv.SortVal = 11;
                nv.Value = item.November;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

                nv = new DashYearlyRevenueMain();
                nv.Description = item.AccountMainDescription;
                nv.Month = DateTime.Parse(txyear + "/12/15");
                nv.SortVal = 12;
                nv.Value = item.December;
                nv.TypeID = item.TypeID;
                nv.GroupName = item.GroupName;
                nv.CountrZone = item.CounterZone;
                nresult.Add(nv);

            }


        }

    }
    public class DashYearlyResultMain
    {
        public string DocumentMonthTr { get; set; }
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public decimal Value { get; set; }
        public int SortVal { get; set; }
        public int TypeID { get; set; }
    }
    public class DashYearlyResultCRM
    {
        public string Description { get; set; }
        public int Year { get; set; }
        public string ValueType { get; set; }
        public int SortVal { get; set; }
        public float Value { get; set; }
    }
    public class DashYearlyResultCRMMain
    {
        public string Description { get; set; }
        public int Year { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public float AmountBakiye { get; set; }
    }
    public class DashYearlyRevenueMain
    {
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public double Value { get; set; }
        public int SortVal { get; set; }
        public int TypeID { get; set; }
        public string GroupName { get; set; }
        public int CountrZone { get; set; }
    }

    public class DashYearlyResultWorkingCapital
    {
        public int Year { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public long CompanyID { get; set; }


        public static DashYearlyResultWorkingCapital setProp(int monthid, DashYearlyResultWorkingCapital nt)
        {

            if (nt == null)
            {
                return new DashYearlyResultWorkingCapital();
            }

            switch (monthid)
            {
                case 1: nt.February = 0; nt.March = 0; nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 2: nt.March = 0; nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 3: nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 4: nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 5: nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 6: nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 7: nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 8: nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 9: nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 10: nt.November = 0; nt.December = 0; return nt;
                case 11: nt.December = 0; return nt;
                default:
                    return nt;
            }


        }
    }
    public class DashYearlyResult
    {
        public string Description { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public int TypeID { get; set; }
    }
    public class DashYearlyResultTx
    {
        public string Description { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public int TypeID { get; set; }




        public static List<DashYearlyResultTx> setDashBilanco(List<DashYearlyResult> mdash)
        {
            List<DashYearlyResultTx> nlist = new List<DashYearlyResultTx>();

            nlist = mdash.Select(x => new DashYearlyResultTx()
            {

                Description = x.Description,
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
                TypeID = x.TypeID
            }).ToList();
            return nlist;

        }

    }

    #endregion
}
