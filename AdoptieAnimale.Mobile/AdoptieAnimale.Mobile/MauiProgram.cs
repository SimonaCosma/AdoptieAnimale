using AdoptieAnimale.Mobile.Services;
using AdoptieAnimale.Mobile.Views;
using Microsoft.Extensions.Logging;

namespace AdoptieAnimale.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Înregistrează serviciile
        builder.Services.AddSingleton<IApiService, ApiService>();

        // Înregistrează TOATE paginile
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AnimalDetailPage>();
        builder.Services.AddTransient<AnimalEditPage>();
        builder.Services.AddTransient<CategoriesPage>();
        builder.Services.AddTransient<SheltersPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<AdoptionRequestPage>();
        builder.Services.AddTransient<MyAdoptionsPage>();

        return builder.Build();
    }
}