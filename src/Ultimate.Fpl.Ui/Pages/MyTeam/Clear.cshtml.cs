using Microsoft.AspNetCore.Mvc.RazorPages;
using Ultimate.Fpl.Ui.Services;

namespace Ultimate.Fpl.Ui.Pages.MyTeam
{
    public class ClearModel : PageModel
    {
        private readonly IEntryService _teamService;

        public ClearModel(IEntryService teamService)
        {
            _teamService = teamService;
        }

        public void OnGet()
        {
            _teamService.ClearMyEntry();
        }
    }
}
