using fincheckup.ENTITY;
using fincheckup.Models.ViewM;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace fincheckup.Models.NKolay.ViewM
{
    public class ErrorCheckSet
    {
        public int ID { get; set; }
        public string MainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public string InMainDesc { get; set; }
        public string InMainDescDC { get; set; }
        public string OutMainDesc { get; set; }
        public string OutMainDescDC { get; set; }
        public float CheckAmount { get; set; }
        public int QueryType { get; set; } 
        public int ColorDesc { get; set; } 
        public string Description { get; set; }
        public int  ColorDescTax { get; set; }          
        public string  DescriptionTax { get; set; }     
        public int  ColorDescInside { get; set; }      
        public string  DescriptionInside { get; set; }
    }
    public class ErrorCheckMain : BaseModel
    {
        public static List<ErrorCheckSet> Get_ReportSet()
        {
            return StaticQuery<ErrorCheckSet>("SELECT * FROM [dbo].[TBLErrzoneInside]").ToList();
        }

        public static List<TBLErrzoneRow> Get_ReportErrSet()
        {
            return StaticQuery<TBLErrzoneRow>("SELECT * FROM [dbo].[TBLErrzone]").ToList();
        }
        public static void Set_ReportSet(int _CsvID)
        {

            List<ErrorCheckSet> setM = Get_ReportSet();
            string nQueryId = string.Empty;
            string nsql = string.Empty;
            foreach (var item in setM)
            {
                nQueryId = "SPOW_ErrorInside" + item.QueryType.ToString();
                nsql = @"EXEC " + nQueryId + " @CsvID,@MainDesc,@MainDC,@MainDescChkIn,@MainDescChkInDC,@OutMainDesc,@OutMainDescDC,@CheckAmount,@InsideID";
                StaticQuery<int>(nsql, new { CsvID = _CsvID, MainDesc = item.MainDescription, MainDC = item.DebitCreditCode, MainDescChkIn = item.InMainDesc, MainDescChkInDC = item.InMainDescDC, OutMainDesc = item.OutMainDesc, OutMainDescDC = item.OutMainDescDC, CheckAmount = item.CheckAmount, InsideID = item.ID }).ToList();
                Thread.Sleep(300);
            }
        }
        public static List<DataViewer> Get_ReportSetAll(int _year, long _compID, int _month)
        {
            int _csvid = TBLXml.GetComapnyIDByMonth(_compID, _month, _year);
            string sql = @" Select tb.[EntryNumber],tb.[DocumentDate],tb.[EnteredBy],tb.[AccountMainID],tb.[AccountMainDescription],tb.[AccountSubID]
,tb.[AccountSubDescription],tb.[DebitCreditCode],tb.[Amount],tb.[DetailComment],tb.[PaymentMethod],tb.[DocumentTypeDescription],tb.[EndDate],tb.[EntryComment],tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc  from  [dbo].[TBLErrzoneInsideXML] xt
                            LEFT  OUTER JOIN  TBLXMLSource as tb on tb.CsvID=xt.CsvID and tb.EntryNumber=xt.EntryNo
                            LEFT  OUTER JOIN [dbo].[TBLErrzoneInside] tt  on tt.ID=xt.ErrorInsideID
                            Where tb.CsvID=@csvID and xt.CsvID =@csvID  and tb.IsPassedEntry=0  and tb.IsFailed=1 and tt.ColorDesc>0 group by tb.[EntryNumber],tb.[DocumentDate],tb.[EnteredBy],tb.[AccountMainID],tb.[AccountMainDescription],tb.[AccountSubID]
,tb.[AccountSubDescription],tb.[DebitCreditCode],tb.[Amount],tb.[DetailComment],tb.[PaymentMethod],tb.[DocumentTypeDescription],tb.[EndDate],tb.[EntryComment],tt.Description , tt.ColorDesc ";


            return StaticQuery<DataViewer>(sql, new { csvID = _csvid }).ToList();
        }

        public static List<DataViewer> Get_ReportSetOther(int _year, long _compID, int _month)
        {
            int _csvid = TBLXml.GetComapnyIDByMonth(_compID, _month, _year);
            string sql = @"Select  tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from  [dbo].[TBLErrzoneInsideXML] xt
                            LEFT  OUTER JOIN  TBLXMLSource as tb on tb.CsvID=xt.CsvID and tb.EntryNumber=xt.EntryNo
                            LEFT  OUTER JOIN [dbo].[TBLErrzoneInside] tt  on tt.ID=xt.ErrorInsideID
                            Where tb.CsvID=@csvID and xt.CsvID =@csvID  and tb.IsPassedEntry=0  and tt.ColorDesc=0 and ( tt.[ColorDescTax]>0 or tt.[ColorDescInside]>0) group by tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], tt.ColorDescTax,tt.DescriptionTax , tt.ColorDescInside ,tt.DescriptionInside ";


            return StaticQuery<DataViewer>(sql, new { csvID = _csvid }).ToList();
        }
    }
}
