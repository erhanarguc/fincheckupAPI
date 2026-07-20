using fincheckup.Models.EarlyWarning.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace fincheckup.Models.EarlyWarning
{
    public class ApiWarnConnect
    {
        HttpClient client;
        private string apiurl;
        public ApiWarnConnect()
        {
            client = new HttpClient();
            apiurl = "http://localhost:1903/";
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<List<ReminderAccountDto>> GetAccountList()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccountlist = JsonConvert.DeserializeObject<List<ReminderAccountDto>>(rezzo);

            return reminderAccountlist;
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ReminderAccountDto> GetAccount(int accountIde)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account/id/" + accountIde.ToString());

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReminderAccountDto>(rezzo);

            return reminderAccount;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<List<ReminderAccountDto>> GetAccountListbyGroupId(int accountGroupIde)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account/account-group/id/" + accountGroupIde.ToString());

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccountlist = JsonConvert.DeserializeObject<List<ReminderAccountDto>>(rezzo);

            return reminderAccountlist;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<List<ReminderAccountDto>> GetAccountListbyTypeId(AccountType accountTypeIde)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            int st = (int)accountTypeIde;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account/account-type/" + st.ToString());

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccountlist = JsonConvert.DeserializeObject<List<ReminderAccountDto>>(rezzo);

            return reminderAccountlist;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ReminderAccountDto> PostAccount(ReminderAccountPost account_)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            string jsonBody = System.Text.Json.JsonSerializer.Serialize<ReminderAccountPost>(account_);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonBody;

                streamWriter.Write(json);
            }
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReminderAccountDto>(rezzo);

            return reminderAccount;
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ReminderAccountDto> PutAccount(ReminderAccountPut account_)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            string jsonBody = System.Text.Json.JsonSerializer.Serialize<ReminderAccountPut>(account_);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonBody;

                streamWriter.Write(json);
            }
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReminderAccountDto>(rezzo);

            return reminderAccount;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> GetAccountGroupList()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {


            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "api/account-group");

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //	string json = jsonBody;

            //	streamWriter.Write(json);
            //}
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var user = JsonConvert.DeserializeObject<string>(rezzo);

            return user;
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> GetLevelList()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //var uric = ApiHelper.ToUrl(levelListModel, RunTimeSetting.BaseJackpoaApiUrl + ApiConstants.LevelListUriV1);
            //HttpResponseMessage response = await client.GetAsync(uric);
            //if (!response.IsSuccessStatusCode) { return  "NOK" ; }
            //var result = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<string>(result);
            return string.Empty;
        }

    }
}
