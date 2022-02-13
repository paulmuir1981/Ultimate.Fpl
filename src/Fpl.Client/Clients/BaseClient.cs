using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fpl.Client.Clients
{
    public abstract class BaseClient
    {
        protected const string BaseUri = "https://fantasy.premierleague.com/api/";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };
        protected readonly ILogger _logger;

        protected BaseClient(HttpClient client, ILogger logger = null)
        {
            _client = client;
            _logger = logger;
        }

        protected async ValueTask<TValue> GetAsync<TValue>(string requestUri, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetAsync)} invoked");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var stream = await _client.GetStreamAsync(requestUri, cancellationToken);
            return await JsonSerializer.DeserializeAsync<TValue>(stream, _options, cancellationToken);
        }
    }
}