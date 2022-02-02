using AutoMapper;
using Fpl.Client.Clients;
using Serilog;
using Ultimate.Fpl.Ui.Models.General;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Services
{
    public class DataService : IDataService
    {
        private readonly ICacheService _cacheService;
        private readonly IGeneralClient _client;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DataService(ICacheService cacheService, IGeneralClient client, IMapper mapper)
        {
            _cacheService = cacheService;
            _client = client;
            _mapper = mapper;
            _logger = Log.ForContext<DataService>();
        }

        public async Task<Data> GetAsync(CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetAsync)} invoked");
            var result = await _cacheService.GetDataAsync(cancellationToken);

            if (result == null)
            {
                var data = await _client.GetDataAsync(cancellationToken);

                var clubs = data.Teams.Select(x => _mapper.Map<Club>(x)).ToList();
                var positions = data.ElementTypes.Select(x => _mapper.Map<Position>(x)).ToList();
                var gameweeks = data.Events.Select(x => _mapper.Map<Gameweek>(x)).ToList();

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
                    (club, team) => _mapper.Map(team, club)
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
                    Prices = prices,
                    Gameweeks = gameweeks
                };

                await _cacheService.SetDataAsync(result, cancellationToken);
            }

            return result;
        }
    }
}