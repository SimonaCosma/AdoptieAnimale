using AdoptieAnimale.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace AdoptieAnimale.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7191/api";
        }

        // ANIMALS
        public async Task<List<Animal>> GetAnimalsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Animals");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Animal>>(content) ?? new List<Animal>();
                }
                return new List<Animal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Animal>();
            }
        }

        public async Task<Animal?> GetAnimalAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Animals/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Animal>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Animal?> CreateAnimalAsync(Animal animal)
        {
            try
            {
                var json = JsonConvert.SerializeObject(animal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/Animals", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Animal>(responseContent);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAnimalAsync(int id, Animal animal)
        {
            try
            {
                var json = JsonConvert.SerializeObject(animal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/Animals/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/Animals/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // CATEGORIES
        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Category>>(content) ?? new List<Category>();
                }
                return new List<Category>();
            }
            catch
            {
                return new List<Category>();
            }
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Categories/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Category>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Categories", content);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new Exception($"API {(int)response.StatusCode} {response.ReasonPhrase}: {body}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(responseContent);
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            try
            {
                var json = JsonConvert.SerializeObject(category);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/Categories/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/Categories/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // SHELTERS
        public async Task<List<Shelter>> GetSheltersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Shelters");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Shelter>>(content) ?? new List<Shelter>();
                }
                return new List<Shelter>();
            }
            catch
            {
                return new List<Shelter>();
            }
        }

        public async Task<Shelter?> GetShelterAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Shelters/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Shelter>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Shelter?> CreateShelterAsync(Shelter shelter)
        {
            try
            {
                var json = JsonConvert.SerializeObject(shelter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/Shelters", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Shelter>(responseContent);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateShelterAsync(int id, Shelter shelter)
        {
            try
            {
                var json = JsonConvert.SerializeObject(shelter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/Shelters/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteShelterAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/Shelters/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}