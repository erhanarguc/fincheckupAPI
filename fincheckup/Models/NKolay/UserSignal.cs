using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class UserSignal : BaseModel
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public string UserSignalID { get; set; }
        public bool IsActive { get; set; }

        public static IEnumerable<UserSignal> Get_All()
        {
            return StaticQuery<UserSignal>("Select * From [UserSignal]");
        }
        public bool Update_ToNonActive()
        {
            try
            {
                string sql = "UPDATE   [UserSignal] SET  [IsActive]=0    WHERE [UserID]=@UserID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool Update_ToActive()
        {
            try
            {
                string sql = "UPDATE   [UserSignal] SET  [IsActive]=1    WHERE [UserID]=@UserID and UserSignalID=@UserSignalID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public void Save_()
        {



            var usr = UserSignal.Get_All().Where(x => x.UserSignalID.Trim() == this.UserSignalID.Trim()).ToList();

            if (usr.Count() < 1)
            {
                Update_ToNonActive();
                string sql = @"  INSERT INTO [UserSignal]
          ( 
        [UserID] ,
        [UserSignalID] ,
        [IsActive] 
          ) 
           VALUES 
         ( 
        @UserID ,
        @UserSignalID ,
        1 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
                this.ID = Query<int>(sql, this).FirstOrDefault();
            }
            else
            {
                Update_ToNonActive();
                Update_ToActive();
            }



        }

    }
}