using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdoptieAnimale.Web.Pages.Animals
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IApiService _apiService;

        public DeleteModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Animal Animal { get; set; } = new Animal();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _apiService.GetAnimalAsync(id.Value);
            if (animal == null)
            {
                return NotFound();
            }

            Animal = animal;
            Animal.Category = await _apiService.GetCategoryAsync(animal.CategoryID);
            Animal.Shelter = await _apiService.GetShelterAsync(animal.ShelterID);

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
                var result = await _apiService.DeleteAnimalAsync(id.Value);

                if (result)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la ?tergerea animalului.";
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