using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class EventStatusClientTests
    {
        private readonly IEventStatusClient _client;

        public EventStatusClientTests()
        {
            _client = new EventStatusClient(new HttpClient());
        }

        [Fact]
        public async Task GetDataAsync_ReturnsOk()
        {
            var result = await _client.GetEventStatusAsync();

            Assert.NotNull(result);
        }
    }
}