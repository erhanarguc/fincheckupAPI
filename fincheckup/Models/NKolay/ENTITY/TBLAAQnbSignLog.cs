using System;
using System.Collections.Generic;
using System.Linq;


namespace fincheckup.ENTITY
{
    public class TBLAAQnbSignLog : BaseModel
    {
        public TBLAAQnbSignLog() { }

        public int ID { get; set; }
        public long UserID { get; set; }
        public long CompanyID { get; set; }
        public int CompanyEntegratorID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte IsDeclined { get; set; }
        public DateTime? DeclinedDate { get; set; }
        public long? DeclinedUserID { get; set; }
        public string EntegratorCompanyName { get; set; }
        public byte IsDeclinedBank { get; set; }
        public DateTime? DeclinedDateBank { get; set; }
        public long? DeclinedUserIDBank { get; set; }
        public byte IsForBankToo { get; set; }

        public TBLAAQnbSignLog(long userID, long companyID, int companyEntegratorID, DateTime createdDate, DateTime startDate, DateTime endDate, byte isDeclined, DateTime? declinedDate, long? declinedUserID, byte isDeclinedBank, DateTime? declinedDateBank, long? declinedUserIDBank, byte isForBankToo)
        {
            UserID = userID;
            CompanyID = companyID;
            CompanyEntegratorID = companyEntegratorID;
            CreatedDate = createdDate;
            StartDate = startDate;
            EndDate = endDate;
            IsDeclined = isDeclined;
            DeclinedDate = declinedDate;
            DeclinedUserID = declinedUserID;
            IsDeclinedBank = isDeclinedBank;
            DeclinedDateBank = declinedDateBank;
            DeclinedUserIDBank = declinedUserIDBank;
            IsForBankToo = isForBankToo;
        }

        public static TBLAAQnbSignLog Get_TBLAAQnbSignLogRow(long Id)
        {
            return StaticQuery<TBLAAQnbSignLog>("Select * From [TBLAAQnbSignLog] where ID=@ID ", new { ID = Id }).FirstOrDefault();
        }
        public static IEnumerable<TBLAAQnbSignLog> Get_TBLAAQnbSignLog(long companyID)
        {
            return StaticQuery<TBLAAQnbSignLog>("Select * From [TBLAAQnbSignLog] where CompanyID=@ID and IsDeclined=0", new { ID = companyID });
        }
        public static IEnumerable<TBLAAQnbSignLog> Get_All()
        {
            string sql = @"SELECT TOP (1000) t.*
,y.CompanyName as EntegratorCompanyName 
            FROM[EDEFTERDB].[dbo].[TBLAAQnbSignLog] t LEFT JOIN CompanyEntegrator y on t.CompanyEntegratorID = y.ID";


            return StaticQuery<TBLAAQnbSignLog>(sql);
        }
        public void Save_TBLAAQnbSignLog()
        {
            string sql = @" 
IF NOT EXISTS
(
  SELECT
    *
  FROM
   [TBLAAQnbSignLog]
  WHERE
    CompanyID = @CompanyID AND
    CompanyEntegratorID =@CompanyEntegratorID and IsDeclined=0   
)
BEGIN 
INSERT INTO [TBLAAQnbSignLog]
        (UserID,CompanyID,CompanyEntegratorID,StartDate,EndDate) 
           VALUES 
         (@UserID,@CompanyID,@CompanyEntegratorID,@StartDate,@EndDate)  ;select  Cast(SCOPE_IDENTITY() as Bigint) END ELSE  BEGIN  UPDATE [TBLAAQnbSignLog] SET 
         StartDate=@StartDate,EndDate=@EndDate    WHERE CompanyID = @CompanyID AND
    CompanyEntegratorID =@CompanyEntegratorID END";

            this.ID = Query<int>(sql, this).FirstOrDefault();
        }
        public void Update_TBLAAQnbSignLog()
        {
            string sql = @"UPDATE [TBLAAQnbSignLog] SET 
         StartDate=@StartDate,EndDate=@EndDate,IsDeclined=@IsDeclined,DeclinedDate=@DeclinedDate,DeclinedUserID=@DeclinedUserID  ,DeclinedDateBank=@DeclinedDateBank,IsDeclinedBank=@IsDeclinedBank,DeclinedUserIDBank=@DeclinedUserIDBank ,IsForBankToo=@IsForBankToo WHERE [ID]=@ID";

            Query<int>(sql, this).FirstOrDefault();
        }


    }

}