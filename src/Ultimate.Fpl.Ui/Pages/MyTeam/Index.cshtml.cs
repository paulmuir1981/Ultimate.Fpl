using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using Ultimate.Fpl.Ui.Models.Entries;
using Ultimate.Fpl.Ui.Services;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Pages.MyTeam
{
    public class IndexModel : PageModel
    {
        private readonly IEntryService _teamService;
        private readonly ILogger _logger;
        public EntryEventPicks EntryEventPicks;

        public IndexModel(IEntryService teamService)
        {
            _teamService = teamService;
            _logger = Log.ForContext<IndexModel>();
        }

        public async Task OnGetAsync(int? eventId = null)
        {
            _logger.Information($"{nameof(OnGetAsync)} invoked");

            if (eventId == null)
            {
                EntryEventPicks = await _teamService.GetMyEntryCurrentEventPicksAsync();
            }
            else
            {
                EntryEventPicks = await _teamService.GetMyEntryEventPicksAsync(eventId.Value);
            }               
        }
    }
}
