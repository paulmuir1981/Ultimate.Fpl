using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using Ultimate.Fpl.Ui.Models.General;
using Ultimate.Fpl.Ui.Services;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger;
        public List<Player> Players;
        public List<Club> Clubs;
        public List<Position> Positions;
        public SelectList MinPrices;
        public SelectList MaxPrices;
        public SelectList MinAvailabilities;
        public SelectList MaxAvailabilities;

        public IndexModel(IDataService dataService)
        {
            _dataService = dataService;
            _logger = Log.ForContext<IndexModel>();
        }

        public async Task OnGetAsync()
        {
            var x = User.Identity;
            _logger.Information($"{nameof(OnGetAsync)} invoked");
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