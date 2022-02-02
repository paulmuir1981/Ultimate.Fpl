using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Ultimate.Fpl.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            Log.ForContext<PrivacyModel>().Information($"{nameof(OnGet)} invoked");
        }
    }
}
