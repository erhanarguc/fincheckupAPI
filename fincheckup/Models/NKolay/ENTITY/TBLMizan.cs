using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY
{
    public class TBLMizan : BaseModel
    {
        public long ID { get; set; }
        public string CsvName { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public int Year { get; set; }
        public int MainMonth { get; set; }
        public static IEnumerable<TBLMizan> Get_TBLMizan()
        {
            return StaticQuery<TBLMizan>("Select * From [TBLMizan]");
        }
        public static int GetComapnyIDByMonth(long compide, int monide, int yearide)
        {
            return StaticQuery<int>("Select ID From [TBLMizan] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
        }
        //
        public static int GetComapnyCountMizanByn(long compide, int yearide)
        {
            return StaticQuery<int>("SELECT  COUNT(*) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] where  [Year]=@year and CompanyID=@ID and (AccountMainID>'599' and AccountMainID<'699' ) and Amount>0", new { ID = compide, year = yearide }).FirstOrDefault();
        }
        public static int DeleteComapnyCountMizanByn(long compide, int yearide)
        {
            return StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] where  [Year]=@year and CompanyID=@ID and  AccountMainID>'599'  ", new { ID = compide, year = yearide }).FirstOrDefault();
        }
        public static IEnumerable<TBLMizan> Get_TBLMizanCompany(string ide)
        {
            return StaticQuery<TBLMizan>("Select * From [TBLMizan] where CompanyID=@ID ", new { ID = ide });
        }
        public static TBLMizan GetRow_TBLMizan(string ide)
        {
            return StaticQuery<TBLMizan>("Select * From [TBLMizan] where ID=@ID ", new { ID = ide }).FirstOrDefault();
        }
        public static int GetYearByComapnyID(long ide)
        {
            return StaticQuery<int>("Select COUNT(DISTINCT(Year)) From [TBLMizan] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
        }


        public void Save_TBLMizan()
        {
            string sql = @"  INSERT INTO [TBLMizan]
          (  
        [CsvName] ,
        [CompanyID] ,
        [CreatedDate] ,
DocumentDate ,MainMonth,[Year]
          ) 
           VALUES 
         (  
        @CsvName ,
        @CompanyID ,
        getdate() ,
@DocumentDate ,@MainMonth,@Year
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_TBLMizan()
        {
            try
            {
                string sql = "UPDATE   [TBLMizan] SET     [CsvName]=@CsvName , [CompanyID]=@CompanyID , [CreatedDate]=@CreatedDate,DocumentDate=@DocumentDate, [Year]=@Year ,MainMonth=@MainMonth WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
