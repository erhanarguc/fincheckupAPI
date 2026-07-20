using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay
{
    public class ERRLOG : BaseModel
    {
        public int ID { get; set; }
        public string ERLOG { get; set; }
        public long CsvID { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }

        public static IEnumerable<ERRLOG> Get_AppLogs()
        {
            return StaticQuery<ERRLOG>("Select * From [LOGGER]");
        }
        public void Save_AppLogs()
        {
            string sql = @"  INSERT INTO [LOGGER]
          ( 
        [ERLOG] ,
         CsvID,
        [CompanyID]  
          ) 
           VALUES 
         ( 
        @ERLOG ,
         @CsvID,
        @CompanyID 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }
    }
}
