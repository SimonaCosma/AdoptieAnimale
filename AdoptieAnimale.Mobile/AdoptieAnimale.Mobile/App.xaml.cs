using AdoptieAnimale.Mobile.Views;
using AdoptieAnimale.Mobile.Services;

namespace AdoptieAnimale.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Pornește cu LoginPage
        var apiService = new ApiService();
        MainPage = new NavigationPage(new LoginPage(apiService));
    }
}