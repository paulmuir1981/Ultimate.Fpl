using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using Ultimate.Fpl.Ui.Models.General;
using Ultimate.Fpl.Ui.Services;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Pages.Clubs
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger;
        public List<Club> Clubs;

        public IndexModel(IDataService dataService)
        {
            _dataService = dataService;
            _logger = Log.ForContext<IndexModel>();
        }

        public async Task OnGetAsync()
        {
            _logger.Information($"{nameof(OnGetAsync)} invoked");
            var data = await _dataService.GetAsync();
            Clubs = data.Clubs;
        }
    }
}
