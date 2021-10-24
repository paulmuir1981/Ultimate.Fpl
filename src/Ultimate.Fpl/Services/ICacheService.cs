using System.Threading;
using System.Threading.Tasks;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Services
{
    public interface ICacheService
    {
        Task SetDataAsync(Data data, CancellationToken cancellationToken = default);
        Task<Data> GetDataAsync(CancellationToken cancellationToken = default);
    }
}