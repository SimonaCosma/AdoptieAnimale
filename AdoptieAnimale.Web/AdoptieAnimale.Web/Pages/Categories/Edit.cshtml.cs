using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdoptieAnimale.Web.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IApiService _apiService;

        public EditModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public Category Category { get; set; } = new Category();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _apiService.GetCategoryAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            Category = category;
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
                var result = await _apiService.UpdateCategoryAsync(Category.ID, Category);

                if (result)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ErrorMessage = "Eroare la modificarea categoriei.";
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