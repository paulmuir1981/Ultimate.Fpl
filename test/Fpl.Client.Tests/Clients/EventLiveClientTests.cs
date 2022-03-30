using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class EventLiveClientTests
    {
        private readonly IEventLiveClient _client;

        public EventLiveClientTests()
        {
            _client = new EventLiveClient(new HttpClient());
        }

        [Fact]
        public async Task GetEventLiveAsync_ReturnsOk()
        {
            var result = await _client.GetEventLiveAsync(1);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(39)]
        [InlineData(int.MaxValue)]
        public async Task GetEventLiveAsync_InvalidEventId_Throws(int eventId)
        {
            var result = await Assert.ThrowsAsync<ValidationException>(() => _client.GetEventLiveAsync(eventId).AsTask());
        }
    }
}