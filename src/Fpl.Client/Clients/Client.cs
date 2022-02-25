using Fpl.Client.Queries;
using Fpl.Client.Validation;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fpl.Client.Clients
{
    public abstract class Client
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };
        protected readonly ILogger _logger;

        protected Client(HttpClient client, ILogger logger = null)
        {
            _client = client;
            _logger = logger;
        }
        protected static void Validate(IValidations validations)
        {
            validations.Validate();
        }

        protected async ValueTask<TResponse> GetAsync<TResponse>(IQuery query, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetAsync)} invoked");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var stream = await _client.GetStreamAsync(query.Uri, cancellationToken);
            return await JsonSerializer.DeserializeAsync<TResponse>(stream, _options, cancellationToken);
        }
    }
}