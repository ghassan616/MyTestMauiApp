using CommunityToolkit.Mvvm.Input;
using MyTestMauiApp.Model;
using MyTestMauiApp.Services;
using MyTestMauiApp.View;
using System.Collections.ObjectModel;
using System.Formats.Asn1;

namespace MyTestMauiApp.ViewModel
{
    public partial class CatsViewModel : BaseViewModel
    {
        CatService catService;
        public ObservableCollection<Cat> Cats { get; } = new();

        public CatsViewModel(CatService catService)
        {
            this.catService = catService;
        }

        [RelayCommand]
        async Task GoToCatDetails(Cat cat)
        {
            if (cat is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CatDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Cat", cat }
                });
        }

        [RelayCommand]
        async Task AddCat()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var newCat = new Cat
                {
                    Name = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Breed", message: "Enter Cat Breed", placeholder: "Ex. Bengal"),
                    Location = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Location", message: "Enter Cat Breed Origin Location", placeholder: "Ex. Spain"),
                    Details = await App.Current.MainPage.DisplayPromptAsync(title: "Cat Details", message: "Enter details about cat", placeholder: "Ex. This cat breed is popular in USA.")
                };

                this.catService.AddCat(newCat);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to add data: {ex.Message}", "OK");
            }
            finally
            {
                await GetCats();
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task DeleteCat(Cat cat)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                this.catService.DeleteCat(cat);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to delete data: {ex.Message}", "OK");
            }
            finally
            {
                await GetCats();
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task DeleteAllCats()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var answer = await App.Current.MainPage.DisplayAlert(title: "Delete All Cats?", message: "Are you sure you want to delete all cats?", accept: "OK", cancel: "Cancel");

                if (!answer)
                    return;

                this.catService.DeleteAllCats();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to delete data: {ex.Message}", "OK");
            }
            finally
            {
                await GetCats();
                IsBusy = false;
            }
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