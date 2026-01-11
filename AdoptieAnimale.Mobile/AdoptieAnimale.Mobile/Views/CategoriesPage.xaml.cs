using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class CategoriesPage : ContentPage
{
    private readonly IApiService _apiService;

    public CategoriesPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        LoadCategories();
    }

    private async void LoadCategories()
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        try
        {
            var categories = await _apiService.GetCategoriesAsync();
            CategoriesCollection.ItemsSource = categories;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }
    }
}