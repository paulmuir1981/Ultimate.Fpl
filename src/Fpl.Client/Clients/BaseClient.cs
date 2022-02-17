using FluentValidation;
using Fpl.Client.Queries;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fpl.Client.Clients
{
    public abstract class BaseClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };
        protected readonly ILogger _logger;

        protected BaseClient(HttpClient client, ILogger logger = null)
        {
            _client = client;
            _logger = logger;
        }

        protected async ValueTask<TValue> GetAsync<TQuery, TValue>(TQuery query, IValidator<TQuery> validator = null, CancellationToken cancellationToken = default) where TQuery : IQuery<TValue>
        {
            _logger?.LogInformation($"{nameof(GetAsync)} invoked");

            if (validator != null)
            {
                await validator.ValidateAndThrowAsync(query, cancellationToken);
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var stream = await _client.GetStreamAsync(query.RequestUri, cancellationToken);
            return await JsonSerializer.DeserializeAsync<TValue>(stream, _options, cancellationToken);
        }
    }
}