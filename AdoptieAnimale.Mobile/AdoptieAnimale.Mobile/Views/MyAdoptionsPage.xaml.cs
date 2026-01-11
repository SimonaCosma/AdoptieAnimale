using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class MyAdoptionsPage : ContentPage
{
    private readonly IApiService _apiService;
    private const int CurrentUserId = 1; // TODO: ID-ul real al utilizatorului logat

    public MyAdoptionsPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        LoadAdoptions();
    }

    private async void LoadAdoptions()
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        try
        {
            var adoptions = await _apiService.GetMyAdoptionRequestsAsync(CurrentUserId);
            AdoptionsCollection.ItemsSource = adoptions;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"Nu s-au putut încărca cererile: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadAdoptions();
    }
}