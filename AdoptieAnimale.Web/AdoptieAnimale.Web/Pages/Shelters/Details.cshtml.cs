using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoptieAnimale.Web.Models;
using AdoptieAnimale.Web.Services;

namespace AdoptieAnimale.Web.Pages.Shelters
{
    public class DetailsModel : PageModel
    {
        private readonly IApiService _apiService;

        public DetailsModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Shelter Shelter { get; set; } = new Shelter();

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
    }
}