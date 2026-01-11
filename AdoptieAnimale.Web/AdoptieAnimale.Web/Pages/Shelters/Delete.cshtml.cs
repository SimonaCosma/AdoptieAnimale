using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Shelters
{
    public class DeleteModel : PageModel
    {
        private readonly IApiService _apiService;

        public DeleteModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Shelter Shelter { get; set; } = new Shelter();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _apiService.GetShelterAsync(id.Value);
            if (shelter == null)
            {
                return NotFound();
            }

            Shelter = shelter;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var result = await _apiService.DeleteShelterAsync(id.Value);

                if (result)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la ștergerea adăpostului. Este posibil să existe animale asociate.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Eroare: {ex.Message}";
                return Page();
            }
        }
    }
}