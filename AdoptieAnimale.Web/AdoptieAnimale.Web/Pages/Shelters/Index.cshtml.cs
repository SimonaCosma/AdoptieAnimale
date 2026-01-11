using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Shelters
{
    public class IndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public IndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Shelter> Shelters { get; set; } = new List<Shelter>();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            try
            {
                Shelters = await _apiService.GetSheltersAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Eroare: {ex.Message}";
            }
        }
    }
}