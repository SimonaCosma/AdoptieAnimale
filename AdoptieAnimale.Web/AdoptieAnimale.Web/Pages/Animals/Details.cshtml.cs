using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly IApiService _apiService;

        public DetailsModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Animal Animal { get; set; } = new Animal();

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

            // Încarcă categoria și shelterul
            Animal.Category = await _apiService.GetCategoryAsync(animal.CategoryID);
            Animal.Shelter = await _apiService.GetShelterAsync(animal.ShelterID);

            return Page();
        }
    }
}