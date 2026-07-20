using System;
using System.Collections.Generic;

namespace fincheckup.Models.NKolay
{
    public class DashBoard : BaseModel
    {

        public int Pass { get; set; }
        public int Fail { get; set; }
        public int total => Pass + Fail;
        public long CompanyID { get; set; }
        public DateTime Datum { get; set; }
        public string datetext { get; set; }
        public static IEnumerable<DashBoard> Get_ErroorList()
        {
            string sql = @" 
SELECT   [Pass]
      ,[Fail]
      ,[MonthPay]
      ,[YearPay],    CAST(
      CAST([YearPay] AS VARCHAR(4)) +
      RIGHT('0' + CAST([MonthPay] AS VARCHAR(2)), 2) +
      RIGHT('0' + CAST(1 AS VARCHAR(2)), 2)  
   AS DATETIME) as Datum,CsvID,CompanyID,   (
      CAST([YearPay] AS VARCHAR(4)) +'-'+
      RIGHT('0' + CAST([MonthPay] AS VARCHAR(2)), 2) ) as datetext
  FROM  [dbo].[ERRORVIEW] order by [YearPay],[MonthPay]";
            return StaticQuery<DashBoard>(sql);
        }
    }
    public class DashBoardRasyo : BaseModel
    {
        public string Description { get; set; }
        public decimal Ocak { get; set; }
        public decimal Subat { get; set; }
        public decimal Mart { get; set; }
        public decimal Nisan { get; set; }
        public decimal Mayıs { get; set; }
        public decimal Haziran { get; set; }
        public decimal Temmuz { get; set; }
        public decimal Agustos { get; set; }
        public decimal Eylul { get; set; }
        public decimal Ekim { get; set; }
        public decimal Kasim { get; set; }
        public decimal Aralik { get; set; }
        public long CompanyID { get; set; }
        public static IEnumerable<DashBoardRasyo> Get_List()
        {
            string sql = @"SELECT  [Description]
      ,[January] as 'Ocak'
      ,[February] as 'Subat'
      ,[March] as 'Mart'
      ,[April] as 'Nisan'
      ,[May] as 'Mayis'
      ,[June] as 'Haziran'
      ,[July] as 'Temmuz'
      ,[August] as 'Agustos'
      ,[September] as 'Eylül'
      ,[October] as 'Ekim'
      ,[November] as 'Kasim'
      ,[December] as 'Aralik'
      ,[CompanyID] 
  FROM  [dbo].[TTZDashBoardOran]";
            return StaticQuery<DashBoardRasyo>(sql);
        }

    }
    public class DashBoardVarlik : BaseModel
    {

        public long Donen { get; set; }
        public long Duran { get; set; }
        public long CompanyID { get; set; }
        public DateTime Datum { get; set; }
        public long total => Donen + Duran;

        public string datetext => Datum.ToString("yyyy-MM");

    }
}
