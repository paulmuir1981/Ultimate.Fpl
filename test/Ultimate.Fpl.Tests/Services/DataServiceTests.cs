//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Ultimate.Fpl.Models;
//using Ultimate.Fpl.Profiles;
//using Ultimate.Fpl.Services;
//using Xunit;
//using Data = Fpl.Client.Models.Data;

//namespace Ultimate.Fpl.Tests.Services
//{
//    public class DataServiceTests
//    {
//        private readonly IDataService _dataService;
//        private readonly Random _random;
//        private readonly Mock<ICacheService> _mockCache;
//        private readonly Mock<IFplClient> _mockClient;

//        public DataServiceTests()
//        {
//            _mockCache = new Mock<ICacheService>();
//            _mockClient = new Mock<IFplClient>();
//            _random = new Random();
//            _dataService = new DataService(
//                _mockCache.Object, 
//                _mockClient.Object, 
//                new Mapper(new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile> { new PlayerProfile(), new ClubProfile(), new PositionProfile() }))));
//        }

//        [Fact]
//        public async Task GetAsync_Cached_Ok()
//        {
//            var expectedPlayerId = _random.Next();
//            var expectedWebName = Guid.NewGuid().ToString();

//            var expectedPlayer = new Player
//            {
//                Id = expectedPlayerId,
//                WebName = expectedWebName
//            };
//            var expectedData = new Models.Data { Players = new List<Player> { expectedPlayer } };
//            _mockCache.Setup(x => x.GetDataAsync(It.IsAny<CancellationToken>())).ReturnsAsync(expectedData);

//            var actualData = await _dataService.GetAsync();

//            Assert.NotNull(actualData);
//            var actualPlayers = actualData.Players;
//            Assert.Single(actualPlayers);
//            var actualPlayer = actualPlayers[0];
//            Assert.Equal(expectedPlayerId, actualPlayer.Id);
//            Assert.Equal(expectedWebName, actualPlayer.WebName);
//            _mockCache.Verify(x => x.GetDataAsync(It.IsAny<CancellationToken>()), Times.Once);
//            _mockClient.Verify(x => x.GetAsync(It.IsAny<CancellationToken>()), Times.Never);
//        }

//        [Fact]
//        public async Task GetAsync_NotCached_Ok()
//        {
//            var expectedPlayerId = _random.Next();
//            var expectedClubId = _random.Next();
//            var expectedWebName = Guid.NewGuid().ToString();
//            var expectedClubName = Guid.NewGuid().ToString();
//            var expectedClubShortName = Guid.NewGuid().ToString();
//            var expectedNowCost = _random.Next() * 10;
//            var expectedPrice = expectedNowCost / 10.0M;
//            var expectedPositionId = _random.Next();
//            var expectedPositionName = Guid.NewGuid().ToString();
//            var expectedPositionShortName = Guid.NewGuid().ToString();
//            var expectedElement = new Element
//            {
//                Id = expectedPlayerId,
//                WebName = expectedWebName,
//                Team = expectedClubId,
//                NowCost = expectedNowCost,
//                ElementType = expectedPositionId
//            };
//            var expectedTeam = new Team
//            {
//                Id = expectedClubId,
//                Name = expectedClubName,
//                ShortName = expectedClubShortName
//            };
//            var expectedElementType = new ElementType
//            {
//                Id = expectedPositionId,
//                SingularName = expectedPositionName,
//                SingularNameShort = expectedPositionShortName
//            };
//            var expectedData = new Data { Elements = new List<Element> { expectedElement }, Teams = new List<Team>{ expectedTeam }, ElementTypes = new List<ElementType>{expectedElementType}};

//            _mockClient.Setup(x => x.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(expectedData);
//            _mockCache.Setup(x => x.GetDataAsync(It.IsAny<CancellationToken>())).ReturnsAsync(null as Models.Data);
//            _mockCache.Setup(x => x.SetDataAsync(It.IsAny<Models.Data>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

//            var actualData = await _dataService.GetAsync();

//            Assert.NotNull(actualData);
//            var actualPlayers = actualData.Players;
//            Assert.Single(actualPlayers);
//            var actualPlayer = actualPlayers[0];
//            Assert.Equal(expectedPlayerId, actualPlayer.Id);
//            Assert.Equal(expectedWebName, actualPlayer.WebName);
//            Assert.Equal(expectedPrice, actualPlayer.Price);
//            Assert.Equal(expectedClubId, actualPlayer.ClubId);
//            Assert.Equal(expectedClubShortName, actualPlayer.ClubShortName);
//            Assert.Equal(expectedClubName, actualPlayer.ClubName);
//            Assert.Equal(expectedPositionId, actualPlayer.PositionId);
//            Assert.Equal(expectedPositionName, actualPlayer.PositionName);
//            Assert.Equal(expectedPositionShortName, actualPlayer.PositionShortName);

//            _mockCache.Verify(x => x.GetDataAsync(It.IsAny<CancellationToken>()), Times.Once);
//            _mockCache.Verify(x => x.SetDataAsync(It.IsAny<Models.Data>(), It.IsAny<CancellationToken>()), Times.Once);
//            _mockClient.Verify(x => x.GetAsync(It.IsAny<CancellationToken>()), Times.Once);
//        }
//    }
//}
