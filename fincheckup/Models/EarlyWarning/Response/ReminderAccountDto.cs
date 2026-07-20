using Newtonsoft.Json;
using System.ComponentModel;

namespace fincheckup.Models.EarlyWarning.Response
{
    
    public class ReminderAccountDto
    {
        [JsonProperty(PropertyName = "id")]
        public long ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "startValue")]
        public int StartValue { get; set; }
        [JsonProperty(PropertyName = "finishValue")]
        public int FinishValue { get; set; }
        [JsonProperty(PropertyName = "accountGroupId")]
        public int AccountGroupId { get; set; }
        [JsonProperty(PropertyName = "accountGroupName")]
        public string AccountGroupName { get; set; }
        [JsonProperty(PropertyName = "accountType")]
        public AccountType AccountType { get; set; }
        [JsonProperty(PropertyName = "accountTypeText")]
        public string AccountTypeText { get; set; }
    }
    public class ReturnToken
    {
        [JsonProperty(PropertyName = "success")]
        public long success { get; set; }
        [JsonProperty(PropertyName = "responseMessage")]
        public string responseMessage { get; set; }

    }

    public class ReturnMainEledger
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object payload { get; set; }
        public object transactionId { get; set; }
    }

    public class ReturnMainPDF
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object payload { get; set; } 
    }

    public class ReminderAccountPost
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "startValue")]
        public int startValue { get; set; }
        [JsonProperty(PropertyName = "finishValue")]
        public int finishValue { get; set; }
        [JsonProperty(PropertyName = "accountGroupId")]
        public int accountGroupId { get; set; }
        [JsonProperty(PropertyName = "accountType")]
        public AccountType accountType { get; set; }
    }

    public class ReminderAccountPut
    {
        [JsonProperty(PropertyName = "id")]
        public long id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "startValue")]
        public int startValue { get; set; }
        [JsonProperty(PropertyName = "finishValue")]
        public int finishValue { get; set; }
        [JsonProperty(PropertyName = "accountGroupId")]
        public int accountGroupId { get; set; }
        [JsonProperty(PropertyName = "accountType")]
        public AccountType accountType { get; set; }
    }
}
