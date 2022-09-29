using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyTestMauiApp.Model;
using System;

namespace MyTestMauiApp.ViewModel
{
    [QueryProperty("Cat", "Cat")]
    public partial class CatDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Cat cat;

        IEmail emailService;

        public CatDetailsViewModel(IEmail emailService)
        {
            this.emailService = emailService;
        }

        [RelayCommand]
        async Task ShareCat(Cat cat)
        {
            if (cat is null)
                return;

            try
            {
                IsBusy = true;

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Unable to send email: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
