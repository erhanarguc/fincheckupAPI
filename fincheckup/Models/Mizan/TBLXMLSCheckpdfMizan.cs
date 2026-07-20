using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;
using System;

namespace fincheckup.Models.Mizan
{
    public class TBLXMLSCheckpdfMizan : BaseModel
    {
        public int PageID { get; set; }
        public long ID { get; set; }
        public string AccountMainZet => (AccountMainID + AccountMainDescription).Replace(" ", "");
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public double Amount1 { get; set; }
        public double Amount2 { get; set; }
        public double Amount3 { get; set; }
        public double Amount4 { get; set; }
        public int Amount1Diff { get; set; }
        public int Amount2Diff { get; set; }
        public int Amount3Diff { get; set; }
        public int Amount4Diff { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public byte MainMonth { get; set; }
        public static List<MizanUploadControl> GetMizanUploded(long _ID, int _year)
        {
            return StaticQuery<MizanUploadControl>("SELECT  [CompanyID],[Year],[IsBeyan],MainMonth  FROM [EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where [CompanyID] =@compid  and [Year]=@nyear group by [CompanyID],[Year],[IsBeyan],MainMonth", new { compid = _ID, nyear = _year }).ToList();
        }
        public static IEnumerable<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizan()
        {
            return StaticQuery<TBLXMLSCheckpdfMizan>("Select * From [TBLXMLSCheckpdfMizan]");
        }
        public static List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanLast(long _ID,int nyear_)
        {
            return StaticQuery<TBLXMLSCheckpdfMizan>("Select * from  [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where CompanyID=@ID and Year=@nyear   and [Amount1Diff]=0 and [Amount2Diff]=0", new { ID = _ID , nyear = nyear_ }).ToList();
        }
        public static List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanCount(long _ID, int nyear_, byte nmonth_)
        {
            StaticQuery<int>("delete from [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where (Amount1=0 and Amount2=0 and Amount3=0)  and CompanyID=@ID and Year=@nyear and MainMonth=@nmon", new { ID = _ID, nyear = nyear_, nmon = nmonth_ });
            return StaticQuery<TBLXMLSCheckpdfMizan>("Select * from  [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where CompanyID=@ID and Year=@nyear and MainMonth=@nmon", new { ID = _ID, nyear = nyear_, nmon = nmonth_ }).ToList();
        }
        public static List<TBLXMLSCheckpdfMizan> LastRepByCompanyIDn(int nyear_, long _ID, int nmonth_, byte typeIDe)
        {
            return StaticQuery<TBLXMLSCheckpdfMizan>("EXEC Sa_PRoMznPdfIN @nyear,@compdID,@nmon,@typeID", new { nyear = nyear_, compdID = _ID,  nmon = nmonth_, typeID = typeIDe }).ToList();
        }
        public static List<TBLXMLSCheckpdfMizan> GetMizanBeyanSame(long _ID)
        {
            return StaticQuery<TBLXMLSCheckpdfMizan>("Select[Year],CompanyID,MainMonth FROM[EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID = @compdID and IsBeyan = 0 and Cast([Year] as nvarchar(4))+Cast(CompanyID  as nvarchar(24))+Cast(MainMonth as nvarchar(24)) in (Select Cast([Year] as nvarchar(4))+Cast(CompanyID  as nvarchar(24))+Cast(MainMonth as nvarchar(24))   FROM[EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID =@compdID and IsBeyan = 1) group by CompanyID,MainMonth ,[Year]", new { compdID = _ID }).ToList();
        }
        
        public static TBLXMLSCheckpdfMizan GetRow_TBLXMLSCheckpdfMizan(long _ID)
        {
            return StaticQuery<TBLXMLSCheckpdfMizan>("Select * From [TBLXMLSCheckpdfMizan] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static int DeleteByCompanyIDn(long _ID, int nyear_, int nmonth_)
        {
            return StaticQuery<int>("DELETE From [TBLXMLSCheckpdfMizan] where CompanyID=@ID and [Year]=@nyear  and MainMonth=@monthide ", new { ID = _ID,nyear= nyear_, monthide = nmonth_ }).FirstOrDefault();
        }
        public void Save_TBLXMLSCheckpdfMizan()
        {
            string sql = @"  INSERT INTO [TBLXMLSCheckpdfMizan]
          ( 
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount1] ,
        [Amount1Diff] ,
        [Amount2] ,
        [Amount2Diff] ,
        [Amount3] ,
        [Amount3Diff] ,
        [Amount4] ,
        [Amount4Diff] ,
        [CompanyID] ,
        [Year] ,MainMonth,PageID
          ) 
           VALUES 
         ( 
        @AccountMainID ,
        @AccountMainDescription ,
        @Amount1 ,
        @Amount1Diff ,
        @Amount2 ,
        @Amount2Diff ,
        @Amount3 ,
        @Amount3Diff ,
        @Amount4 ,
        @Amount4Diff ,
        @CompanyID ,
        @Year ,@MainMonth,@PageID
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_TBLXMLSCheckpdfMizan()
        {
            try
            {
                string sql = "UPDATE   [TBLXMLSCheckpdfMizan] SET  [AccountMainID]=@AccountMainID , [AccountMainDescription]=@AccountMainDescription , [Amount1]=@Amount1 , [Amount1Diff]=@Amount1Diff , [Amount2]=@Amount2 , [Amount2Diff]=@Amount2Diff , [Amount3]=@Amount3 , [Amount3Diff]=@Amount3Diff , [Amount4]=@Amount4 , [Amount4Diff]=@Amount4Diff , [CompanyID]=@CompanyID , [Year]=@Year   WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class MizanUploadControl
    {
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public int MainMonth { get; set; }
        public byte IsBeyan { get; set; }

    }
    public class TBLXMLSCheckpdfMizancHK
    {
        public int pageID { get; set; }
        public long ID { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public double Amount1 { get; set; }
        public double Amount2 { get; set; }
        public double Amount3 { get; set; }
        public double Amount4 { get; set; }
        public string lineMainDescription { get; set; }
        public TBLXMLSCheckpdfMizancHK()
        {
            AccountMainID = "";
            AccountMainDescription = "";
            lineMainDescription = "";
        }

        public static List<TBLXMLSCheckpdfMizan> getlimited(List<TBLXMLSCheckpdfMizancHK> ndor)
        { 
            List<TBLXMLSCheckpdfMizan> nbi = ndor.Select(x => new TBLXMLSCheckpdfMizan()
            {
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                Amount1 = x.Amount1,
                Amount2 = x.Amount2,
                Amount3 = x.Amount3,
                Amount4 = x.Amount4, 
                PageID = x.pageID,
            }).ToList();
            return nbi;
        }
    }
}