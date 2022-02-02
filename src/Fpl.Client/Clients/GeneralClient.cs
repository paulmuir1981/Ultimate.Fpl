using Fpl.Client.Models.General;
using Serilog;

namespace Fpl.Client.Clients
{
    public class GeneralClient : BaseClient, IGeneralClient
    {
        public GeneralClient(HttpClient client) : base(client, Log.ForContext<GeneralClient>()) { }

        public ValueTask<Data> GetDataAsync(CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetDataAsync)} invoked");
            return GetAsync<Data>($"{BaseUri}bootstrap-static/", cancellationToken);
        }
    }
}