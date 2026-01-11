using AdoptieAnimale.Web.Models;

namespace AdoptieAnimale.Web.Services
{
    public interface IApiService
    {
        // Animals
        Task<List<Animal>> GetAnimalsAsync();
        Task<Animal?> GetAnimalAsync(int id);
        Task<Animal?> CreateAnimalAsync(Animal animal);
        Task<bool> UpdateAnimalAsync(int id, Animal animal);
        Task<bool> DeleteAnimalAsync(int id);

        // Categories
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int id);
        Task<Category?> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);

        // Shelters
        Task<List<Shelter>> GetSheltersAsync();
        Task<Shelter?> GetShelterAsync(int id);
        Task<Shelter?> CreateShelterAsync(Shelter shelter);
        Task<bool> UpdateShelterAsync(int id, Shelter shelter);
        Task<bool> DeleteShelterAsync(int id);
    }
}