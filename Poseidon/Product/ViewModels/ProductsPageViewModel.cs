using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using Poseidon.Product.Models;
using System.Windows.Input;
using Poseidon.ViewModels;
using Poseidon.Product.UseCases.UpdateProductByIdUseCase;
using Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase;

namespace Poseidon.Product.ViewModels
{
    public class ProductsPageViewModel : ProductsViewModel
    {

        private readonly IUpdateProductByIdUseCase _updateProductById;

        public ProductsPageViewModel()
        {
            _updateProductById = DependencyService.Get<IUpdateProductByIdUseCase>();
            Task.Run(PopulateDataAsync);
        }

        public ICommand EditCommandAsync =>
            new Command<ProductModel>(async (ProductModel product) =>
            {
                await App.Current.MainPage.DisplayAlert($"Edit {product.Id}", "This action is TBA", "ok");
            }
        );

        public ICommand ToggleArchiveCommandAsync =>
            new Command<ProductModel>(async (ProductModel product) =>
            {
                bool isAgree = await App.Current.MainPage
                    .DisplayAlert
                    (
                       product.IsActive ? "Archive" : "Unarchive",
                        "Are you sure want to continue?",
                        "Yes",
                        "Cancel"
                     );

                if (isAgree)
                {
                    IsLoading = true;

                    try
                    {
                        Products.Single(item => item.Id == product.Id).IsActive = !product.IsActive;

                        await _updateProductById.ExecuteAsync
                            (
                                Products.FirstOrDefault(x => x.Id == product.Id)
                            );

                        Products = Products;
                    }
                    catch (Exception e)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", $"{e.Message}", "ok");
                    }
                    finally
                    {
                        IsLoading = false;
                    }
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

        public override void OnAppearing()
        {
            //base.OnAppearing();
        }
    }
}
