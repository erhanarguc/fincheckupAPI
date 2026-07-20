using fincheckup.Models.NKolay.ENTITY.NwEntity;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace fincheckup.Services
{ 
    public interface IWChkWordSWRService
    {
        Task<IReadOnlyList<TBLErrzoneInsideWordRow>> GetAllAsync(CancellationToken ct = default);
    }
    
}
