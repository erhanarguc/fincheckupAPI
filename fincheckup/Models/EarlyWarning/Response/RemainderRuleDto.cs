using System;

namespace fincheckup.Models.EarlyWarning.Response
{
    public class RemainderRuleDto
    {
        public long ID { get; set; }
        public PeriodType PeriodType { get; set; }
        public string PeriodTypeText { get; set; }
        public double ControlValue { get; set; }
        public ControlValueType ControlValueType { get; set; }
        public string ControlValueTypeText { get; set; }
        public DateTime? LastGenerateDate { get; set; }
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public int StartValue { get; set; }
        public int FinishValue { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountTypeText { get; set; }
    }
}
