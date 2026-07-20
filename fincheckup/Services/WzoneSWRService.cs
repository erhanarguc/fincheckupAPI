using System.Collections.Concurrent;
using Dapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Data.SqlClient; 
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;
using fincheckup.Models;
using fincheckup.Models.NKolay.ENTITY.NwEntity;

namespace fincheckup.Services;
public sealed class WzoneSWRService: IWzoneSWRService
{
    private readonly IMemoryCache _cache;
    private readonly string _connStr;

  
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> Locks = new();

    private const string CacheKey = "wzone:all";


    private static readonly TimeSpan HardTtl = TimeSpan.FromDays(7);
    private static readonly TimeSpan SoftTtl = TimeSpan.FromMinutes(30);  
    private static readonly TimeSpan RefreshBackoff = TimeSpan.FromSeconds(15); 

    private sealed class Container
    {
        public IReadOnlyList<WzoneRow> Data { get; init; } = Array.Empty<WzoneRow>();
        public DateTimeOffset LoadedAt { get; init; }
        public DateTimeOffset ExpiresAt { get; init; }
        public DateTimeOffset NextRefreshNotBefore { get; set; }
        public volatile bool RefreshInProgress;
    }

    public WzoneSWRService(IMemoryCache cache)
    {
        _cache = cache;
        _connStr =Database.ConnectionString;
    }

  
    public async Task<IReadOnlyList<WzoneRow>> GetAllAsync(CancellationToken ct = default)
    {
        if (_cache.TryGetValue(CacheKey, out Container? c))
        {
     
            if (DateTimeOffset.UtcNow >= c.ExpiresAt)
                return (await LoadWithLockAsync(ct)).Data;

          
            if (DateTimeOffset.UtcNow - c.LoadedAt >= SoftTtl)
                TriggerBackgroundRefresh(c);

            return c.Data;
        }

   
        return (await LoadWithLockAsync(ct)).Data;
    }
     
    public async Task ReloadAsync(CancellationToken ct = default)
    {
        var sem = Locks.GetOrAdd(CacheKey, _ => new SemaphoreSlim(1, 1));
        await sem.WaitAsync(ct);
        try
        {
            var rows = await ReadRows(ct);
            if (rows.Count == 0 && _cache.TryGetValue(CacheKey, out Container? existing))
            {
            
                _cache.Set(CacheKey, existing);
                return;
            }

            var container = BuildContainer(rows, DateTimeOffset.UtcNow);
            _cache.Set(CacheKey, container);
        }
        finally { sem.Release(); }
    }

 

    private async Task<Container> LoadWithLockAsync(CancellationToken ct)
    {
        var sem = Locks.GetOrAdd(CacheKey, _ => new SemaphoreSlim(1, 1));
        await sem.WaitAsync(ct);
        try
        {
             
            if (_cache.TryGetValue(CacheKey, out Container? ready) && DateTimeOffset.UtcNow < ready.ExpiresAt)
                return ready;

            var rows = await ReadRows(ct);

         
            if (rows.Count == 0 && _cache.TryGetValue(CacheKey, out Container? existing))
                return existing;

            var container = BuildContainer(rows, DateTimeOffset.UtcNow);
            _cache.Set(CacheKey, container);
            return container;
        }
        finally { sem.Release(); }
    }

    private void TriggerBackgroundRefresh(Container current)
    {
        var now = DateTimeOffset.UtcNow;
        if (current.RefreshInProgress || now < current.NextRefreshNotBefore) return;

        current.RefreshInProgress = true;
        current.NextRefreshNotBefore = now + RefreshBackoff;

        _ = Task.Run(async () =>
        {
            try
            {
                var rows = await ReadRows(CancellationToken.None);
                if (rows.Count == 0) { current.RefreshInProgress = false; return; }  

                var fresh = BuildContainer(rows, DateTimeOffset.UtcNow);
                _cache.Set(CacheKey, fresh );
            }
            catch
            {
               
            }
            finally
            {
                current.RefreshInProgress = false;
            }
        });
    }

    private async Task<List<WzoneRow>> ReadRows(CancellationToken ct)
    {
        using var con = new SqlConnection(_connStr);
        try
        {
            var list = (await con.QueryAsync<WzoneRow>(
      "SELECT ID, MainDescriptionID, MainDescription FROM dbo.TBLWzone WITH (NOLOCK)")).ToList();

            return list;
        }
        catch (Exception ex)
        {
            var ttt = ex;
            return null;
        }
  
    }

    private static Container BuildContainer(List<WzoneRow> rows, DateTimeOffset now) => new()
    {
        Data = rows,
        LoadedAt = now,
        ExpiresAt = now + HardTtl,
        NextRefreshNotBefore = now + RefreshBackoff,
        RefreshInProgress = false
    };
}


