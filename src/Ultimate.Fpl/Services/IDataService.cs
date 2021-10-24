using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Services
{
    public interface IDataService
    {
        Task<List<Player>> GetPlayersAsync(CancellationToken cancellationToken = default);
    }
}
