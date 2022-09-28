using CommunityToolkit.Mvvm.ComponentModel;
using MyTestMauiApp.Model;
using System;

namespace MyTestMauiApp.ViewModel
{
    [QueryProperty("Cat", "Cat")]
    public partial class CatDetailsViewModel : BaseViewModel
    {
        public CatDetailsViewModel()
        {

        }

        [ObservableProperty]
        Cat cat;
    }
}
