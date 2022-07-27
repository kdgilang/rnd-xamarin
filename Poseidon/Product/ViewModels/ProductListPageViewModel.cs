using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Poseidon.Product.Models;
using System.Windows.Input;
using Poseidon.ViewModels;

namespace Poseidon.Product.ViewModels
{
    public class ProductListPageViewModel : ProductsViewModel
    {
        public ProductListPageViewModel()
        {
        }

        public ICommand EditCommandAsync =>
            new Command<ProductModel>(async (ProductModel product) =>
            {
                await App.Current.MainPage.DisplayAlert($"Edit {product.Id}", "This action is TBA", "ok");
            }
        );

        public ICommand ArchiveCommandAsync =>
            new Command<long>(async (long id) =>
            {
                bool isDelete = await App.Current.MainPage
                    .DisplayAlert
                    (
                        "Archive",
                        "Are you sure want to archive this item?",
                        "Yes",
                        "Cancel"
                     );

                if (isDelete)
                {
                    IsLoading = true;
                    Products = Products.Where(item => item.Id == id).ToList();
                    IsLoading = false;
                }
            }
        );

        public ICommand DeleteCommandAsync =>
            new Command<long>(async (long id) =>
            {
                bool isDelete = await App.Current.MainPage
                    .DisplayAlert
                    (
                        "Delete",
                        "Are you sure want to delete this item?",
                        "Yes",
                        "Cancel"
                     );

                await App.Current.MainPage.DisplayAlert($"Delete {isDelete}", "This action is TBA", "ok");
            }
        );

        public ICommand SearchCommand =>
            new Command<string>(async (string text) =>
            {
                await App.Current.MainPage.DisplayAlert($"Edit {text}", "This action is TBA", "ok");
            }
        );

        public ICommand RefreshCommandAsync =>
            new Command(async () =>
            {
                await PopulateDataAsync();
            }
        );

        public ICommand AddCommandAsync =>
            new Command(async () =>
            {
                await App.Current.MainPage.DisplayAlert($"Add", "This action is TBA", "ok");
            }
        );
    }
}
