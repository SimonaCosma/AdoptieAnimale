using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class SheltersPage : ContentPage
{
    private readonly IApiService _apiService;

    public SheltersPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        LoadShelters();
    }

    private async void LoadShelters()
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        try
        {
            var shelters = await _apiService.GetSheltersAsync();
            SheltersCollection.ItemsSource = shelters;
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