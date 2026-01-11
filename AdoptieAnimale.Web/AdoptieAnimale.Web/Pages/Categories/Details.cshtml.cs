using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly IApiService _apiService;

        public DetailsModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Category Category { get; set; } = new Category();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var category = await _apiService.GetCategoryAsync(id.Value);
            if (category == null) return NotFound();

            Category = category;
            return Page();
        }
    }
}