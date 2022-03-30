using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class ElementSummaryClientTests
    {
        private readonly IElementSummaryClient _client;

        public ElementSummaryClientTests()
        {
            _client = new ElementSummaryClient(new HttpClient());
        }

        [Fact]
        public async Task GetElementSummaryAsync_ReturnsOk()
        {
            var result = await _client.GetElementSummaryAsync(4);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetElementSummaryAsync_BadElement_Throws()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _client.GetElementSummaryAsync(9999999).AsTask());
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task GetEntryHistoryAsync_InvalidEntryId_Throws(int entryId)
        {
            var result = await Assert.ThrowsAsync<ValidationException>(() => _client.GetElementSummaryAsync(entryId).AsTask());
        }
    }
}