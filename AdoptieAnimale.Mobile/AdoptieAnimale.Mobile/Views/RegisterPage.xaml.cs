using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class RegisterPage : ContentPage
{
    private readonly IApiService _apiService;

    public RegisterPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
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

        if (PasswordEntry.Text.Length < 6)
        {
            await DisplayAlert("Eroare", "Parola trebuie să aibă minim 6 caractere!", "OK");
            return;
        }

        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Eroare", "Parolele nu coincid!", "OK");
            return;
        }

        try
        {
            var registerRequest = new RegisterRequest
            {
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text,
                ConfirmPassword = ConfirmPasswordEntry.Text
            };

            var success = await _apiService.RegisterAsync(registerRequest);

            if (success)
            {
                await DisplayAlert("Success", "Cont creat cu succes! Te poți autentifica acum.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Eroare", "Nu s-a putut crea contul. Încearcă din nou!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"A apărut o eroare: {ex.Message}", "OK");
        }
    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}