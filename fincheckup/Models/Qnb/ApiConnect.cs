using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace fincheckup.Models.Qnb
{
    public class ApiConnect
    {
#pragma warning disable CS0414 // The field 'ApiConnect.apiurl' is assigned but its value is never used
        private string apiurl;
#pragma warning restore CS0414 // The field 'ApiConnect.apiurl' is assigned but its value is never used
        public ApiConnect()
        {

            //saveSubmissionPermission
            //checkSubmission
            apiurl = "https://edeftertest.efinans.com.tr/edefter/api/gen/";
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<GetTokenResponse> GetTokenAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            LoginInputModel login = new LoginInputModel("fincheckup-YKyPVreLAchaZW6D2Cd", "cAJPu2jB5RMCbYWra4qsTtZnGDpLyNH8ge7k6VSx", "password", "fincheckup.entegrasyon", "H6MjuGYu");
            string jsonBody = System.Text.Json.JsonSerializer.Serialize<LoginInputModel>(login);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://edefter.efinans.com.tr/edefter/api/auth/getToken");

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

            var user = JsonConvert.DeserializeObject<GetTokenResponse>(rezzo);

            return user;
        }

        public async Task<SubmissionResponse> GetcheckSubmission(SubmissionModel TckVkn)
        {
            GetTokenResponse token;
            //var client = new HttpClient();
            token = await GetTokenAsync();

            string jsonBody = System.Text.Json.JsonSerializer.Serialize<SubmissionModel>(TckVkn);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://edefter.efinans.com.tr/edefter/api/gen/checkSubmission");
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.accessToken);
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

            var user = JsonConvert.DeserializeObject<SubmissionResponse>(rezzo);


            return user;


        }

        public async Task<SubmissionResponse> GetsaveSubmissionPermission(SubmissionModelT TckVkn)
        {
            GetTokenResponse token;
            //var client = new HttpClient();
            token = await GetTokenAsync();
            if (TckVkn.vknTckn == null || TckVkn.vknTckn == string.Empty)
            {
                TckVkn.vknTckn = "25174530344";

            }
            string jsonBody = System.Text.Json.JsonSerializer.Serialize<SubmissionModelT>(TckVkn);


            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://edefter.efinans.com.tr/edefter/api/gen/saveSubmissionPermission");
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.accessToken);
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

            var user = JsonConvert.DeserializeObject<SubmissionResponse>(rezzo);



            return user;

        }
    }
}
