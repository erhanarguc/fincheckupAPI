using DevExpress.DataProcessing.InMemoryDataProcessor;
using fincheckup.Models.ViewM;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashRasyoMizan : BaseModel
    {
        public static bool GetDashLikiditeRiskTrend(int _year, long _compID)
        {

            DashLikiditeRiskTrendMizan.LikiditeRiskTrend21(_year, _compID);
            return true;
        }
        public static int GetCheckMizanStatus(int _year, long _compID, int _month)
        {

            return DashOzetMaliMizan.GetCheckCountMizanMOnth(_year, _compID, _month);


        }
        public static bool GetDashOzetMali(int _year, long _compID)
        {

            DashOzetMaliMizan.OzetMali8(_year, _compID);
     
            
            return true;
        }
        public static bool GetDashOzetMali1(int _year, long _compID)
        {

            DashOzetMaliMizan.OzetMali81(_year, _compID);

            return true;
        }
        public static bool GetDashOzetMaliByn(int _year, long _compID)
        {

            DashOzetMaliMizan.OzetMali8Byn(_year, _compID);


            return true;
        }

        public static bool GetDashRasyoAnaliz(int _year, long _compID)
        {

            RasyoAnalizMainMizan.RasyoAnalizBFinalM(_year, _compID);

            RasyoAnalizMainMizan.RasyoAnalizCFinalM(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizDFinal(_year, _compID);

            RasyoAnalizMainMizan.RasyoAnalizEFinal(_year, _compID);

            RasyoAnalizMainMizan.RasyoAnalizFFinal(_year, _compID);

            RasyoAnalizMainMizan.RasyoAnalizGFinal(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizHFinal(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizH1Final(_year, _compID);
            //RasyoAnalizMaMizanin.RasyoAnalizIFinal(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalT(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalKarT(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalAktifKarT(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalAktifKarT1(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalAktifKarT2(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalAktifKarT3(_year, _compID);
            RasyoAnalizMainMizan.RasyoAnalizIFinalAktifKarT5(_year, _compID);



            return true;
        }
    }
    #region LikiditeRiskTrend 
    public class DashLikiditeRiskTrendMizan : BaseModel
    {

        public static List<DashYearlyResultMizan> LikiditeRiskTrend21(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResultMizan>("EXEC TTZDashBoardOzetLikiditeSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> LikiditeRiskTrend21Final(long _compID)
        {
            return StaticQuery<DashYearlyResultMizan>("Select *  FROM [TTZDashBoardOzetLikiditeMzn] where [CompanyID]=@companyID  ", new { companyID = _compID }).ToList();
        }
    }
    #endregion

    public class DashYearlyResultMizan
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int TypeID { get; set; }
        public int Year { get; set; }
        public string Yeartx => Year.ToString();
    }
    #region Ozet Mali
    public class DashOzetMaliMizan : BaseModel
    {
        public static int OzetMali81(int _year, long _compID)
        {
           
            string sqll = @"EXEC [dbo].[SPO_BYNLAST] @companyID,@nyear";
            StaticQuery<DashBilancoViewQnb>(sqll, new { nyear = _year, companyID = _compID }).FirstOrDefault();
            



            return 0;
        }
        public static int GetCheckCountMizanMOnth(int _year, long _compID, int _month)
        {

            return StaticQuery<int>("SELECT COUNT([ID])  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [MainMonth]=@nmon and [Year]=@nyear and [CompanyID]=@companyID and IsBeyan=0 ", new { nyear = _year, companyID = _compID, nmon = _month }).FirstOrDefault();
        }
        public static int setJournnal(int _year, long _compID)
        {

            StaticQuery<int>("EXEC [SPP_SMMMZNBLNCAKTJRNLA] @companyID,@nyear", new { companyID = _compID, nyear = _year, }).FirstOrDefault();

            return 0;
        }
        public static int ClearFibaPr(long _compID)
        {
            StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrtCustomPr] where  CompanyID=@companyID", new { companyID = _compID }).FirstOrDefault();

            return 0;
        }

        public static long getPasifMizan(int _year, long _compID)
        {
            string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)";
            return StaticQuery<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static long getOzkaynak(int _year, long _compID)
        {
            string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (3333)";
            return StaticQuery<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public static List<DashYearlyResultMizan> OzetMali8(int _year, long _compID)
        {
            StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrt] where  CompanyID=@companyID", new { companyID = _compID }).FirstOrDefault();
            StaticQuery<int>("EXEC SPO_MIZANACT @companyID,@nyear", new { companyID = _compID, nyear = _year }).FirstOrDefault();
            //string sqle = @"EXEC SPO_MIZANACT @companyID,@nyear";
            //StaticQuery<int>(sqle, new { companyID = _compID,  nyear = _year},commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            //float totalKArzarare = DashOzetMaliMizan.getKArzarar(_year, _compID);
            //long totalP590 = DashOzetMaliMizan.Get_P590(_year, _compID);
            //if (totalP590 == 0 && totalKArzarare > 0)
            //{

            //    //   string sqle1 = @"UPDATE  [dbo].[TBLMSampleBlncoMzn] set [Amount]=@bakiye+[Amount]      where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='2223'";
            //    //StaticQuery<int>(sqle1, new { nyear = _year, companyID = _compID, bakiye = totalKArzarare }); 
            //}
            //else
            //{
            //    //string sql = @"UPDATE [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] set Amount=(select SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)) where CompanyID=@companyID and Year=@nyear and TypeID in (2223)";StaticQuery<int>("UPDATE   TBLMSampleBlncoMzn set AmountBakiye=AmountBakiye*-1 where  CompanyID=@companyID and [Year]=@nyear and AccountMainID in('590')", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //    //StaticQuery<int>(sql, new { nyear = _year, companyID = _compID });
            //}

            //

            return StaticQuery<DashYearlyResultMizan>("EXEC TTZDashBoardOzetMaliSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> OzetMali8Byn(int _year, long _compID)
        {
            StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrt] where  CompanyID=@companyID", new { companyID = _compID }).FirstOrDefault();
            //StaticQuery<int>("EXEC SPO_MIZANACT @companyID,@nyear", new { companyID = _compID, nyear = _year }).FirstOrDefault();
            //string sqle = @"EXEC SPO_MIZANACT @companyID,@nyear";
            //StaticQuery<int>(sqle, new { companyID = _compID,  nyear = _year},commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            //float totalKArzarare = DashOzetMaliMizan.getKArzarar(_year, _compID);
            //long totalP590 = DashOzetMaliMizan.Get_P590(_year, _compID);
            //if (totalP590 == 0 && totalKArzarare > 0)
            //{

            //    //   string sqle1 = @"UPDATE  [dbo].[TBLMSampleBlncoMzn] set [Amount]=@bakiye+[Amount]      where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='2223'";
            //    //StaticQuery<int>(sqle1, new { nyear = _year, companyID = _compID, bakiye = totalKArzarare }); 
            //}
            //else
            //{
            //    //string sql = @"UPDATE [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] set Amount=(select SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)) where CompanyID=@companyID and Year=@nyear and TypeID in (2223)";StaticQuery<int>("UPDATE   TBLMSampleBlncoMzn set AmountBakiye=AmountBakiye*-1 where  CompanyID=@companyID and [Year]=@nyear and AccountMainID in('590')", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //    //StaticQuery<int>(sql, new { nyear = _year, companyID = _compID });
            //}

            //

            return StaticQuery<DashYearlyResultMizan>("EXEC TTZDashBoardOzetMaliSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        //public static void OzetMali9byn(int _year, long _compID)
        //{
        //    string sqll = @"  declare @@chk591 int = (  SELECT  ISNULL(ABS(SUM(Amount)),0) FROM TBLXMLSourceOne WITH (NOLOCK) where  [CompanyID]=@companyID and [Year]=@nyear      and AccountMainID in ('591'));
        //        declare @@chk692 int = (  SELECT  ISNULL(ABS(SUM(Amount)),0) FROM TBLXMLSourceOne WITH (NOLOCK) where  [CompanyID]=@companyID and [Year]=@nyear             and        AccountMainID in ('692'));

        //      if	@@chk591=0 or ABS(@@chk692-@@chk591)>5	
        //      BEGIN
        //      UPDATE   TBLMSampleBlncoMzn set Amount=Amount*-1 where  CompanyID=@companyID and [Year]=@nyear and TypeID in ('59')

        //      END";


        //    StaticQuery<int>(sqll, new { nyear = _year, companyID = _compID }).FirstOrDefault();



        //}
        //public static void OzetMali10byn(int _year, long _compID)
        //{

        //    string sqll = @"  declare @@chk591 int = (  SELECT  ISNULL(ABS(SUM(Amount)),0) FROM TBLXMLSourceOne WITH (NOLOCK) where  [CompanyID]=@companyID and [Year]=@nyear      and AccountMainID in ('591'));
        //        declare @@chk692 int = (  SELECT  ISNULL(ABS(SUM(Amount)),0) FROM TBLXMLSourceOne WITH (NOLOCK) where  [CompanyID]=@companyID and [Year]=@nyear             and        AccountMainID in ('692'));

        //      if	@@chk591=0 or ABS(@@chk692-@@chk591)>5	
        //      BEGIN
        //    UPDATE   TBLMRevenueMzn set Amount=Amount*-1 where  CompanyID=@companyID and [Year]=@nyear and TypeID in ('9991','9995')

        //      END";


        //    StaticQuery<int>(sqll, new { nyear = _year, companyID = _compID }).FirstOrDefault();



        //}
        //public static void OzetMali9(int _year, long _compID)
        //{



        //    StaticQuery<int>("UPDATE   TBLMSampleBlncoMzn set Amount=Amount*-1 where  CompanyID=@companyID and [Year]=@nyear and TypeID in ('59')", new { nyear = _year, companyID = _compID }).FirstOrDefault();



        //}
        //public static void OzetMali10(int _year, long _compID)
        //{
        //    StaticQuery<int>("UPDATE   TBLMRevenueMzn set Amount=Amount*-1 where  CompanyID=@companyID and [Year]=@nyear and TypeID in ('9991','9995')", new { nyear = _year, companyID = _compID }).FirstOrDefault();



        //}

        public static List<DashYearlyResultMizan> OzetMaliFinal(long _compID)
        {
            return StaticQuery<DashYearlyResultMizan>("Select * from  [TTZDashBoardOzetMaliMzn] where [CompanyID]=@companyID    ", new { companyID = _compID }).ToList();
        }

        public static void SetErrored(int _year, long _compID, int _monthID)
        {
            StaticQuery<int>("EXEC SPGRO_TBLDataErrored @companyID, @nyear, @nmonth", new { nyear = _year, companyID = _compID, nmonth = _monthID });
        }

        internal static long getKArzarar(int _year, long _compID)
        {
            string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMRevenueMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (9995)";
            return StaticQuery<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }

        internal static long Get_P590(int _year, long _compID)
        {
            return StaticQuery<long>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='590'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }

    }
    #endregion

    #region Rasyo Analiz
    public class RasyoAnalizMainMizan : BaseModel
    {


        public static List<DashYearlyResultMizan> RasyoAnalizBFinalM(int _year, long _compID)
        { //SP_RasyoFinansalBorclar


            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoFinansalBorclarMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }


        public static List<DashYearlyResultMizan> RasyoAnalizCFinalM(int _year, long _compID)
        {//SP_RasyoFinansalKaldirac
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoFinansalKaldiracMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResultMizan> RasyoAnalizDFinal(int _year, long _compID)
        {//SP_RasyoKisaVadeliBorclar
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoKisaVadeliBorclarMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }


        public static List<DashYearlyResultMizan> RasyoAnalizEFinal(int _year, long _compID)
        {//SP_RasyoLikiditeOran
            return StaticQuery<DashYearlyResultMizan>("EXEC  SP_RasyoLikiditeOranMZN  @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResultMizan> RasyoAnalizFFinal(int _year, long _compID)
        {//SP_RasyoDuranVarlkOzSermye
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoDuranVarlkOzSermyeMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResultMizan> RasyoAnalizGFinal(int _year, long _compID)
        {//SP_RasyoNakiOran
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoNakiOranMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResultMizan> RasyoAnalizHFinal(int _year, long _compID)
        {//SP_RasyoIsltmeSermyeAktif
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoIsltmeSermyeAktifMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizH1Final(int _year, long _compID)
        {//SP_RasyoCari
            return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoCariMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        // return StaticQuery<DashBilancoView>("EXEC MainZZCariOranTM @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //public static List<DashYearlyResultMizan> RasyoAnalizIFinal(int _year, long _compID)
        //{//SP_RasyoSermOzSermyeOran
        //    return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoSermOzSermyeOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        //}
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalT(int _year, long _compID)
        {//SP_RasyoOzsermayeDevirHizi
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoOzsermayeDevirHiziMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalKarT(int _year, long _compID)
        {//SP_RasyoOzsermayeKarlilikT
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoOzsermayeKarlilikTMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT(int _year, long _compID)
        {//SP_RasyoAktifKarlilik
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoAktifKarlilikMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT1(int _year, long _compID)
        {//SP_RasyoEkonomikRantabilite
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoEkonomikRantabiliteMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT2(int _year, long _compID)
        {//SP_RasyoAktifDevirHiz
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoAktifDevirHizMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT3(int _year, long _compID)
        {//SP_RasyoFaizKarsilamaT
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoFaizKarsilamaTMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT5(int _year, long _compID)
        {//SP_RasyoLikiditeOran
            return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoLikiditeOranMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashYearlyResultMizan> RasyoAnalizTOTALFinal(int _year, long _compID)
        {
            return StaticQuery<DashYearlyResultMizan>("Select * from TTZDashBoardOranMzn   where CompanyID=@companyID  ", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
    #endregion
}