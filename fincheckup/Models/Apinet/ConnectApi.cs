using fincheckup.Controllers;
using fincheckup.Models.EarlyWarning.Response;
using fincheckup.Models.NKolay.json;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using DevExpress.XtraPrinting.Native.Properties;
using fincheckup.Helper;
using System.Text;
using Azure.Core;


namespace fincheckup.Models.Apinet
{
    public class ConnectApi
    {
        private string apiurl;
        public ConnectApi()
        {

            //saveSubmissionPermission
            //checkSubmission
            //apiurl = "http://185.201.213.227/";   
            apiurl = "http://localhost:43371/";
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ReturnToken> GetAccount()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string usrname = "nefdev";
            string pass = "Nef2021***";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "Login/Login?UserName=" + usrname + "&Password=" + pass);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReturnToken>(rezzo);

            return reminderAccount;
        }
        public async Task<ReturnMainEledger> SavePermission(ApiCompany npar)
        {
            ReturnToken token;
            string rezzo = "";
            //var client = new HttpClient();
            token = await GetAccount();
            npar.permissionTargetCode = "us";
            HttpResponseMessage nmes = new HttpResponseMessage();


            var respbearere = token.responseMessage;




            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiurl + "Permission/accessConfirmation");

            request.Headers.Add("accept", "text/plain");
            request.Headers.Add("Authorization", "Bearer "+ respbearere);
            string abba = JsonConvert.SerializeObject(npar);
            request.Content = new StringContent(abba);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            var reminderAccount = JsonConvert.DeserializeObject<ReturnMainEledger>(responseBody);

            return reminderAccount;






            ////using (var client = new HttpClient())
            ////{
            ////    var uri = new Uri(apiurl + "Permission/accessConfirmation");
            ////    var json = JsonConvert.SerializeObject(npar);
            ////    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + respbearere);
            ////    var stringContent = new StringContent(json, Encoding.UTF8, "text/plain");
            ////    nmes = await client.PostAsync(uri, stringContent);
            ////    // ...
            ////}
            ////if (nmes.IsSuccessStatusCode)
            ////{
            ////     rezzo= nmes.Content.ReadAsStringAsync().Result;
            ////}
  
            ////var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "Permission/accessConfirmation");
            ////httpWebRequest.Headers.Add("Authorization", "Bearer " + token.responseMessage);
            ////httpWebRequest.ContentType = "application/json";
            ////httpWebRequest.Method = "POST";
            ////var jsonObj = JsonConvert.SerializeObject(npar);
            ////using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            ////{
            ////    //string json = "{\"user\":\"test\"," +
            ////    //              "\"password\":\"bla\"}";

            ////    streamWriter.Write(jsonObj);
            ////    streamWriter.Flush();
            ////    streamWriter.Close();
            ////}

            ////var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            ////using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            ////{
            ////    rezzo = streamReader.ReadToEnd();
            ////}
            //////var reminderAccount = JsonConvert.DeserializeObject<ReturnMainEledger>(rezzo);

            //return reminderAccount;
        }
        public async Task<ReturnMainEledger> GetEledger(FinansmanEntegrasyonCs npar,string target)
        {
            ReturnToken token;
            //var client = new HttpClient();
            token = await GetAccount();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "ELedger/GetAllEledgerlist?CompanyPortalUser=" + npar.kulaniciKodu + "&CompanyPortalPassword=" + npar.password + "&Identifier=" + npar.vknTckn + "&BranchId=" + "0" + "&StartDate=" + "2023-06-06" + "&EndDate=" + "2024-03-03" + "&PermissionTargetCode="+ target);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.responseMessage);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReturnMainEledger>(rezzo);

            return reminderAccount;
        }
        public async Task<ReturnMainEledger> CancelEledgerPermission(FinansmanEntegrasyonCs npar)
        {
            ReturnToken token;
            //var client = new HttpClient();
            token = await GetAccount();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "Permission/aceessCancel?taxNumber=" + npar.vknTckn + "&documentType=" + "0" +  "&PermissionTargetCode=us");
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token.responseMessage);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            string rezzo = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                rezzo = streamReader.ReadToEnd();
            }

            var reminderAccount = JsonConvert.DeserializeObject<ReturnMainEledger>(rezzo);

            return reminderAccount;
        }
        public async Task<string> SendApi(XMlook pageIndex,string filepath)
        {
            ReturnToken token;
            //var client = new HttpClient();
            token = await GetAccount();

            string returnString = "";

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://185.201.213.227/");
            //     client.DefaultRequestHeaders.Accept.Clear();


            //    //client.DefaultRequestHeaders.Clear();
            //    //client.DefaultRequestHeaders..Add("Content-Type", "multipart/form-data");
            //    //client.DefaultRequestHeaders.Add("accept", "text/plain");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain")); 
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  token.responseMessage);

            //    //string filepath = "C:/Users/Popper/Desktop/Stackoverflow/MatchPositions.PNG";
            //    string filename = "@12345678-2023.pdf";

            //  //  MultipartFormDataContent content = new MultipartFormDataContent();
            //  //  ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filepath));
            //  //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
            //  //  content.Add(fileContent, filename);


            //    //var content = new MultipartFormDataContent();
            //    //var fileContent = new StreamContent(pageIndex.file[0].OpenReadStream());
            //    //fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(pageIndex.file[0].ContentType);

            //    //content.Add(pageIndex.file[0], "File", filename);




            //    //content.Add(fileContent, "File", filename);

            //    //HttpResponseMessage response = await _httpClient.PostAsync(serviceMethod, content);
            //    //HttpResponseMessage response = await client.PostAsync("Pdf/UploadPdf", content);
            //    //returnString = await response.Content.ReadAsStringAsync();
            //}

            //HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(10);
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://185.201.213.227/Pdf/UploadPdf"))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "text/plain");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token.responseMessage);

                        var multipartContent = new MultipartFormDataContent();
                        var file1 = new ByteArrayContent(File.ReadAllBytes(filepath));
                        file1.Headers.Add("Content-Type", "application/pdf");
                        multipartContent.Add(file1, "File", Path.GetFileName(filepath));
                        request.Content = multipartContent;

                        var response = await httpClient.SendAsync(request);
                        returnString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var tt = ex;
                throw;
            }
           

            var chk = returnString;

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl + "/Pdf/UploadPdf");
            //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.responseMessage); 
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST"; 
            //string rezzo = string.Empty;
            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    rezzo = streamReader.ReadToEnd();
            //}

            //var reminderAccount = JsonConvert.DeserializeObject<ReturnMainEledger>(rezzo);

            return returnString;
        }

        public async Task<string> getFileApi(string filename)
        {
            ReturnToken token; 
            token = await GetAccount();

            string returnString = "";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://185.201.213.227/Pdf/DownloadPdf?File=" + filename))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "text/plain");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token.responseMessage);

                        var response = await httpClient.SendAsync(request);
                        returnString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var tt = ex;
                throw;
            }
        

            var chk = returnString;

          

            return returnString;
        }
        //GetAllEledgerlist?CompanyPortalUser=SgeMuhendislik_WebServis&CompanyPortalPassword=n1oWjOsd&Identifier=3526532235&BranchId=0&StartDate=2022-01-01&EndDate=2022-03-31&PermissionTargetCode=us
    }
}
