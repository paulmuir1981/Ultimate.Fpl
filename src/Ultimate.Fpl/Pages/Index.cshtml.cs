using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Ultimate.Fpl.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Log.ForContext<IndexModel>().Information($"{nameof(OnGet)} invoked");
        }
    }
}
