using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class H2hLeagueClientTests
    {
        private readonly IH2hLeagueClient _client;

        public H2hLeagueClientTests()
        {
            _client = new H2hLeagueClient(new HttpClient());
        }

        [Fact]
        public async Task GetH2hLeagueAsync_ReturnsOk()
        {
            var result = await _client.GetH2hLeagueAsync(5389);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetH2hLeagueAsync_BadLeague_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetH2hLeagueAsync(9999999).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetH2hLeagueAsync_InvalidLeague_Throws(int leagueId)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetH2hLeagueAsync(leagueId).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetH2hLeagueAsync_InvalidPage_Throws(int page)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetH2hLeagueAsync(5389, page).AsTask());
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetH2hLeagueAsync(5389, 1, page).AsTask());
        }

        [Fact]
        public async Task GetH2hMatchesAsync_ReturnsOk()
        {
            var result = await _client.GetH2hMatchesAsync(5389);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetH2hMatchesAsync_BadLeague_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetH2hMatchesAsync(9999999).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetH2hMatchesAsync_InvalidLeague_Throws(int leagueId)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetH2hMatchesAsync(leagueId).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetH2hMatchesAsync_InvalidPage_Throws(int page)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetH2hMatchesAsync(5389, page).AsTask());
        }

        [Fact]
        public async Task GetH2hMatchesAsync_EventNotNull_ReturnsOk()
        {
            for (int eventId = 1; eventId <= 38; eventId++)
            {
                var result = await _client.GetH2hMatchesAsync(5389, 1, eventId);
                Assert.NotNull(result);
                Assert.NotEmpty(result.Results);
            }
        }
    }
}