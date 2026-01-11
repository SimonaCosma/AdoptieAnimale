using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Shelters
{
    public class CreateModel : PageModel
    {
        private readonly IApiService _apiService;

        public CreateModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Shelter Shelter { get; set; } = new Shelter();
        public string ErrorMessage { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
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
                var result = await _apiService.CreateShelterAsync(Shelter);

                if (result != null)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la ad?ugarea ad?postului.";
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