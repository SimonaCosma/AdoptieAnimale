using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Shelters
{
    public class EditModel : PageModel
    {
        private readonly IApiService _apiService;

        public EditModel(IApiService apiService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _apiService.UpdateShelterAsync(Shelter.ID, Shelter);

                if (result)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la modificarea ad?postului.";
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