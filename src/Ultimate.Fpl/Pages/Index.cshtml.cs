using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Ultimate.Fpl.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Log.Debug($"{nameof(OnGet)} invoked");
        }
    }
}
