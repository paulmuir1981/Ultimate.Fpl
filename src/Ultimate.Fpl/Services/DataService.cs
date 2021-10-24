using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fpl.Client.Clients;
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

        private async Task<Models.Data> GetAsync(CancellationToken cancellationToken = default)
        {
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
                    .ToList();

                result = new Models.Data
                {
                    Clubs = clubs,
                    Players = players,
                    Positions = positions
                };
                await _cacheService.SetDataAsync(result, cancellationToken);
            }

            return result;
        }

        public async Task<List<Player>> GetPlayersAsync(CancellationToken cancellationToken = default)
        {
            return (await GetAsync(cancellationToken)).Players;
        }
    }
}