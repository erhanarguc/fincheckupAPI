using fincheckup.Models.EarlyWarning.Response;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.EarlyWarning
{
    public class ReminderRuleJob : BaseModel
    {
        public long ID { get; set; }
        public long CompanyId { get; set; }
        public long ReminderRuleId { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int Month { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompareScheduleDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public JobStatus JobStatus { get; set; }
        public string JobStatusText { get; set; }
        public static IEnumerable<ReminderRuleJob> Get_ReminderRuleJob()
        {
            return StaticQuery<ReminderRuleJob>("Select * From [ReminderRuleJob]");
        }
        public static ReminderRuleJob GetRow_ReminderRuleJob(long _ID)
        {
            return StaticQuery<ReminderRuleJob>("Select * From [ReminderRuleJob] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_ReminderRuleJob()
        {
            string sql = @"  INSERT INTO [ReminderRuleJob]
          ( 
        [CompanyId] ,
        [ReminderRuleId] ,
        [Year] ,
        [Quarter] ,
        [Month] ,
        [CreatedDate] ,
        [ScheduledDate] ,
        [CompareScheduleDate] ,
        [CompletedDate] ,
        [JobStatus] ,
        [JobStatusText] 
          ) 
           VALUES 
         ( 
        @CompanyId ,
        @ReminderRuleId ,
        @Year ,
        @Quarter ,
        @Month ,
        @CreatedDate ,
        @ScheduledDate ,
        @CompareScheduleDate ,
        @CompletedDate ,
        @JobStatus ,
        @JobStatusText 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            if (this.ID > 0)
            {
                  sql = "UPDATE   [ReminderRuleJob] SET  [CompanyId]=@CompanyId , [ReminderRuleId]=@ReminderRuleId , [Year]=@Year , [Quarter]=@Quarter , [Month]=@Month , [CreatedDate]=@CreatedDate , [ScheduledDate]=@ScheduledDate , [CompareScheduleDate]=@CompareScheduleDate , [CompletedDate]=@CompletedDate , [JobStatus]=@JobStatus , [JobStatusText]=@JobStatusText  WHERE [ID]=@ID";
            }


        
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_ReminderRuleJob()
        {
            try
            {
                string sql = "UPDATE   [ReminderRuleJob] SET  [CompanyId]=@CompanyId , [ReminderRuleId]=@ReminderRuleId , [Year]=@Year , [Quarter]=@Quarter , [Month]=@Month , [CreatedDate]=@CreatedDate , [ScheduledDate]=@ScheduledDate , [CompareScheduleDate]=@CompareScheduleDate , [CompletedDate]=@CompletedDate , [JobStatus]=@JobStatus , [JobStatusText]=@JobStatusText  WHERE [ID]=@ID";
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
