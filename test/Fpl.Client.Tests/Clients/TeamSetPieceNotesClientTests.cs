using System.Net.Http;
using System.Threading.Tasks;
using Fpl.Client.Clients;
using Xunit;

namespace Fpl.Client.Tests.Clients
{
    public class TeamSetPieceNotesClientTests
    {
        private readonly ITeamSetPieceNotesClient _client;

        public TeamSetPieceNotesClientTests()
        {
            _client = new TeamSetPieceNotesClient(new HttpClient());
        }

        [Fact]
        public async Task TeamSetPieceNotesClient_ReturnsOk()
        {
            var result = await _client.GetSetPieceNotesAsync();

            Assert.NotNull(result);
        }
    }
}