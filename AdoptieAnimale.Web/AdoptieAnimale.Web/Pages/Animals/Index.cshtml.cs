using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public IndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Animal> Animals { get; set; } = new List<Animal>();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            try
            {
                Animals = await _apiService.GetAnimalsAsync();

                // Încarc? ?i categoriile ?i shelters pentru afi?are
                var categories = await _apiService.GetCategoriesAsync();
                var shelters = await _apiService.GetSheltersAsync();

                // Asociaz? categoriile ?i shelters cu animalele
                foreach (var animal in Animals)
                {
                    animal.Category = categories.FirstOrDefault(c => c.ID == animal.CategoryID);
                    animal.Shelter = shelters.FirstOrDefault(s => s.ID == animal.ShelterID);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Eroare la înc?rcarea animalelor: {ex.Message}";
            }
        }
    }
}