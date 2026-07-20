using DevExpress.CodeParser;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay.ViewM;
using fincheckup.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class DashGelirTablosu : BaseModel
    {
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznSmm(int _year, long _compID)
        {
            string sql = @"EXEC SPP_SMMMZNBLNC @companyID,@nyear";

            return StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }



        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznSmm(int _year, long _compID)
        {
            string sql = @"EXEC SPP_SMMMZNRVN @companyID,@nyear";

            return StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznAkt(int _year, long _compID)
        {
            string sql = @"EXEC SPP_SMMMZNRVNAKT @companyID,@nyear";

            return StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAkt(int _year, long _compID)
        {
            string sql = @"EXEC [SPP_SMMMZNBLNCAKT] @companyID,@nyear";

            return StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMulti(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNBLNCAKT @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;

        }
       
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAktCompare(long _compID, long _yearD, long _monID)
        {
   
 
                string sql = @"EXEC SPP_SMMMZZCOMPR @companyID,@nyear,@mmonth";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { companyID = _compID, nyear = _yearD, mmonth = _monID }).ToList(); 
          

            return tlist;

        }
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiKon(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoRasTKon] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNBLNCAKTKON @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;

        }
        //SPP_SMMMZNRVNAKTJRNL
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiJRNL(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNBLNCAKT @companyID,@nyear";
                //string sql = @"EXEC SPP_SMMMZNBLNCAKTJRNL @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;

        }
        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiJRNL(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNRVNAKTJRNL @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;
        }
        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiKon(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueRasTKon] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNRVNAKTKon @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;
        }
        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMulti(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1000000;
            string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNRVNAKT @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;
        }
       
        public static List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiSmm(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1;
            string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNRVN @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;
        }
        public static List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiSmm(long _compID)
        {
            List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
            long _compIDz = _compID * -1;
            string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
            List<int> nlistint = StaticQuery<int>(sql1, new { companyID = _compIDz }).ToList();

            foreach (var item in nlistint)
            {
                string sql = @"EXEC SPP_SMMMZNBLNC @companyID,@nyear";

                List<DashBilancoViewMznShort> tlist = StaticQuery<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
                nlist.AddRange(tlist);
            }

            return nlist;

        }
        public static List<DashBilancoView> Get_MAINRESULT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("Select * from  TBLMSampleBlnco WITH (NOLOCK) Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMulti> Get_MAINRESULTMulti(int[] _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMulti>("Select * from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID and [Year] in @nyear ", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<CashflowView> Get_MAINRESULTMultiCashFlow(long _compID)
        {
            return StaticQuery<CashflowView>("Select * from [dbo].[TBLMNKTAKIS] where CompanyID=@companyID  order by TypeID asc", new { companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMulti> Get_MAINRESULTMultiMain(long _compID)
        {
            string sqll = @"Select  [AccountMainID]
      ,[AccountMainDescription]
      ,[DebitCreditCode]
        , CASE WHEN(([AccountMainID] > '299' and [AccountMainID] < '550') and [AccountMainID] not in ('300','400','303','309'))  or (TypeID in (333, 444) and Amount<0) THEN Amount*-1 ELSE Amount END as 'Amount'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden]
      ,[ID]
      ,[CreatedDate]from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID ";


            return StaticQuery<DashBilancoViewMulti>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOT(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount' 
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt WITH (NOLOCK) Where CompanyID=@companyID ";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static int Get_MAINRESULTMultiMainPIVOTCheckFiba(long _compID)
        {
            string sqll = @"IF(NOT EXISTS(SELECT* FROM TBLMSampleBlncoShrtCustom WHERE CompanyID = @compID) )
        BEGIN
            EXEC SP_CUSTSPCE @compID; 
        END";


            return StaticQuery<int>(sqll, new { compID = _compID }).FirstOrDefault();
        }
        public static  int  Get_MAINRESULTMultiMainPIVOTCheck(long _compID)
        {
            string sqll = @"IF(NOT EXISTS(SELECT* FROM TBLMSampleBlncoShrt WHERE CompanyID = @compID) )
        BEGIN
            EXEC [SP_Main_CompanyViewBilancoShrtMIZAN] @compID;
        EXEC SP_Main_Grow_ViewBiloncoScoreListMIZAN @compID;
        END";


            return StaticQuery<int>(sqll, new { compID = _compID }).FirstOrDefault();
        }
        public static List<DashShortView> Get_MAINRESULTMultiMainPIVOTANeo(long _compID)
        {
            string sqll = @"EXEC ShortBilancoView @companyID ";


            return StaticQuery<DashShortView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTA(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 99 and 299) or TypeID in (111,222,2121)) and CompanyID=@companyID ";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTB(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST([Amount] AS DECIMAL(25, 2)) END  as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]   ,CASE WHEN [Amount]<-1 and TypeID<>4141 THEN  CAST(ABS([Diff]) AS DECIMAL(25, 2))*-1 ELSE  CAST(ABS([Diff]) AS DECIMAL(25, 2))  END as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 299 and 599) or TypeID in (333,444,4141,3333)) and CompanyID=@companyID ";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMIFIBA(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] ,YearTx from  TBLMSampleBlncoShrtCustom where  CounterZone <63    and CompanyID=@companyID order by CounterZone";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMIFIBA(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST([Amount] AS DECIMAL(25, 2)) END  as 'Amount'
      ,[Diff]   as 'DiffZone'
      ,[DiffVal]  as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden],YearTx from  TBLMSampleBlncoShrtCustom where  CounterZone >62     and CompanyID=@companyID order by CounterZone";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMI(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST(ABS([Amount]) AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 99 and 299) or TypeID in (111,222,2221)) and CompanyID=@companyID ";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMI(long _compID)
        {
            string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST(ABS([Amount]) AS DECIMAL(25, 2)) END  as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]   ,CASE WHEN [Amount]<-1 and TypeID<>4141 THEN  CAST(ABS([Diff]) AS DECIMAL(25, 2))*-1 ELSE  CAST(ABS([Diff]) AS DECIMAL(25, 2))  END as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 299 and 599) or TypeID in (333,444,2223,3333)) and CompanyID=@companyID ";


            return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMulti> Get_MAINRESULTMultiRVNMain(long _compID)
        {
            return StaticQuery<DashBilancoViewMulti>("Select * from  TBLMRevenueMzn WITH (NOLOCK) Where CompanyID=@companyID   ", new { companyID = _compID }).ToList();
        }
        public static List<DashBilancoViewMulti> Get_MAINRESULTMultiRVN(int[] _year, long _compID)
        {
            return StaticQuery<DashBilancoViewMulti>("Select * from  TBLMRevenueMzn WITH (NOLOCK) Where CompanyID=@companyID and [Year] in @nyear ", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MAINTAXCheck(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("Select * from   [dbo].[TBLZoneCheck] WITH (NOLOCK) Where CompanyID=@companyID and [Year]=@nyear and AccountMainID='100'", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TicBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_DigerBorcT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_AlinanAvansT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_InsaatOnarimHakedisT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_VergiYukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_BorcKarslkT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_KTahakkukT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_YabKaynakT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TOPLAMT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_TOPLAMTU(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,4", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DashBilancoView> Get_MaliBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TicBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_DigerBorcUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_AlinanAvansUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_BorcKarslkUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_TahakkukUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<DashBilancoView> Get_YabKaynakUT(int _year, long _compID)
        {
            return StaticQuery<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
        }



        //public static List<DashBilancoView> Get_FinansmanGiderT(int _year, long _compID)
        //{//   ""SPO_WcapFinansmanGiderTpl
        //    return StaticQuery<DashBilancoView>("EXEC SPO_WcapFinansmanGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--- +++('660','661')+++ TestMainOKynkFinansmanGider(TBLWcapFinansmanGider)
        //}







    }


    public class DashGelirTablosuViewMain
    {
        public static List<DashBilancoView> getList(int _year, long _compID)
        {
            DashGelirTablosuViewT nCheck = new DashGelirTablosuViewT();
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);


            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);

            //nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_FinansmanGiderT(_year, _compID), "I-Finasnman Giderleri", 777, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
            nCheck.SetBilanco(DashGelirTablosuSet.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);

            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraT(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
            nCheck.SetBilancoHeaderT(DashGelirTablosuSet.Get_DonemKarZaraTNet(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

            return nCheck.mrequestEntry;
        }




    }
    public class DashGelirTablosuViewT
    {
        public DashGelirTablosuViewT()
        {
            mrequestEntry = new List<DashBilancoView>();
            counter = 0;
        }
        public List<DashBilancoView> mrequestEntry { get; set; }
        public int counter { get; set; }

        public void SetBilanco(List<DashBilancoView> mrequestEntryCount, string tname, int ishidden)
        {
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                counter++;
                nDash = new DashBilancoView();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
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
                nDash.TypeID = 0;
                nDash.CounterZone = counter;
                nDash.IsHidden = ishidden;
                mrequestEntry.Add(nDash);
            }

        }

        public void SetBilancoHeaderT(List<DashBilancoView> mrequestEntryCount, string tname, int typeid_, int ishidden)
        {
            counter++;
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                nDash = new DashBilancoView();
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
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
                nDash.IsHidden = ishidden;
                nDash.CounterZone = counter;

                mrequestEntry.Add(nDash);
            }
        }

    }

    public class DashGelirTablosuView
    {
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public decimal Acilis { get; set; }
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
        public int Year { get; set; }
        public string GroupName { get; set; }
    } 
    public class DashPivotView
    {
        public string AccountMainID { get; set; }

        public string AccountMainDescription { get; set; } 
        public decimal Amount { get; set; }
        public decimal Diff { get; set; }
        public string DiffTx => "% "+ this.Diff.ToString("0.00");
        public string DiffZone { get; set; } 
        public decimal DiffVal { get; set; } 
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public byte IsHidden { get; set; }
        public string YearTx { get; set; }
    }
    public class DashShortView
    {
        public int AccountMainID { get; set; }

        public string AccountMainDescription { get; set; }
        public decimal Amount { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int TypeID { get; set; }
    }
}
