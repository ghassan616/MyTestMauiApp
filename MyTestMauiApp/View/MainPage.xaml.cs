using MyTestMauiApp.ViewModel;

namespace MyTestMauiApp.View;

public partial class MainPage : ContentPage
{
    public MainPage(CatsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}