using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class AdoptionRequestPage : ContentPage
{
    private readonly IApiService _apiService;
    private readonly Animal _animal;

    public AdoptionRequestPage(IApiService apiService, Animal animal)
    {
        InitializeComponent();
        _apiService = apiService;
        _animal = animal;
        LoadAnimalInfo();
    }

    private void LoadAnimalInfo()
    {
        AnimalNameLabel.Text = _animal.Name;
        AnimalDetailsLabel.Text = $"{_animal.Species} - {_animal.Breed ?? "Rasă necunoscută"}";
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Validare
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Eroare", "Te rog introdu numele tău!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Eroare", "Te rog introdu email-ul!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(ReasonEditor.Text))
        {
            await DisplayAlert("Eroare", "Te rog explică de ce vrei să adopți!", "OK");
            return;
        }

        try
        {
            var adoptionRequest = new AdoptionRequest
            {
                AnimalID = _animal.ID,
                MemberID = 1, // TODO: ID-ul utilizatorului logat
                RequestDate = DateTime.Now,
                Status = "Pending",
                ApplicantName = NameEntry.Text,
                ApplicantEmail = EmailEntry.Text,
                ApplicantPhone = PhoneEntry.Text,
                ApplicantAddress = AddressEntry.Text,
                Reason = ReasonEditor.Text
            };

            var result = await _apiService.CreateAdoptionRequestAsync(adoptionRequest);

            if (result != null)
            {
                await DisplayAlert("Success", "Cererea ta de adopție a fost trimisă cu succes!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Eroare", "Nu s-a putut trimite cererea. Încearcă din nou!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"A apărut o eroare: {ex.Message}", "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}