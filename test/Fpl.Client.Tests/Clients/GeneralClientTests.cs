using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class GeneralClientTests
    {
        private readonly IGeneralClient _client;

        public GeneralClientTests()
        {
            _client = new GeneralClient(new HttpClient());
        }

        [Fact]
        public async Task GetDataAsync_ReturnsOk()
        {
            var result = await _client.GetDataAsync();

            Assert.NotNull(result);
        }
    }
}