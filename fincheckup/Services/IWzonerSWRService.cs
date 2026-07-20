using fincheckup.Models.NKolay.ENTITY.NwEntity;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using fincheckup.Models.NKolay.ViewM;

namespace fincheckup.Services
{ 
    public interface IWzonerSWRService
    {
        Task<IReadOnlyList<TBLErrzoneRow>> GetAllAsync(CancellationToken ct = default);
    }
}
