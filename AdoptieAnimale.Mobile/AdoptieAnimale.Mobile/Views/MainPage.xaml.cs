using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class MainPage : ContentPage
{
    private readonly IApiService _apiService;

    public MainPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        LoadAnimals();
    }

    private async void LoadAnimals()
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        try
        {
            var animals = await _apiService.GetAnimalsAsync();
            AnimalsCollection.ItemsSource = animals;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"Nu s-au putut încărca animalele: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadAnimals();
    }

    private async void OnAnimalSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Animal selectedAnimal)
        {
            await Navigation.PushAsync(new AnimalDetailPage(_apiService, selectedAnimal));
            AnimalsCollection.SelectedItem = null;
        }
    }

    private async void OnCategoriesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CategoriesPage(_apiService));
    }

    private async void OnSheltersClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SheltersPage(_apiService));
    }
}