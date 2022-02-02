//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.DependencyInjection;
//using Ultimate.Fpl.Models;
//using Ultimate.Fpl.Services;
//using Ultimate.Fpl.Extensions;
//using Xunit;

//namespace Ultimate.Fpl.Tests.Services
//{
//    public class CacheServiceTests
//    {
//        private readonly IDistributedCache _distributedCache;
//        private readonly ICacheService _cacheService;
//        private readonly Random _random;

//        public CacheServiceTests()
//        {
//            var services = new ServiceCollection();
//            services.AddDistributedMemoryCache();
//            var serviceProvider = services.BuildServiceProvider();
//            _distributedCache = serviceProvider.GetService<IDistributedCache>();
//            _cacheService = new CacheService(_distributedCache);
//            _random = new Random();
//        }

//        [Fact]
//        public async Task SetDataAsync_Ok()
//        {
//            var expectedPlayer = new Player
//            {
//                Id = _random.Next(),
//                WebName = Guid.NewGuid().ToString()
//            };
//            var expectedData = new Data {Players = new List<Player> {expectedPlayer}};

//            await _cacheService.SetDataAsync(expectedData);

//            var actualData = await _distributedCache.GetAsync<Data>(CacheService.Keys.Data);

//            Assert.NotNull(actualData);
//            Assert.Single(actualData.Players);
//            var actualPlayer = actualData.Players[0];
//            Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
//            Assert.Equal(expectedPlayer.WebName, actualPlayer.WebName);
//        }

//        [Fact]
//        public async Task GetDataAsync_DataSet_Ok()
//        {
//            var expectedPlayer = new Player
//            {
//                Id = _random.Next(),
//                WebName = Guid.NewGuid().ToString()
//            };
//            var expectedData = new Data { Players = new List<Player> { expectedPlayer } };
//            await _distributedCache.SetAsync(CacheService.Keys.Data, expectedData);

//            var actualData = await _cacheService.GetDataAsync();

//            Assert.NotNull(actualData);
//            Assert.Single(actualData.Players);
//            var actualPlayer = actualData.Players[0];
//            Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
//            Assert.Equal(expectedPlayer.WebName, actualPlayer.WebName);
//        }

//        [Fact]
//        public async Task GetDataAsync_DataNotSet_ReturnsNull()
//        {
//            var actualData = await _cacheService.GetDataAsync();
//            Assert.Null(actualData);
//        }
//    }
//}