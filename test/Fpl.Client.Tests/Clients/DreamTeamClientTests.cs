using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class DreamTeamClientTests
    {
        private readonly IDreamTeamClient _client;

        public DreamTeamClientTests()
        {
            _client = new DreamTeamClient(new HttpClient());
        }

        [Fact]
        public async Task GetDreamTeamAsync_ReturnsOk()
        {
            var result = await _client.GetDreamTeamAsync(1);
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
            var result = await Assert.ThrowsAsync<ValidationException>(() => _client.GetDreamTeamAsync(eventId).AsTask());
        }
    }
}