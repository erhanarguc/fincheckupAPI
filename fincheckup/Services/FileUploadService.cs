using fincheckup.Models.DigiForm;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace fincheckup.Services
{
    public class FileUploadService
    {
        private readonly IUploadFileApi _uploadFileApi;
        private static readonly HttpClient _httpClient = new HttpClient();
        // Constructor injection of the Refit API interface
        public FileUploadService(IUploadFileApi uploadFileApi)
        {
            _uploadFileApi = uploadFileApi;
        }
        public async Task<DigiResponseMizan> GetDocumentResultAsync(int documentId)
        {
            try
            {
                // Build the request URL with the query parameter
                //string requestUrl = $"http://51.12.208.191:200/api/Document/GetResult?documentId={documentId}";

                //// Send the GET request
                //HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                //// Ensure successful status code
                //response.EnsureSuccessStatusCode();

                //// Read the response content as a string
                //string result = await response.Content.ReadAsStringAsync();

                var response = await _uploadFileApi.GetMizanFileResultAsync(documentId);

                // Return the response
                return response;

                //return result;
            }
            catch (HttpRequestException ex)
            {
                // Handle errors in making the request
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other types of errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        // Method to upload a file
        public async Task<DigiGenericResult> UploadFileMizanAsync(DigiRequestMizan request)
        {
            try
            {

                // Call the API
                var response = await _uploadFileApi.UploadMizanFileAsync(request);

                // Return the response
                return response;
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., network issues)
                return new DigiGenericResult { ResultCode = 1, ResultMessage = ex.Message };
            }
        }

        public async Task<DigiGenericResult> UploadFileBeyannameAsync(DigiRequestBeyanname request)
        {
            try
            {

                // Call the API
                var response = await _uploadFileApi.UploadBeyannameFileAsync(request);

                // Return the response
                return response;
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., network issues)
                return new DigiGenericResult { ResultCode = 1, ResultMessage = ex.Message };
            }
        }

        public async Task<DigiResponseMizan> GetMizanResultAsync(int documentId)
        {
            try
            {

                // Call the API
                var response = await _uploadFileApi.GetMizanFileResultAsync(documentId);

                // Return the response
                return response;
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., network issues)
                return new DigiResponseMizan();
            }
        }
    }
}
