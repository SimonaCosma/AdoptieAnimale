using AdoptieAnimale.Mobile.Models;

namespace AdoptieAnimale.Mobile.Services
{
    public interface IApiService
    {
        // Animals
        Task<List<Animal>> GetAnimalsAsync();
        Task<Animal> GetAnimalAsync(int id);
        Task<Animal> CreateAnimalAsync(Animal animal);
        Task<bool> UpdateAnimalAsync(int id, Animal animal);
        Task<bool> DeleteAnimalAsync(int id);

        // Categories
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);

        // Shelters
        Task<List<Shelter>> GetSheltersAsync();
        Task<Shelter> GetShelterAsync(int id);
        Task<Shelter> CreateShelterAsync(Shelter shelter);
        Task<bool> UpdateShelterAsync(int id, Shelter shelter);
        Task<bool> DeleteShelterAsync(int id);

        // AdoptionRequests
        Task<List<AdoptionRequest>> GetAdoptionRequestsAsync();
        Task<List<AdoptionRequest>> GetMyAdoptionRequestsAsync(int memberId);
        Task<AdoptionRequest> GetAdoptionRequestAsync(int id);
        Task<AdoptionRequest> CreateAdoptionRequestAsync(AdoptionRequest request);
        Task<bool> UpdateAdoptionRequestAsync(int id, AdoptionRequest request);
        Task<bool> DeleteAdoptionRequestAsync(int id);

        // Authentication (optional)
        Task<bool> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
    }
}