using Fpl.Client.Models.General;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class GeneralClient : BaseClient, IGeneralClient
    {
        public GeneralClient(HttpClient client, ILogger<GeneralClient> logger = null) : base(client, logger) { }

        public ValueTask<Data> GetDataAsync(CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetDataAsync)} invoked");
            return GetAsync<Data>($"{BaseUri}bootstrap-static/", cancellationToken);
        }
    }
}