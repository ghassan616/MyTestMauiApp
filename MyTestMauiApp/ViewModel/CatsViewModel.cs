using CommunityToolkit.Mvvm.Input;
using MyTestMauiApp.Model;
using MyTestMauiApp.Services;
using System.Collections.ObjectModel;

namespace MyTestMauiApp.ViewModel
{
    public partial class CatsViewModel : BaseViewModel
    {
        CatService catService;
        public ObservableCollection<Cat> Cats { get; } = new();

        public CatsViewModel(CatService catService)
        {
            Title = "Cool Catz";
            this.catService = catService;
        }

        async Task AddCatAsync()
        {
            var newCat = new Cat
            {
                Name = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Breed", message: "Enter Cat Breed", placeholder: "Ex. Bengal"),
                Location = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Location", message: "Enter Cat Breed Origin Location", placeholder: "Ex. Spain"),
                Details = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Details", message: "Enter details about cat", placeholder: "Ex. This cat breed is popular in USA.")
            };
        }

        async Task DeleteCat()
        {

        }

        [RelayCommand]
        async Task GetCats()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var cats = await catService.GetCats();

                if (Cats.Count != 0)
                    Cats.Clear();

                foreach (var cat in cats)
                    Cats.Add(cat);


            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to get data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
