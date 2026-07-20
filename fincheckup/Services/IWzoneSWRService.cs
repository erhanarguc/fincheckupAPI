using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using fincheckup.Models.NKolay.ENTITY.NwEntity;

namespace fincheckup.Services
{
    public interface IWzoneSWRService
    {
        Task<IReadOnlyList<WzoneRow>> GetAllAsync(CancellationToken ct = default);
    }
}
