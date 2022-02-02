using Fpl.Client.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class EntryClientTests
    {
        private readonly IEntryClient _client;

        public EntryClientTests()
        {
            _client = new EntryClient(new HttpClient());
        }

        [Fact]
        public async Task GetEntryAsync_ReturnsOk()
        {
            var result = await _client.GetEntryAsync(5514);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEntryAsync_BadEntry_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetEntryAsync(9999999).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetEntryAsync_InvalidEntryId_Throws(int entryId)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _client.GetEntryAsync(entryId).AsTask());
            Assert.Equal("entryId", result.ParamName);
            Assert.Equal(entryId, result.ActualValue);
        }

        [Fact]
        public async Task GetEventPicksAsync_ReturnsOk()
        {
            var result = await _client.GetEntryEventPicksAsync(5514, 1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEventPicksAsync_BadEntry_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetEntryEventPicksAsync(9999999, 1).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetEventPicksAsync_InvalidEntryId_Throws(int entryId)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _client.GetEntryEventPicksAsync(entryId, 1).AsTask());
            Assert.Equal("entryId", result.ParamName);
            Assert.Equal(entryId, result.ActualValue);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(39)]
        [InlineData(int.MaxValue)]
        public async Task GetEventPicksAsync_InvalidEventId_Throws(int eventId)
        {
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _client.GetEntryEventPicksAsync(5514, eventId).AsTask());
            Assert.Equal("eventId", result.ParamName);
            Assert.Equal(eventId, result.ActualValue);
        }
    }
}