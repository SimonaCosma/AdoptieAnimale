using AdoptieAnimale.Mobile.Models;
using Newtonsoft.Json;
using System.Text;

namespace AdoptieAnimale.Mobile.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        //private const string BaseUrl = "https://10.0.2.2:7191/api"; // Android Emulator
        private const string BaseUrl = "http://localhost:5107/api";

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        // ===== ANIMALS =====
        public async Task<List<Animal>> GetAnimalsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/animals");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Animal>>(content) ?? new List<Animal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Animal>();
            }
        }

        public async Task<Animal> GetAnimalAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/animals/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Animal>(content);
        }

        public async Task<Animal> CreateAnimalAsync(Animal animal)
        {
            var json = JsonConvert.SerializeObject(animal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/animals", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Animal>(responseContent);
        }

        public async Task<bool> UpdateAnimalAsync(int id, Animal animal)
        {
            var json = JsonConvert.SerializeObject(animal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/animals/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/animals/{id}");
            return response.IsSuccessStatusCode;
        }

        // ===== CATEGORIES =====
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Category>>(content) ?? new List<Category>();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/categories/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(content);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/categories", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(responseContent);
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/categories/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/categories/{id}");
            return response.IsSuccessStatusCode;
        }

        // ===== SHELTERS =====
        public async Task<List<Shelter>> GetSheltersAsync()
        {
            var response = await _httpClient.GetAsync("api/shelters");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Shelter>>(content) ?? new List<Shelter>();
        }

        public async Task<Shelter> GetShelterAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/shelters/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Shelter>(content);
        }

        public async Task<Shelter> CreateShelterAsync(Shelter shelter)
        {
            var json = JsonConvert.SerializeObject(shelter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/shelters", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Shelter>(responseContent);
        }

        public async Task<bool> UpdateShelterAsync(int id, Shelter shelter)
        {
            var json = JsonConvert.SerializeObject(shelter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/shelters/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteShelterAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/shelters/{id}");
            return response.IsSuccessStatusCode;
        }

        // ===== ADOPTION REQUESTS =====
        public async Task<List<AdoptionRequest>> GetAdoptionRequestsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/adoptionrequests");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AdoptionRequest>>(content) ?? new List<AdoptionRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<AdoptionRequest>();
            }
        }

        public async Task<List<AdoptionRequest>> GetMyAdoptionRequestsAsync(int memberId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/adoptionrequests/member/{memberId}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AdoptionRequest>>(content) ?? new List<AdoptionRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<AdoptionRequest>();
            }
        }

        public async Task<AdoptionRequest> GetAdoptionRequestAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/adoptionrequests/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AdoptionRequest>(content);
        }

        public async Task<AdoptionRequest> CreateAdoptionRequestAsync(AdoptionRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/adoptionrequests", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AdoptionRequest>(responseContent);
        }

        public async Task<bool> UpdateAdoptionRequestAsync(int id, AdoptionRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/adoptionrequests/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAdoptionRequestAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/adoptionrequests/{id}");
            return response.IsSuccessStatusCode;
        }

        // ===== AUTHENTICATION (Simplified - fără Identity real) =====
        public async Task<bool> LoginAsync(LoginRequest request)
        {
            // Simplified - pentru testare
            return await Task.FromResult(true);
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            // Simplified - pentru testare
            return await Task.FromResult(true);
        }
    }
}