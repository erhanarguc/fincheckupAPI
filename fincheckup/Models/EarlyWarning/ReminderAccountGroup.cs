using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;
using System;

namespace fincheckup.Models.EarlyWarning
{
    public class ReminderAccountGroup : BaseModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public static IEnumerable<ReminderAccountGroup> Get_ReminderAccountGroup()
        {
            return StaticQuery<ReminderAccountGroup>("Select * From [ReminderAccountGroup]");
        }
        public static ReminderAccountGroup GetRow_ReminderAccountGroup(long _ID)
        {
            return StaticQuery<ReminderAccountGroup>("Select * From [ReminderAccountGroup] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_ReminderAccountGroup()
        {

            string sql = @"  INSERT INTO [ReminderAccountGroup]
          ( 
        [Name] 
          ) 
           VALUES 
         ( 
        @Name 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            if (this.ID > 0) { sql = "UPDATE   [ReminderAccountGroup] SET  [Name]=@Name  WHERE [ID]=@ID"; }

            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_ReminderAccountGroup()
        {
            try
            {
                string sql = "UPDATE   [ReminderAccountGroup] SET  [Name]=@Name  WHERE [ID]=@ID";
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