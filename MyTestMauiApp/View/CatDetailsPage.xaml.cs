using MyTestMauiApp.ViewModel;

namespace MyTestMauiApp.View;

public partial class CatDetailsPage : ContentPage
{
    public CatDetailsPage(CatDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}