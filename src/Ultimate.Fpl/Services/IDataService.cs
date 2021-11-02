using System.Threading;
using System.Threading.Tasks;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Services
{
    public interface IDataService
    {
        Task<Data> GetAsync(CancellationToken cancellationToken = default);
    }
}
