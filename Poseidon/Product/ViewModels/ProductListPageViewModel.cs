using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Poseidon.ViewModels;
using Xamarin.Forms;

namespace Poseidon.Product.ViewModels
{
    public class ProductListPageViewModel : ProductsViewModel
    {
        public ProductListPageViewModel()
        {
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();
        }


        public ICommand DeleteCommandAsync =>
            new Command<string>(async (string id) =>
            {
                await App.Current.MainPage.DisplayAlert($"Delete {id}", "This action is TBA", "ok");
            }
        );

        public ICommand EditCommandAsync => new Command<string>(async (string id) =>
        {
            await App.Current.MainPage.DisplayAlert($"Edit {id}", "This action is TBA", "ok");
        });
    }
}
