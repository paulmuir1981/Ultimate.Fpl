using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ultimate.Fpl.Models;
using Ultimate.Fpl.Services;

namespace Ultimate.Fpl.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly IDataService _dataService;
        public List<Player> Players;

        public PlayersModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task OnGetAsync()
        {
            Players = await _dataService.GetPlayersAsync();
        }
    }
}
