using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.EarlyWarning
{
    public class ReminderRuleJobHistory : BaseModel
    {
        public long ID { get; set; }
        public long ReminderRuleJobId { get; set; }
        public double ControlValue { get; set; }
        public double CalculateValue { get; set; }
        public double DifferentValue { get; set; }
        public double DifferentPercentage { get; set; }
        public string Explanation { get; set; }
        public bool IsNotify { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long SourceTableControlValueId { get; set; }
        public long SourceTableCalculateValueId { get; set; }
        public static IEnumerable<ReminderRuleJobHistory> Get_ReminderRuleJobHistory()
        {
            return StaticQuery<ReminderRuleJobHistory>("Select * From [ReminderRuleJobHistory]");
        }
        public static ReminderRuleJobHistory GetRow_ReminderRuleJobHistory(long _ID)
        {
            return StaticQuery<ReminderRuleJobHistory>("Select * From [ReminderRuleJobHistory] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_ReminderRuleJobHistory()
        {
            string sql = @"  INSERT INTO [ReminderRuleJobHistory]
          ( 
        [ReminderRuleJobId] ,
        [ControlValue] ,
        [CalculateValue] ,
        [DifferentValue] ,
        [DifferentPercentage] ,
        [Explanation] ,
        [IsNotify] ,
        [CreatedDate] ,
        [UpdatedDate] ,
        [SourceTableControlValueId] ,
        [SourceTableCalculateValueId] 
          ) 
           VALUES 
         ( 
        @ReminderRuleJobId ,
        @ControlValue ,
        @CalculateValue ,
        @DifferentValue ,
        @DifferentPercentage ,
        @Explanation ,
        @IsNotify ,
        @CreatedDate ,
        @UpdatedDate ,
        @SourceTableControlValueId ,
        @SourceTableCalculateValueId 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_ReminderRuleJobHistory()
        {
            try
            {
                string sql = "UPDATE   [ReminderRuleJobHistory] SET  [ReminderRuleJobId]=@ReminderRuleJobId , [ControlValue]=@ControlValue , [CalculateValue]=@CalculateValue , [DifferentValue]=@DifferentValue , [DifferentPercentage]=@DifferentPercentage , [Explanation]=@Explanation , [IsNotify]=@IsNotify , [CreatedDate]=@CreatedDate , [UpdatedDate]=@UpdatedDate , [SourceTableControlValueId]=@SourceTableControlValueId , [SourceTableCalculateValueId]=@SourceTableCalculateValueId  WHERE [ID]=@ID";
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
