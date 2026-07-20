using fincheckup.Helper;
using fincheckup.Models.Requests;
using fincheckup.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace fincheckup.Models.Qnb
{
    public class QNBpayPaymentService
    {

        private static readonly HttpClient _httpClient;
        static QNBpayPaymentService()
        {
#if !NETSTANDARD
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif

            _httpClient = new HttpClient();
        }

        public static TokenResponse CreateToken(Settings settings)
        {
            TokenRequest tokenRequest = new TokenRequest();
            tokenRequest.AppID = settings.AppID;
            tokenRequest.AppSecret = settings.AppSecret;

            TokenResponse response = PostDataAsync<TokenResponse, TokenRequest>(settings.BaseUrl + "/api/token", tokenRequest);
            return response;
        }

        public static GetPosResponse GetPos(GetPosRequest request, Settings settings, string token)
        {

            request.MerchantKey = settings.MerchantKey;

            var header = new Dictionary<string, string>();
            header.Add("Authorization", "Bearer " + token);

            GetPosResponse response = PostDataAsync<GetPosResponse, GetPosRequest>(settings.BaseUrl + "/api/getpos", request, header);

            return response;
        }

        public static PaymentResponse Pay(PaymentRequest request, Settings settings, string token)
        {
            var header = new Dictionary<string, string>();
            header.Add("Authorization", "Bearer " + token);

            PaymentResponse response = PostDataAsync<PaymentResponse, PaymentRequest>(settings.BaseUrl + "/api/pay", request, header);

            return response;
        }

        public static SmartPaymentResponse SmartPay(SmartPaymentRequest request, Settings settings, string token)
        {
            var header = new Dictionary<string, string>();
            header.Add("Authorization", "Bearer " + token);

            SmartPaymentResponse response = PostDataAsync<SmartPaymentResponse, SmartPaymentRequest>(settings.BaseUrl + "/api/paySmart2D", request, header);

            return response;
        }


        public static BrandedPaymentResponse BrandedPay(BrandedPaymentRequest request, Settings settings)
        {
            var formDatas = new Dictionary<string, string>();
            formDatas.Add("currency_code", request.currency_code);
            formDatas.Add("invoice", JsonBuilder.SerializeToJsonString<Invoice>(request.invoice).ToString().Trim());
            formDatas.Add("merchant_key", request._settings.MerchantKey);
            formDatas.Add("name", request.name);
            formDatas.Add("surname", request.surname);

            BrandedPaymentResponse response = PostUrlEncodedDataAsync<BrandedPaymentResponse>(settings.BaseUrl + "/purchase/link", formDatas);

            return response;
        }

        public static GetOrderStatusResponse GetOrderStatus(GetOrderStatusRequest request, Settings settings)
        {
            var formDatas = new Dictionary<string, string>();
            formDatas.Add("merchant_key", request._settings.MerchantKey);
            formDatas.Add("invoice_id", request.invoice_id);

            GetOrderStatusResponse response = PostUrlEncodedDataAsync<GetOrderStatusResponse>(settings.BaseUrl + "/purchase/status", formDatas);

            return response;
        }

        public static RefundResponse Refund(RefundRequest request, Settings settings, string token)
        {
            var header = new Dictionary<string, string>();
            header.Add("Authorization", "Bearer " + token);

            RefundResponse response = PostDataAsync<RefundResponse, RefundRequest>(settings.BaseUrl + "/api/refund", request, header);

            return response;
        }

        //public static 3DPayResponse Initialize3DPay(3DPaymentRequest request, Settings settings)
        //{

        //    //var header = new Dictionary<string, string>();
        //    //header.Add("Authorization", "Bearer " + token);

        //    GetPosResponse response = PostDataAsync<3DPayResponse, 3DPaymentRequest>(settings.BaseUrl + "/getpos", request);

        //    return response;
        //}


        public static Response PostDataAsync<Response, Request>(string endPoint, Request dto, Dictionary<string, string> headers = null)
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endPoint),
                Content = JsonBuilder.ToJsonString<Request>(dto)
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            var httpResponse = _httpClient.SendAsync(requestMessage).Result;

            // GEÇİCİ
            var t = httpResponse.Content.ReadAsStringAsync().Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                return default;
            }


            return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        }

        public static Response GetDataAsync<Response>(string endPoint)
        {
            var httpResponse = _httpClient.GetAsync(endPoint).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        }

        public static Response PostUrlEncodedDataAsync<Response>(string endPoint, Dictionary<string, string> formDatas = null, Dictionary<string, string> headers = null)
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endPoint),
                Content = new FormUrlEncodedContent(formDatas)
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            var httpResponse = _httpClient.SendAsync(requestMessage).Result;

            // GEÇİCİ
            var t = httpResponse.Content.ReadAsStringAsync().Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                return default;
            }


            return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        }

    }
}
