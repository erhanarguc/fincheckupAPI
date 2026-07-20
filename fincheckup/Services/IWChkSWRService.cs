using fincheckup.Models.NKolay.ENTITY.NwEntity;
using System.Threading.Tasks;
using System.Threading;
using fincheckup.Models.NKolay.ViewM;
using System.Collections.Generic;

namespace fincheckup.Services
{
    
    public interface IWChkSWRService
    {
        Task<IReadOnlyList<ErrorCheckSet>> GetAllAsync(CancellationToken ct = default);
    }
     
}
