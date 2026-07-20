using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class AppLogs : BaseModel
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public int LogTypeID { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public String Detail { get; set; }
        public static IEnumerable<AppLogs> Get_AppLogs()
        {
            return StaticQuery<AppLogs>("Select * From [AppLogs]");
        }
        public static AppLogs GetRow_AppLogs(int _ID)
        {
            return StaticQuery<AppLogs>("Select * From [AppLogs] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_AppLogs()
        {
            string sql = @"  INSERT INTO [AppLogs]
          ( 
        [UserID] ,
LogTypeID,
        [ActionDate] ,
        [Detail] 
          ) 
           VALUES 
         ( 
        @UserID ,
@LogTypeID,
        @ActionDate ,
        @Detail 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }


    }

}