using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fpl.Client.Clients;
using Serilog;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Services
{
    public class DataService : IDataService
    {
        private readonly ICacheService _cacheService;
        private readonly IFplClient _fplClient;
        private readonly IMapper _mapper;

        public DataService(ICacheService cacheService, IFplClient fplClient, IMapper mapper)
        {
            _cacheService = cacheService;
            _fplClient = fplClient;
            _mapper = mapper;
        }

        public async Task<Data> GetAsync(CancellationToken cancellationToken = default)
        {
            Log.Debug($"{nameof(GetAsync)} invoked");
            var result = await _cacheService.GetDataAsync(cancellationToken);

            if (result == null)
            {
                var data = await _fplClient.GetAsync(cancellationToken);

                var clubs = data.Teams.Select(x => _mapper.Map<Club>(x)).ToList();
                var positions = data.ElementTypes.Select(x => _mapper.Map<Position>(x)).ToList();

                var players = data.Elements
                    .Select(x => _mapper.Map<Player>(x))
                    .Join(
                        clubs,
                        p => p.ClubId,
                        c => c.Id,
                        (p, c) => _mapper.Map(c, p)
                    )
                    .Join(
                        positions,
                        pl => pl.PositionId,
                        po => po.Id,
                        (pl, po) => _mapper.Map(po, pl)
                    )
                    .OrderByDescending(x => x.TotalPoints)
                    .ToList();

                clubs = clubs.GroupJoin(
                    players,
                    club => club.Id,
                    player => player.ClubId,
                    (club, squad) => _mapper.Map(squad, club)
                ).ToList();

                var prices = new List<decimal>();

                for (var price = players.Min(x => x.Price); price <= players.Max(x => x.Price); price += 0.1m)
                {
                    prices.Add(price);
                }

                result = new Data
                {
                    Clubs = clubs,
                    Players = players,
                    Positions = positions,
                    Prices = prices
                };

                await _cacheService.SetDataAsync(result, cancellationToken);
            }

            return result;
        }
    }
}