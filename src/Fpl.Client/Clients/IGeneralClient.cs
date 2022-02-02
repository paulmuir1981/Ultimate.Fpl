using Fpl.Client.Models.General;

namespace Fpl.Client.Clients
{
    public interface IGeneralClient
    {
        ValueTask<Data> GetDataAsync(CancellationToken cancellationToken = default);
    }
}