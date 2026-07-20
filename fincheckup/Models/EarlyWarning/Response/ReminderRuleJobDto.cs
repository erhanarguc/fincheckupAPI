using System;
using System.ComponentModel;

namespace fincheckup.Models.EarlyWarning.Response
{
    public enum JobStatus
    {
        [Description("Oluşturuldu")] Created = 1,
        [Description("Çalışıyor")] Processing = 2,
        [Description("Tamamlandı")] Completed = 3,
        [Description("Tekrarlanacak")] Retried = 4
    }
    public enum PeriodType
    {
        [Description("Monthly")] Monthly = 1,
        [Description("Quarterly")] Quarterly = 2,
        [Description("Yearly")] Yearly = 3
    }
    public enum ControlValueType
    {
        [Description("Artmıştır")] Increment = 1,
        [Description("Azalmıştır")] Decrease = 2
    }
    public class ReminderRuleJobDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public long ReminderRuleId { get; set; }
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public long AccountGroupId { get; set; }
        public string AccountGroupName { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountTypeText { get; set; }
        public PeriodType PeriodType { get; set; }
        public string PeriodTypeText { get; set; }
        public double ControlValue { get; set; }
        public ControlValueType ControlValueType { get; set; }
        public string ControlValueTypeText { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int Month { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompareScheduleDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public JobStatus JobStatus { get; set; }
        public string JobStatusText { get; set; }
    }
}
