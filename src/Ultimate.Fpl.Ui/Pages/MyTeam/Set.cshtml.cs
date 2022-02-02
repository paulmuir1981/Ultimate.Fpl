using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ultimate.Fpl.Ui.Services;

namespace Ultimate.Fpl.Ui.Pages.MyTeam
{
    public class SetModel : PageModel
    {
        private readonly IEntryService _teamService;

        public SetModel(IEntryService teamService)
        {
            _teamService = teamService;
        }

        [BindProperty]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Team ID")]
        [DisplayName("Team ID")]
        public int? TeamId { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid && await _teamService.SetMyEntryAsync(TeamId.Value))
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
