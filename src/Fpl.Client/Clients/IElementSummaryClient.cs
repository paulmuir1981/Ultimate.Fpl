using Fpl.Client.Models.ElementSummaries;

namespace Fpl.Client.Clients
{
    public interface IElementSummaryClient
    {
        ValueTask<ElementSummary> GetElementSummaryAsync(int elementId, CancellationToken cancellationToken = default);
    }
}
