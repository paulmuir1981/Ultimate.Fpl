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
        private readonly ILogger _logger;
        public List<Club> Clubs;

        public ClubsModel(IDataService dataService)
        {
            _dataService = dataService;
            _logger = Log.ForContext<ClubsModel>();
        }

        public async Task OnGetAsync()
        {
            _logger.Information($"{nameof(OnGetAsync)} invoked");
            var data = await _dataService.GetAsync();
            Clubs = data.Clubs;
        }
    }
}