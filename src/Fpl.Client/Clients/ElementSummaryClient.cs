using Fpl.Client.Models.ElementSummaries;
using Fpl.Client.Queries.ElementSummaries;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Fpl.Client.Clients
{
    public class ElementSummaryClient : Client, IElementSummaryClient
    {
        public ElementSummaryClient(HttpClient client, ILogger<ElementSummaryClient> logger = null) : base(client, logger) { }

        public async ValueTask<ElementSummary> GetElementSummaryAsync(int elementId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetElementSummaryAsync)} invoked");

            var query = new GetElementSummaryQuery { ElementId = elementId };
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(elementId);
                Exception exception = new ArgumentException($"{paramName} ({elementId}) does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }
    }
}
