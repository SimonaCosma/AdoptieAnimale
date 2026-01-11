using AdoptieAnimale.Mobile.Models;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile.Views;

public partial class AnimalEditPage : ContentPage
{
    private readonly IApiService _apiService;
    private readonly Animal _animal;

    public AnimalEditPage(IApiService apiService, Animal animal)
    {
        InitializeComponent();
        _apiService = apiService;
        _animal = animal;
        LoadAnimalData();
    }

    private void LoadAnimalData()
    {
        NameEntry.Text = _animal.Name;
        SpeciesEntry.Text = _animal.Species;
        BreedEntry.Text = _animal.Breed;
        AgeEntry.Text = _animal.Age?.ToString() ?? "0";
        GenderPicker.SelectedItem = _animal.Gender;
        DescriptionEditor.Text = _animal.Description;
        StatusPicker.SelectedItem = _animal.Status;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _animal.Name = NameEntry.Text;
        _animal.Species = SpeciesEntry.Text;
        _animal.Breed = BreedEntry.Text;
        _animal.Age = int.TryParse(AgeEntry.Text, out int age) ? age : 0;
        _animal.Gender = GenderPicker.SelectedItem?.ToString();
        _animal.Description = DescriptionEditor.Text;
        _animal.Status = StatusPicker.SelectedItem?.ToString();

        try
        {
            var success = await _apiService.UpdateAnimalAsync(_animal.ID, _animal);
            if (success)
            {
                await DisplayAlert("Success", "Animal actualizat cu succes!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Eroare", "Nu s-a putut actualiza animalul!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}