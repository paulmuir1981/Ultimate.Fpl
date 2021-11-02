using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using Ultimate.Fpl.Models;
using Ultimate.Fpl.Services;

namespace Ultimate.Fpl.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly IDataService _dataService;
        public List<Player> Players;
        public List<Club> Clubs;
        public List<Position> Positions;
        public SelectList MinPrices;
        public SelectList MaxPrices;
        public SelectList MinAvailabilities;
        public SelectList MaxAvailabilities;

        public PlayersModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task OnGetAsync()
        {
            Log.Debug($"{nameof(OnGetAsync)} invoked");
            var data = await _dataService.GetAsync();
            Players = data.Players;
            Clubs = data.Clubs;
            Positions = data.Positions;

            MinPrices = new SelectList(data.Prices, data.Prices[0]);
            MaxPrices = new SelectList(data.Prices.AsEnumerable().Reverse(), data.Prices.Last());

            MinAvailabilities = new SelectList(Player.Availabilities, Player.Availabilities[0]);
            MaxAvailabilities = new SelectList(Player.Availabilities.AsEnumerable().Reverse(), Player.Availabilities.Last());
        }
    }
}
