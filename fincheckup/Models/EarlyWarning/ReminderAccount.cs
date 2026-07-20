 
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;

namespace fincheckup.Models.EarlyWarning
{
    public enum AccountType
    {
        [Description("Revenue Main Account ID")] RevenueMainAccount = 1,
        [Description("Revenue Type ID")] RevenueType = 2,
        [Description("Balance Main Account ID")] BalanceMainAccount = 3,
        [Description("Balance Type ID")] BalanceType = 4
    }
    public class ReminderAccount : BaseModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int StartValue { get; set; }
        public int FinishValue { get; set; }
        public long AccountGroupId { get; set; }
        public AccountType AccountType { get; set; }
        public static IEnumerable<ReminderAccount> Get_ReminderAccount()
        {
            return StaticQuery<ReminderAccount>("Select * From [ReminderAccount]");
        }
        public static ReminderAccount GetRow_ReminderAccount(long _ID)
        {
            return StaticQuery<ReminderAccount>("Select * From [ReminderAccount] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_ReminderAccount()
        {
            string sql = @"  INSERT INTO [ReminderAccount]
          ( 
        [Name] ,
        [StartValue] ,
        [FinishValue] ,
        [AccountGroupId] ,
        [AccountType] 
          ) 
           VALUES 
         ( 
        @Name ,
        @StartValue ,
        @FinishValue ,
        @AccountGroupId ,
        @AccountType 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            if (this.ID>0)
            {
                sql = "UPDATE   [ReminderAccount] SET  [Name]=@Name , [StartValue]=@StartValue , [FinishValue]=@FinishValue , [AccountGroupId]=@AccountGroupId , [AccountType]=@AccountType  WHERE [ID]=@ID";
            }
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_ReminderAccount()
        {
            try
            {
                string sql = "UPDATE   [ReminderAccount] SET  [Name]=@Name , [StartValue]=@StartValue , [FinishValue]=@FinishValue , [AccountGroupId]=@AccountGroupId , [AccountType]=@AccountType  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
