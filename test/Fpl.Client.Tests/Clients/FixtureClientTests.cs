using Fpl.Client.Clients;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class FixtureClientTests
    {
        private readonly IFixtureClient _client;

        public FixtureClientTests()
        {
            _client = new FixtureClient(new HttpClient());
        }

        [Fact]
        public async Task GetAllFixturesAsync_ReturnsOk()
        {
            var result = await _client.GetFixturesAsync();

            Assert.NotNull(result);
            Assert.Equal(380, result.Count);
        }

        [Fact]
        public async Task GetFixturesAsync_ReturnsOk()
        {
            for (int eventId = 1; eventId <= 38; eventId++)
            {
                var result = await _client.GetFixturesAsync(eventId);
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(39)]
        [InlineData(int.MaxValue)]
        public async Task GetFixturesAsync_InvalidEventId_Throws(int eventId)
        {
            var result = await Assert.ThrowsAsync<ValidationException>(() => _client.GetFixturesAsync(eventId).AsTask());
        }

        [Fact]
        public async Task GetFutureFixturesAsync_ReturnsOk()
        {
            var result = await _client.GetFutureFixturesAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}