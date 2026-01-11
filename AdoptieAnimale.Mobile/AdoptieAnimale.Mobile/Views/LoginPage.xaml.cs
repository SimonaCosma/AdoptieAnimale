using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class LoginPage : ContentPage
{
    private readonly IApiService _apiService;

    public LoginPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Validare
        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Eroare", "Te rog introdu email-ul!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Eroare", "Te rog introdu parola!", "OK");
            return;
        }

        try
        {
            var loginRequest = new LoginRequest
            {
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            var success = await _apiService.LoginAsync(loginRequest);

            if (success)
            {
                await DisplayAlert("Success", "Autentificare reușită!", "OK");

                // Navighează la MainPage
                Application.Current.MainPage = new NavigationPage(new MainPage(_apiService));
            }
            else
            {
                await DisplayAlert("Eroare", "Email sau parolă incorecte!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"A apărut o eroare: {ex.Message}", "OK");
        }
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_apiService));
    }
}