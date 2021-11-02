using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Ultimate.Fpl.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            Log.Debug($"{nameof(OnGet)} invoked");
        }
    }
}
