using MyTestMauiApp.View;

namespace MyTestMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CatDetailsPage), typeof(CatDetailsPage));
    }
}
