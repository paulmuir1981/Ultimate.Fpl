using Fpl.Client.Models.General;
using Fpl.Client.Queries.General;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class GeneralClient : Client, IGeneralClient
    {
        public GeneralClient(HttpClient client, ILogger<GeneralClient> logger = null) : base(client, logger) { }

        public ValueTask<Data> GetDataAsync(CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetDataAsync)} invoked");
            return GetAsync(new GetDataQuery(), cancellationToken);
        }
    }
}