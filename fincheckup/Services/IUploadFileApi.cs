using CsvHelper.Configuration.Attributes;
using fincheckup.Models.DigiForm;
using Refit;
using System.Threading.Tasks;

namespace fincheckup.Services
{
    public interface IUploadFileApi
    {
        [Post("/api/Document/Upload")]
        Task<DigiGenericResult> UploadMizanFileAsync([Body] DigiRequestMizan request);

        [Post("/api/Document/Upload")]
        Task<DigiGenericResult> UploadBeyannameFileAsync([Body] DigiRequestBeyanname request);

        [Get("/api/Document/GetResult")]
        Task<DigiResponseMizan> GetMizanFileResultAsync([Query] int documentId);
    }
}
