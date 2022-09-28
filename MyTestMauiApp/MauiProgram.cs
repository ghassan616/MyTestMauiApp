using Microsoft.Extensions.DependencyInjection;
using MyTestMauiApp.Services;
using MyTestMauiApp.View;
using MyTestMauiApp.ViewModel;

namespace MyTestMauiApp;

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

        builder.Services.AddSingleton<CatService>();
        builder.Services.AddSingleton<CatsViewModel>();
        builder.Services.AddTransient<CatDetailsViewModel>();
        builder.Services.AddTransient<CatDetailsPage>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}