using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;
using System.Xml;

namespace AdoptieAnimale.Mobile.Views;

public partial class AnimalDetailPage : ContentPage
{
    private readonly IApiService _apiService;
    private readonly Animal _animal;

    public AnimalDetailPage(IApiService apiService, Animal animal)
    {
        InitializeComponent();
        _apiService = apiService;
        _animal = animal;
        LoadAnimalDetails();
    }

    private void LoadAnimalDetails()
    {
        NameLabel.Text = _animal.Name;
        SpeciesLabel.Text = $"Specie: {_animal.Species}";
        BreedLabel.Text = $"Rasă: {_animal.Breed ?? "Necunoscută"}";
        AgeLabel.Text = $"Vârstă: {_animal.Age ?? 0} ani";
        GenderLabel.Text = $"Gen: {_animal.Gender ?? "Necunoscut"}";
        StatusLabel.Text = $"Status: {_animal.Status}";
        DescriptionLabel.Text = _animal.Description ?? "Fără descriere.";
    }

    private async void OnAdoptClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdoptionRequestPage(_apiService, _animal));
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AnimalEditPage(_apiService, _animal));
    }
}