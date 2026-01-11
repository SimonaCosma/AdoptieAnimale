using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdoptieAnimale.Web.Pages.Animals
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IApiService _apiService;

        public CreateModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Animal Animal { get; set; } = new Animal();

        public SelectList? CategoriesSelectList { get; set; }
        public SelectList? SheltersSelectList { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadSelectLists();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectLists();
                return Page();
            }

            try
            {
                Animal.DateAdded = DateTime.Now;
                var result = await _apiService.CreateAnimalAsync(Animal);

                if (result != null)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la ad?ugarea animalului. Verifica?i conexiunea la API.";
                    await LoadSelectLists();
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Eroare: {ex.Message}";
                await LoadSelectLists();
                return Page();
            }
        }

        private async Task LoadSelectLists()
        {
            var categories = await _apiService.GetCategoriesAsync();
            var shelters = await _apiService.GetSheltersAsync();

            CategoriesSelectList = new SelectList(categories, "ID", "Name");
            SheltersSelectList = new SelectList(shelters, "ID", "Name");
        }
    }
}