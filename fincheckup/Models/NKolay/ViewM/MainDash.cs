using fincheckup.Models.NKolay.MizanView;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace fincheckup.Models.ViewM
{
    public class MainDash : BaseModel
    {
        public static IEnumerable<YearlyErrorResult> Get_Data(int _year, long _compID)
        {
            return StaticQuery<YearlyErrorResult>("Select * from [TBLDBMONCOM] where CompanyID=@companyID and MainYear= @nyear", new { nyear = _year, companyID = _compID });
        }
        public static IEnumerable<YearlyErrorResult> Get_DatabyError(int _year, long _compID)
        {
            return StaticQuery<YearlyErrorResult>("Select * from [TBLDBMONCOM] where CompanyID=@companyID and MainYear= @nyear", new { nyear = _year, companyID = _compID });
        }
        public static List<int> Get_DatabyMOnthMizan(int _year, long _compID)
        {
            return StaticQuery<int>("Select DISTINCT(MainMonth) from [TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]= @nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
        public static IEnumerable<YearlyErrorResult> Get_DatabyErrorV1(int _year, long _compID, int _monID)
        {
            return StaticQuery<YearlyErrorResult>("EXEC [SP_ROWERRORBYMONTHV1] @nyear,@companyID,@monId", new { nyear = _year, companyID = _compID, monId = _monID });
        }
        public static DataViewerErroredCountCsv Get_DatabyErrorbyCsv(long _Csvid)
        {
            return StaticQuery<DataViewerErroredCountCsv>("EXEC [SP_ROWONLLYERRORBYCsv] @Csvid", new { Csvid = _Csvid }).FirstOrDefault();
        }
        public static int GetTblxml(int _year, long _compID, int _monID)
        {
            string sql = @" Select TOP 1 ID from TBLXML  where  CompanyID=@companyID and [Year]=@nyear and MONTH(DocumentDate)=@monid  ";

            return StaticQuery<int>(sql, new { nyear = _year, companyID = _compID, monid = _monID }).FirstOrDefault();
        }
        public static int GetMainReport(int _year, long _compID, int _monID)
        {
            string sql = @" Select TOP 1 ID from TBLXML  where  CompanyID=@companyID and [Year]=@nyear and MONTH(DocumentDate)=@monid  ";

            return StaticQuery<int>(sql, new { nyear = _year, companyID = _compID, monid = _monID }).FirstOrDefault();
        }
        public static List<YearlyErrorResult> DataViewerTaxError(int _year, long _compID)
        {
            string sql = @"EXEC [SP_ROWERRORTAXBYMONTH] @nyear,@companyID";

            return StaticQuery<YearlyErrorResult>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        //SELECT COUNT(*),MONTH(t.DocumentDate) as MainMonth FROM [dbo].[TBLErrzoneInsideXML] tb WITH(NOLOCK) LEFT JOIN TblXml t   on tb.CsvID=t.ID where  t.CompanyID= 8 and t.Year = 2021  group by t.DocumentDate
        //
        public static List<DataViewer> DataViewerMain(int _year, long _compID)
        {
            string sql = @" Select * from [TBLDataErrored]  where CompanyID=@companyID and [Year]=@nyear  ";

            return StaticQuery<DataViewer>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<DataViewer> DataViewerMainMonth(int _year, long _compID, int _nmonth)
        {
            string sql = @" Select * from [TBLDataErrored]  where CompanyID=@companyID and [Year]=@nyear and MONTH(EndDate)=@nmonth ";

            return StaticQuery<DataViewer>(sql, new { nyear = _year, companyID = _compID, nmonth = _nmonth }).ToList();
        }
        public static List<TBLErrColor> DataTBLErrColor()
        {
            string sql = @" Select * from [TBLErrColor] ";

            return StaticQuery<TBLErrColor>(sql).ToList();
        }
        public static DataViewerError DataViewerCheckOne(string mainDescription_)
        {
            string sql = @" Select TOP 1 * from [TBLErrzone]  where TRIM(MainDescription)=TRIM(@mainDescription)";

            return StaticQuery<DataViewerError>(sql, new { mainDescription = mainDescription_ }).FirstOrDefault();
        }


        public static int DataErrorSetter(DataViewerError _dataGroup)
        {
            try
            {
                string sql1 = string.Empty;


                if (_dataGroup.ID == "0" || _dataGroup.ID == "null" || string.IsNullOrEmpty(_dataGroup.ID))
                {
                    sql1 = @"INSERT INTO TBLErrzone([MainDescription]
      ,[ColorDesc]
      ,[Description]
      ,[ColorDescTax]
      ,[DescriptionTax]
      ,[ColorDescInside]
      ,[DescriptionInside])
      VALUES(@mainDescription,@colorDesc,@description,@colorDescTax,@descriptionTax,@colorDescInside,@descriptionInside) ";
                    StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, colorDesc = _dataGroup.ColorDesc, description = _dataGroup.Description, colorDescTax = _dataGroup.ColorDescTax, descriptionTax = _dataGroup.DescriptionTax, colorDescInside = _dataGroup.ColorDescInside, descriptionInside = _dataGroup.DescriptionInside }).FirstOrDefault();
                }
                else
                {
                    sql1 = @"UPDATE TBLErrzone  SET [MainDescription]=@mainDescription 
      ,[ColorDesc]=@colorDesc 
      ,[Description]= @description
      ,[ColorDescTax]=@colorDescTax
      ,[DescriptionTax]=@descriptionTax
      ,[ColorDescInside]=@colorDescInside
      ,[DescriptionInside] =@descriptionInside
      WHERE ID=@ide";

                    StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, colorDesc = _dataGroup.ColorDesc, description = _dataGroup.Description, colorDescTax = _dataGroup.ColorDescTax, descriptionTax = _dataGroup.DescriptionTax, colorDescInside = _dataGroup.ColorDescInside, descriptionInside = _dataGroup.DescriptionInside, ide = _dataGroup.ID }).FirstOrDefault();
                }

            }
            catch (System.Exception ex)
            {
                var chk = ex;
            }

            return 1;
        }
        public static int DataCheckSetter(DataViewerCheck _dataGroup)
        {
            try
            {
                string sql1 = @"INSERT INTO  [dbo].[TBLWzone] (MainDescriptionID,[MainDescription] )
      VALUES(@mainDescriptionInfo,@mainDescription) ";
                StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, mainDescriptionInfo = _dataGroup.DescriptionInfo }).FirstOrDefault();
            }
            catch (System.Exception ex)
            {

                var chk = ex;
            }

            return 1;
        }
        public static List<DataViewer> DataViewerMainSourceT(int _year, long _compID, int monthid_,long DocumentID)
        {



            //string sql3 = @" Select tb.*,tt.Description ,tt.ColorDesc ,tt.ColorDescTax,tt.DescriptionTax ,tt.ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
            //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
            //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
            //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear) ";

            //string sql = @" Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
            //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
            //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
            //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and tt.ColorDesc>0 and xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid) ";
            string sqll = @"EXEC [SP_CAccountErrorr] @nyear,@companyID,@monthid,@companyDocumentId";
            //            string sql = @"  Select EntryNumber,DocumentDate,EnteredBy,AccountMainID,AccountMainDescription,AccountSubID,AccountSubDescription,DebitCreditCode,Amount,DetailComment,PaymentMethod,DocumentTypeDescription,EndDate   From TBLXMLSource  where EntryNumber in
            //(
            //  			SELECT
            //  MIN(EntryNumber) TEntryNumber 
            //FROM
            //     [dbo].[CSVGRUPTA]  WHERE IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
            //GROUP BY
            //    [AccountMainIDList])    and  CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)";
            //            string sql = @"   Select c.EntryNumber,c.DocumentDate,c.EnteredBy,c.AccountMainID,c.AccountMainDescription,c.AccountSubID,c.AccountSubDescription,c.DebitCreditCode,c.Amount,c.DetailComment,c.PaymentMethod,c.DocumentTypeDescription,c.EndDate   From TBLXMLSource as c  JOIN  
            //(
            //     SELECT   Max(EntryNumber) as TentryNumber ,Max([TotalCredit]) as TTotalCredit
            //FROM
            //(
            //    SELECT   TOP 1000000  [AccountMainIDList], EntryNumber ,[TotalCredit]
            //    FROM  [dbo].[CSVGRUPTA]  where IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
            //    ORDER BY EntryNumber
            //) u Group By EntryNumber , [AccountMainIDList])t on t.TentryNumber=c.EntryNumber and t.TTotalCredit=c.TotalCredit ";
            return StaticQuery<DataViewer>(sqll, new { nyear = _year, companyID = _compID, monthid = monthid_ , companyDocumentId =DocumentID}).ToList();
        }
        public static List<DataViewer> DataViewerMainSource(int _year, long _compID, int monthid_)
        {



            //string sql3 = @" Select tb.*,tt.Description ,tt.ColorDesc ,tt.ColorDescTax,tt.DescriptionTax ,tt.ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
            //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
            //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
            //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear) ";

            //string sql = @" Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
            //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
            //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
            //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid) ";

            //string sqlT = @"Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLXMLSource]  as tb WITH (NOLOCK)
            //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
            //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
            //                Where  xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid)  and (tt.ColorDescTax>0 or tt.ColorDescInside>0)"; ()
            long cssvid =   StaticQuery<long>("Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid", new { nyear = _year, companyID = _compID, monthid = monthid_ }).FirstOrDefault();
            string sqll = @"Select  tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside from [TBLXMLSource]  as tb WITH (NOLOCK)
                            LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
                            LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
                            Where  xt.CsvID = @csvid  and tb.CsvID= @csvid   and (tt.ColorDescTax>0 or tt.ColorDescInside>0) group by tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], tt.ColorDescTax,tt.DescriptionTax , tt.ColorDescInside ,tt.DescriptionInside ";
            //            string sql = @"  Select EntryNumber,DocumentDate,EnteredBy,AccountMainID,AccountMainDescription,AccountSubID,AccountSubDescription,DebitCreditCode,Amount,DetailComment,PaymentMethod,DocumentTypeDescription,EndDate   From TBLXMLSource  where EntryNumber in
            //(
            //  			SELECT
            //  MIN(EntryNumber) TEntryNumber 
            //FROM
            //     [dbo].[CSVGRUPTA]  WHERE IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
            //GROUP BY
            //    [AccountMainIDList])    and  CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)";
            //            string sql = @"   Select c.EntryNumber,c.DocumentDate,c.EnteredBy,c.AccountMainID,c.AccountMainDescription,c.AccountSubID,c.AccountSubDescription,c.DebitCreditCode,c.Amount,c.DetailComment,c.PaymentMethod,c.DocumentTypeDescription,c.EndDate   From TBLXMLSource as c  JOIN  
            //(
            //     SELECT   Max(EntryNumber) as TentryNumber ,Max([TotalCredit]) as TTotalCredit
            //FROM
            //(
            //    SELECT   TOP 1000000  [AccountMainIDList], EntryNumber ,[TotalCredit]
            //    FROM  [dbo].[CSVGRUPTA]  where IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
            //    ORDER BY EntryNumber
            //) u Group By EntryNumber , [AccountMainIDList])t on t.TentryNumber=c.EntryNumber and t.TTotalCredit=c.TotalCredit ";
            return StaticQuery<DataViewer>(sqll, new { nyear = _year, companyID = _compID, monthid = monthid_ , csvid = cssvid }).ToList();
        }
        public static List<ReportMainItem> DataReportMain(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT01 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";
            var ttt = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            return ttt;
        }
        public static List<DashBilancoViewQnb> DataReportMainQnb(int _year, long _compID)
        {

            string sql = @"Select * from TBLMQnbReport where   CompanyID=@companyID and  [Year]=@nyear and  MainTypeID in (1,2,3,4,5,6,7,8,9,11) and TypeID not in (7,9,11,15,17,19,21,55,57,59) order by TypeID";
            var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { nyear = _year, companyID = _compID }).ToList();
            return ttt;
        }
        public static List<DashBilancoViewQnb> DataReportMainQnbT(long _compID)
        {

            string sql = @"Select * from TBLMQnbReportShrt where   CompanyID=@companyID   and  MainTypeID in (1,2,3,4,5,6,7,8,9,11)  and TypeID not in (7,9,11,15,17,19,21,55,57,59) order by TypeID";
            var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { companyID = _compID }).ToList();
            return ttt;
        }
        public static List<DashBilancoViewQnb> DataReportMainQnbGelirT(long _compID)
        {

            string sql = @"Select * from TBLMQnbReportShrt where   CompanyID=@companyID  and  MainTypeID not in (1,2,3,4,5,6,7,8,9,11) order by TypeID";
            var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { companyID = _compID }).ToList();
            return ttt;
        }

        public static List<DashBilancoViewQnb> DataReportMainQnbGelir(int _year, long _compID)
        {

            string sql = @"Select * from TBLMQnbReport where   CompanyID=@companyID and  [Year]=@nyear and  MainTypeID not in (1,2,3,4,5,6,7,8,9,11) order by TypeID";
            var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { nyear = _year, companyID = _compID }).ToList();
            return ttt;
        }

        public static List<ReportMainItem> DataReportMainDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT01MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT01MZN where   CompanyID=@companyID and  [Year] in @nyear   order by CounterZone";
            var ttt = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            return ttt;
        }

        public static List<ReportMainItem> DataReportMainDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT01MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT01 where   CompanyID=@companyID and  [Year] in @nyear   order by CounterZone";
            var ttt = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            return ttt;
        }
        public static List<ReportMainItem> DataReportMainCompanyList(long _compID)
        {

            string sql = @"Select  [CompanyID]      ,[Year] from TBMLREPORT01 where   CompanyID=@companyID   group by  [CompanyID]      ,[Year]";

            return StaticQuery<ReportMainItem>(sql, new { companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainA(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT01A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainADynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT01AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT01AMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainADynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT01AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT01A where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainBDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT03MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT03MZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainBDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT03MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT03  where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainCDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT031AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT031AMZN where   CompanyID=@companyID and  [Year]  in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainCDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT031AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT031A  where   CompanyID=@companyID and  [Year]  in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainDDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT05MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT05MZN where   CompanyID=@companyID and  [Year] in @nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainDDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT05MZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT05 where   CompanyID=@companyID and  [Year] in @nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainEDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT051AMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainEDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051AMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT051A  where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainFDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051BMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT051BMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainItem> DataReportMainFDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051BMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            string sql = @"Select * from TBMLREPORT051B  where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainGDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051CMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            //
            string sql = @"Select * from TBMLREPORT051CMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainItem> DataReportMainGDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT051CMZN SOH  where SOH.CompanyID=@companyID 
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";

            //
            string sql = @"Select * from TBMLREPORT051C where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainB(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT03 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainItem> DataReportMainC(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT031A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainItem> DataReportMainD(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT05 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainE(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT051A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainF(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT051B where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainG(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT051C where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainT(int _year, long _compID)
        {

            string sql = @"Select * from TBMLREPORT07 where   CompanyID=@companyID and  [Year]=@nyear   and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }
        public static List<ReportMainItem> DataReportMainTDynamic(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT07MZN SOH  where SOH.CompanyID=@companyID  and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT07MZN where   CompanyID=@companyID and  [Year] in @nyear   and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainItem> DataReportMainTDynamicNew(int[] _year, long _compID)
        {
            //            string sqla = @"SELECT * FROM 
            //(
            //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
            //        SOH.TumYil as TotalSales
            // FROM TBMLREPORT07MZN SOH  where SOH.CompanyID=@companyID  and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)
            //) AS Sales
            //PIVOT (SUM(TotalSales)
            //FOR SalesYear IN @nyear )
            //as PVT order by CounterZone";
            string sql = @"Select * from TBMLREPORT07  where   CompanyID=@companyID and  [Year] in @nyear   and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        }

        public static List<ReportMainChartQnb> DataReportMain1DynamicMainChart(long _compID)
        {

            List<ReportMainChartQnb> nget = new List<ReportMainChartQnb>();
            string sql = @"SELECT [ID]
      ,[AccountMainID] as GridName
      ,[AccountMainDescription] as GroupName 
      ,[Amount] 
      ,[CompanyID]
      ,[Year] as GroupText
      ,[TypeID]  
  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioChart] where CompanyID=@companyID ";



            nget = StaticQuery<ReportMainChartQnb>(sql, new { companyID = _compID }).ToList();


            return nget;
        }

        public static List<ReportMainItemQnb> DataReportMain1DynamicMain(long _compID)
        {

            List<ReportMainItemQnb> nget = new List<ReportMainItemQnb>();
            string sql = @"SELECT [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] as GroupName 
      ,[AccountMainDescription] as GridName  
      ,cast([Amount] as decimal(25,2)) as Amount
    ,cast([Amount1] as decimal(25,2)) as Amount1
    ,cast([Amount2] as decimal(25,2)) as Amount2
    ,cast([Amount3] as decimal(25,2)) as Amount3
    ,cast([Amount4] as decimal(25,2)) as Amount4
      ,[CompanyID] 
      ,[TypeID]
      ,[MainTypeID]
      ,[ColorID]
  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioChartShrt] where CompanyID=@companyID ";



            nget = StaticQuery<ReportMainItemQnb>(sql, new { companyID = _compID }).ToList();


            return nget;
        }

        public static List<ReportMainItem> DataReportMain1Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=11 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil,YIL as Year   FROM [dbo].[TBLBANKAKREDIAKTIFLER] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain1DynamicNew(int[] _year, long _compID, int _naceID)
        {
            ////List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=11 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil,YIL as Year   FROM [dbo].[TBLBANKAKREDIAKTIFLER] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain2Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=33 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBANKAKREDIYABKAYNAK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain2DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=33 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBANKAKREDIYABKAYNAK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain3Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=111 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year   FROM [dbo].[TBLDURANVARLIKOZKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain3DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=111 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year   FROM [dbo].[TBLDURANVARLIKOZKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain4Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=133 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBDONENVARLIKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain4DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=133 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBDONENVARLIKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain5Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=255 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEALACKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain5DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=255 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEALACKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain6Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _year = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=277 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEALACKDONEN] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain6DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=277 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEALACKDONEN] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain7Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=299 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEKYNKPASIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain7DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=299 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBKVADEKYNKPASIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain8Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=377 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil  ,YIL as Year   FROM [dbo].[TBLBMDDIDURANOKAYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain8DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=377 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil  ,YIL as Year   FROM [dbo].[TBLBMDDIDURANOKAYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain9Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=499 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil  ,YIL as Year   FROM [dbo].[TBLBSTOKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain9DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=499 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil  ,YIL as Year   FROM [dbo].[TBLBSTOKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain10Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=533 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year   FROM [dbo].[TBLBUVADEYABKYNKPSF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain10DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=533 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year   FROM [dbo].[TBLBUVADEYABKYNKPSF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain11Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=577 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBOKYNKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain11DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=577 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBOKYNKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain12Dynamic(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=599 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBOKYNKYBNCIKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain12DynamicNew(int[] _year, long _compID, int _naceID)
        {
            //List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and CounterZone=599 and [Year] IN @nyear ";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,YIL as Year    FROM [dbo].[TBLBOKYNKYBNCIKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain1(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear  and CounterZone=11";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBANKAKREDIAKTIFLER] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain2(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=33";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBANKAKREDIYABKAYNAK] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain3(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=111";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLDURANVARLIKOZKYNK] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain4(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=133";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBDONENVARLIKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain5(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=255";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEALACKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain6(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=277";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEALACKDONEN] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain7(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=299";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEKYNKPASIF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        //TBLBOKYNKYBNCIKYNK,TBLBOKYNKAKTIF,TBLBUVADEYABKYNKPSF,TBLBSTOKAKTIF,TBLBMDDIDURANOKAYNK,,,,,,,,,,,,,,,,,,,
        public static List<ReportMainItem> DataReportMain8(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=377";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBMDDIDURANOKAYNK] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain9(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=499";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBSTOKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static List<ReportMainItem> DataReportMain10(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=533";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBUVADEYABKYNKPSF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        public static List<ReportMainItem> DataReportMain11(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=577";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBOKYNKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }
        //
        //TBLBOKYNKYBNCIKYNK,TBLBOKYNKAKTIF,TBLBUVADEYABKYNKPSF,,,,,,,,,,,,,,,,,,,,,
        //
        public static List<ReportMainItem> DataReportMain12(int _year, long _compID, int _naceID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            List<ReportMainItem> nget1 = new List<ReportMainItem>();
            string sql = @"Select [TumYil]      ,[CompanyID]      ,[Year] , 'İşletme' as GroupName ,[CounterZone]      ,[TypeID]      ,[ID] from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=599";

            nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
            nget.AddRange(nget1);

            nget1 = new List<ReportMainItem>();
            string sql1 = @"  SELECT 'Sektörü ve Segment Ortalaması' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBOKYNKYBNCIKYNK] where [YIL]=@nyear and [NACE]=@nace";
            nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
            nget.AddRange(nget1);

            return nget;
        }

        public static IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            string sql = @"Select * from [dbo].[TBMLREPOR01] where   CompanyID=@companyID and  [Year]=(Select MAX(Year) from [dbo].[TBMLREPOR01] where   CompanyID=@companyID  and TypeID=11 and TumYil is not null)";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

        }
        public static IEnumerable<ReportMainItem> DataReportMainKapakDynamic(int _year, long _compID)
        {
            List<ReportMainItem> nget = new List<ReportMainItem>();
            string sql = @"Select * from [dbo].[TBMLREPOR01MZN] where   CompanyID=@companyID and  [Year]=@nyear";

            return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

        }

        public static List<ReportMainChart> DataReportMainChart(ReportMainItem _nItem)
        {
            List<ReportMainChart> ncheck = new List<ReportMainChart>();
            ReportMainChart ncha = new ReportMainChart();
            ncha.GroupName = _nItem.GroupName;
            ncha.GroupText = "Q1";
            ncha.Value = _nItem.Q1;
            ncheck.Add(ncha);
            ncha = new ReportMainChart();
            ncha.GroupName = _nItem.GroupName;
            ncha.GroupText = "Q2";
            ncha.Value = _nItem.Q2;
            ncheck.Add(ncha);
            ncha = new ReportMainChart();
            ncha.GroupName = _nItem.GroupName;
            ncha.GroupText = "Q3";
            ncha.Value = _nItem.Q3;
            ncheck.Add(ncha);
            ncha = new ReportMainChart();
            ncha.GroupName = _nItem.GroupName;
            ncha.GroupText = "TumYil";
            ncha.Value = _nItem.TumYil;
            ncheck.Add(ncha);

            return ncheck;
        }



        public static List<ReportMainChartQnb> DataReportMainChartMultiQnb(ReportMainItemQnb _nItem, int chk_)
        {
            List<ReportMainChartQnb> ncheck = new List<ReportMainChartQnb>();
            ReportMainChartQnb ncha = new ReportMainChartQnb();

            ncha.GridName = _nItem.GroupName;
            ncha.GroupText = _nItem.Year.ToString();
            switch (chk_)
            {
                case 1: ncha.Amount = _nItem.Amount; break;
                default:
                    break;
            }

            ncheck.Add(ncha);

            return ncheck;
        }

        public static List<ReportMainChart> DataReportMainChartMulti(ReportMainItem _nItem)
        {
            List<ReportMainChart> ncheck = new List<ReportMainChart>();
            ReportMainChart ncha = new ReportMainChart();
            ncha.GroupName = _nItem.GroupName;
            ncha.GroupText = _nItem.Year.ToString();
            ncha.Value = _nItem.TumYil;
            ncheck.Add(ncha);

            return ncheck;
        }
        public static List<ReportMainChart> DataReportMainChartMain(List<ReportMainItem> _nItem)
        {
            List<ReportMainChart> ncheck = new List<ReportMainChart>();

            foreach (var item in _nItem)
            {
                ncheck.AddRange(DataReportMainChart(item));
            }

            return ncheck;
        }
        public static List<ReportMainChart> DataReportMainChartMainMulti(IEnumerable<ReportMainItem> _nItem)
        {
            List<ReportMainChart> ncheck = new List<ReportMainChart>();

            foreach (var item in _nItem)
            {
                ncheck.AddRange(DataReportMainChartMulti(item));
            }

            return ncheck;
        }

    }


}


public class ReportKapak
{

    public static ReportKapak setKapak(IEnumerable<ReportMainItem> nlist)
    {
        ReportKapak nkapak = new ReportKapak();
        nkapak.nitemCariOran = nlist.Where(x => x.TypeID == 11).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 11).FirstOrDefault();
        nkapak.nitemLikitideOran = nlist.Where(x => x.TypeID == 33).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 33).FirstOrDefault();
        nkapak.nitemNakitOran = nlist.Where(x => x.TypeID == 55).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 55).FirstOrDefault();
        nkapak.nitemAlacakDevir = nlist.Where(x => x.TypeID == 171).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 171).FirstOrDefault();
        nkapak.nitemTicariBorcDevir = nlist.Where(x => x.TypeID == 101).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 101).FirstOrDefault();
        nkapak.nitemStokDevir = nlist.Where(x => x.TypeID == 99).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 99).FirstOrDefault();
        nkapak.nitemBorcOzsermaye = nlist.Where(x => x.TypeID == 141).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 141).FirstOrDefault();
        nkapak.nitemTpolamBankaBorc = nlist.Where(x => x.TypeID == 161).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 161).FirstOrDefault();
        nkapak.nitemOzkaynakAktif = nlist.Where(x => x.TypeID == 201).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 201).FirstOrDefault();
        nkapak.nitemOzsermayeKarlilik = nlist.Where(x => x.TypeID == 181).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 181).FirstOrDefault();
        nkapak.nitemNetIsletmeSermaye = nlist.Where(x => x.TypeID == 121).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 121).FirstOrDefault();
        nkapak.nitemNetSatisBuyumeOran = nlist.Where(x => x.TypeID == 191).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 191).FirstOrDefault();
        nkapak.nitemROAAktifKarlilik = nlist.Where(x => x.TypeID == 221).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 221).FirstOrDefault();
        nkapak.nitemAltmanz = nlist.Where(x => x.TypeID == 251).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 251).FirstOrDefault();
        nkapak.nitemFaizVergiOncesiKarZarar = nlist.Where(x => x.TypeID == 231).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 231).FirstOrDefault();
        return nkapak;
    }

    //    GroupName CounterZone
    //Cari Oranı	11
    //Likitide Oranı	33
    //Nakit Oranı(%)  55
    //Ortalama Tahsil Süresi	77
    //Stok Devir Hızı	99
    //Borç Devir Hızı	101
    //Net İşletme Sermayesi	121
    //Toplam Borç / Özsermaye Oranı	141
    //Kısa vadeli Banka borçları/Net Satışlar	161
    //Alacak Devir Hızı	171
    //Özsermaye Karlılığı	181
    //Net Satış Büyüme Oranı	191
    public ReportMainItem nitemAltmanz { get; set; }
    public ReportMainItem nitemFaizVergiOncesiKarZarar { get; set; }
    public ReportMainItem nitemNetIsletmeSermaye { get; set; }
    public ReportMainItem nitemNetSatisBuyumeOran { get; set; }
    public ReportMainItem nitemCariOran { get; set; }
    public ReportMainItem nitemLikitideOran { get; set; }
    public ReportMainItem nitemNakitOran { get; set; }
    public ReportMainItem nitemAlacakDevir { get; set; }
    public ReportMainItem nitemTicariBorcDevir { get; set; }
    public ReportMainItem nitemStokDevir { get; set; }
    public ReportMainItem nitemBorcOzsermaye { get; set; }
    public ReportMainItem nitemTpolamBankaBorc { get; set; }
    public ReportMainItem nitemOzkaynakAktif { get; set; }
    public ReportMainItem nitemOzsermayeKarlilik { get; set; }
    public ReportMainItem nitemROAAktifKarlilik { get; set; }
}

//       
public class YearlyErrorResultView
{

    public IEnumerable<YearlyErrorResult> mrequestEntryCount { get; set; }
    public string EntryCountTotal => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Sum(x => x.TRowCount).ToString("N0") : "0";

    public string ErrorCountTotal => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Sum(x => x.TErrorRowCount).ToString("N0") : "0";
    public string EntryCountLast => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TRowCount).ToString() : "0";
    public string ErrorCountLast => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TErrorRowCount).ToString() : "0";
    public string EntryCountBefore => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TRowCount).ToString() : "0";
    public string ErrorCountBefore => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TErrorRowCount).ToString() : "0";
}

public class YearlyErrorResult
{
    public int MainYear { get; set; }
    public int MainMonth { get; set; }
    public int TErrorRowCount { get; set; }
    public string DocumentMonth { get; set; }
    public string DocumentMonthTr { get; set; }
    public int TRowCount { get; set; }
    public int TNonErrorRowCount { get; set; }
    public string TxResult { get; set; }
}
public class ReportMainItemQnb
{
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public string GridName { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }
    public int MainTypeID { get; set; }
    public int ColorID { get; set; }
    public float Amount { get; set; }
    public float Amount1 { get; set; }
    public float Amount2 { get; set; }
    public float Amount3 { get; set; }
    public float Amount4 { get; set; }

}
public class ReportMainItem
{
    public float Q1 { get; set; }
    public float Q2 { get; set; }
    public float Q3 { get; set; }
    public float TumYil { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }


    public byte IsFailed { get; set; }
    public string Q1Tx1A
    {
        get { if (Q1 < 10000) { return (Q1).ToString("N2"); } else { return Q1.ToString("N0"); }; }
        set { }
    }
    public string Q2Tx1A
    {
        get { if (Q2 < 10000) { return (Q2).ToString("N2"); } else { return Q2.ToString("N0"); }; }
        set { }
    }
    public string Q3Tx1A
    {
        get { if (Q3 < 10000) { return (Q3).ToString("N2"); } else { return Q3.ToString("N0"); }; }
        set { }
    }
    public string TumYilTx1A
    {
        get { if (TumYil < 10000) { return (TumYil).ToString("N2"); } else { return TumYil.ToString("N0"); }; }
        set { }
    }
    public string Q1Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q1 * 100).ToString("N1"); } else { return Q1.ToString("N2"); }; }
        set { }
    }
    public string Q2Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q2 * 100).ToString("N1"); } else { return Q2.ToString("N2"); }; }
        set { }
    }
    public string Q3Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q3 * 100).ToString("N1"); } else { return Q3.ToString("N2"); }; }
        set { }
    }
    public string TumYilTx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (TumYil * 100).ToString("N1"); } else { return TumYil.ToString("N2"); }; }
        set { }
    }
    public string Q1Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q1 * 100).ToString("N1"); } else { return Q1.ToString("N0"); }; }
        set { }
    }
    public string Q2Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q2 * 100).ToString("N1"); } else { return Q2.ToString("N0"); }; }
        set { }
    }
    public string Q3Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q3 * 100).ToString("N1"); } else { return Q3.ToString("N0"); }; }
        set { }
    }
    public string TumYilTx
    {
        get { if (GroupName.Contains("%")) { return "%" + (TumYil * 100).ToString("N1"); } else { return TumYil.ToString("N0"); }; }
        set { }
    }

}
public class ReportMainChartQnb
{
    public string AccountMainID { get; set; }
    public string GridName { get; set; }
    public string GroupText { get; set; }
    public float Amount { get; set; }
    public int TypeID { get; set; }

}
public class ReportMainChart
{

    public string GroupName { get; set; }
    public string GroupText { get; set; }
    public float Value { get; set; }
}
public class ReportMizan
{
    public long TotalAssets { get; set; }
    public long TotalLiability { get; set; }

    public long TotalEquity { get; set; }
    public long ProfitOrLoss { get; set; }
    public long TrialBalance { get; set; }

}
public class ReportMizanone
{
    public long Amount { get; set; }

}
public class ReportMizanCheck : BaseModel
{
    public static ReportMizanone Get_TrialBalance(int _year, long _compID)
    {
        ReportMizanone result = StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2,3,4,5,6)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

        long check = StaticQuery<long>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        result.Amount = result.Amount + check;
        return result;
    }
    public static ReportMizanone Get_TrialBalanceMizan(int _year, long _compID)
    {
        ReportMizanone result = StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where  CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2,3,4,5,6)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

        long check = StaticQuery<long>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        result.Amount = result.Amount + check;
        return result;
    }
    public static ReportMizanone Get_TotalAssets(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_TotalAssetsMizan(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_TotalLiability(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(3,4)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_TotalLiabilityMizan(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(3,4)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_TotalEquity(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount  FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID=5) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_TotalEquityMizan(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount  FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID=5) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_ProfitOrLoss(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and [Year]=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(6,7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizanone Get_ProfitOrLossMizan(int _year, long _compID)
    {
        return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(6,7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static long Get_P590(int _year, long _compID)
    {
        return StaticQuery<long>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='590'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static long Get_P591(int _year, long _compID)
    {
        return StaticQuery<long>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear    and AccountMainID ='591'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    //  
    public static long Get_NetKarZarar(int _year, long _compID)
    {
        return StaticQuery<long>("Select ([January] +[February]+[March]+[April]+[May]+[June]+[July]+[August]+[September]+[October]+[November]+[December] ) from  TBLWcapDonemKarZararNet where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public static ReportMizan GetComapanyCumulative(int _year, long _compID)
    {
        ReportMizan rn = new ReportMizan();
        long netkarz = Get_NetKarZarar(_year, _compID);
        rn.ProfitOrLoss = netkarz;
        rn.TotalAssets = Get_TotalAssets(_year, _compID).Amount;
        rn.TotalEquity = Get_TotalEquity(_year, _compID).Amount;
        rn.TotalLiability = Get_TotalLiability(_year, _compID).Amount;
        rn.TrialBalance = Math.Abs(rn.TotalAssets) - (Math.Abs(rn.TotalEquity) + Math.Abs(rn.TotalLiability));

        if (rn.TrialBalance < 2 && rn.TrialBalance > -2)
        {
            rn.ProfitOrLoss = 0;
            rn.TrialBalance = 0;
            return rn;
        }


        long get590 = Get_P590(_year, _compID);
        if (get590 > netkarz)
        {
            if (get590 - netkarz < 1)
            {

            }
            else
            {
                rn.ProfitOrLoss = 0;
                rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(get590);
            }
        }
        else
        {
            if (netkarz - get590 < 1)
            {

            }
            else
            {
                rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(netkarz);
            }
        }

        if (rn.TrialBalance < 2 && rn.TrialBalance > -2)
        {
            rn.TrialBalance = 0;

        }

        return rn;
    }
    public static ReportMizan GetComapanyCumulativeMizan(int _year, long _compID)
    {
        ReportMizan rn = new ReportMizan();
        rn.ProfitOrLoss = Get_ProfitOrLossMizan(_year, _compID) != null ? Get_ProfitOrLossMizan(_year, _compID).Amount : 0;
        rn.TotalAssets = Get_TotalAssetsMizan(_year, _compID) != null ? Get_TotalAssetsMizan(_year, _compID).Amount : 0;
        rn.TotalEquity = Get_TotalEquityMizan(_year, _compID) != null ? Get_TotalEquityMizan(_year, _compID).Amount : 0;
        rn.TotalLiability = Get_TotalLiabilityMizan(_year, _compID) != null ? Get_TotalLiabilityMizan(_year, _compID).Amount : 0;

        long totalPasive = DashOzetMaliMizan.getPasifMizan(_year, _compID);
        long totalKArzarare = DashOzetMaliMizan.getKArzarar(_year, _compID);
        long totalOzkaynak = DashOzetMaliMizan.getOzkaynak(_year, _compID);
        rn.TrialBalance = Math.Abs(rn.TotalAssets) - (Math.Abs(rn.TotalEquity) + Math.Abs(rn.TotalLiability));
        long get590 = Get_P590(_year, _compID);
        bool chkKarZarar = false;
        if (get590 == 0)
        {
            chkKarZarar = true;
            get590 = totalKArzarare;
        }

        if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
        {
            rn.TotalEquity = totalOzkaynak;
            rn.ProfitOrLoss = 0;
            if (chkKarZarar)
            {
                rn.ProfitOrLoss = get590;
            }

            rn.TrialBalance = 0;
            return rn;
        }
        rn.TrialBalance = Math.Abs(rn.TotalAssets) - Math.Abs(totalPasive);

        if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
        {
            rn.TotalEquity = totalOzkaynak;
            rn.ProfitOrLoss = 0;
            if (chkKarZarar)
            {
                rn.ProfitOrLoss = get590;
            }
            rn.TrialBalance = 0;
            return rn;
        }



        if (get590 > rn.ProfitOrLoss)
        {
            if (get590 - rn.ProfitOrLoss < 1)
            {

            }
            else
            {
                rn.ProfitOrLoss = 0;
                if (chkKarZarar)
                {
                    rn.ProfitOrLoss = get590;
                }
                rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(totalKArzarare);
            }
        }
        else
        {
            if (rn.ProfitOrLoss - get590 < 1)
            {
                rn.ProfitOrLoss = get590;
                rn.TrialBalance = 0;
            }
            else
            {
                if (rn.TrialBalance == 0)
                {
                    rn.TrialBalance = Math.Abs(rn.TrialBalance - rn.ProfitOrLoss);
                }
                else
                {

                    rn.TrialBalance = Math.Abs(rn.TrialBalance - rn.ProfitOrLoss);
                    rn.ProfitOrLoss = 0;
                    if (chkKarZarar)
                    {
                        rn.ProfitOrLoss = get590;
                    }
                }
            }
        }


        rn.ProfitOrLoss = 0;
        if (chkKarZarar)
        {
            rn.ProfitOrLoss = get590;
        }
        rn.TotalEquity = totalOzkaynak;
        rn.TrialBalance = Math.Abs(rn.TotalAssets) - (rn.TotalEquity + rn.TotalLiability + rn.ProfitOrLoss);
        if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
        {
            rn.TrialBalance = 0;

        }
        return rn;
    }
    public static ReportMizan GetComapanyCumulativeBeyan(int _year, long _compID)
    {
        ReportMizan rn = new ReportMizan();
        rn.ProfitOrLoss = Get_ProfitOrLossMizan(_year, _compID) != null ? Get_ProfitOrLossMizan(_year, _compID).Amount : 0;
        rn.TotalAssets = Get_TotalAssetsMizan(_year, _compID) != null ? Get_TotalAssetsMizan(_year, _compID).Amount : 0;
        rn.TotalEquity = Get_TotalEquityMizan(_year, _compID) != null ? Get_TotalEquityMizan(_year, _compID).Amount : 0;
        rn.TotalLiability = Get_TotalLiabilityMizan(_year, _compID) != null ? Get_TotalLiabilityMizan(_year, _compID).Amount : 0;
        rn.TrialBalance = Get_TrialBalanceMizan(_year, _compID) != null ? Get_TrialBalanceMizan(_year, _compID).Amount : 0;
        return rn;
    }
}

