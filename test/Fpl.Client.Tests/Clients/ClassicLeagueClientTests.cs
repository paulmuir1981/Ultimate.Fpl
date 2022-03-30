using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class ClassicLeagueClientTests
    {
        private readonly IClassicLeagueClient _client;

        public ClassicLeagueClientTests()
        {
            _client = new ClassicLeagueClient(new HttpClient());
        }

        [Fact]
        public async Task GetClassicLeagueAsync_ReturnsOk()
        {
            var result = await _client.GetClassicLeagueAsync(361);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetClassicLeagueAsync_BadLeague_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetClassicLeagueAsync(9999999).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetClassicLeagueAsync_InvalidLeague_Throws(int leagueId)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetClassicLeagueAsync(leagueId).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetClassicLeagueAsync_InvalidPage_Throws(int page)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetClassicLeagueAsync(316, page).AsTask());
            await Assert.ThrowsAsync<ValidationException>(() => _client.GetClassicLeagueAsync(316, 1, page).AsTask());
        }
    }
}