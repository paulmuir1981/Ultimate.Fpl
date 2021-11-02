using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using Ultimate.Fpl.Models;
using Ultimate.Fpl.Services;

namespace Ultimate.Fpl.Pages
{
    public class ClubsModel : PageModel
    {
        private readonly IDataService _dataService;
        public List<Club> Clubs;

        public ClubsModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task OnGetAsync()
        {
            Log.Debug($"{nameof(OnGetAsync)} invoked");
            var data = await _dataService.GetAsync();
            Clubs = data.Clubs;
        }
    }
}