using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public IndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            try
            {
                Categories = await _apiService.GetCategoriesAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Eroare la înc?rcarea categoriilor: {ex.Message}";
            }
        }
    }
}