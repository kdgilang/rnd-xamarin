using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using Poseidon.Product.Models;
using System.Windows.Input;
using Poseidon.ViewModels;
using Poseidon.Models;
using Poseidon.Configs;
using Poseidon.Product.UseCases.UpdateProductByIdUseCase;
using Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase;

namespace Poseidon.Product.ViewModels
{
    public class ProductsPageViewModel : UserViewModel
    {
        private readonly IGetProductsByCompanyIdUseCase _getProductsByCompanyId;

        private readonly IUpdateProductByIdUseCase _updateProductById;

        public ProductsPageViewModel()
        {
            _getProductsByCompanyId = DependencyService.Get<IGetProductsByCompanyIdUseCase>();
            _updateProductById = DependencyService.Get<IUpdateProductByIdUseCase>();
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

        private List<ProductModel> _products;
        public List<ProductModel> Products
        {
            get => _products;

            set
            {
                _products = value;
                ActiveProducts = value;
                ArchivedProducts = value;
                OnPropertyChanged("Products");
            }
        }

        private List<ProductModel> _activeProducts;
        public List<ProductModel> ActiveProducts
        {
            get => _activeProducts?.Where(item => item.IsActive).ToList();

            set
            {
                _activeProducts = value;
                IsActiveProductsEmpty = ActiveProducts.Count() < 1;
                OnPropertyChanged("ActiveProducts");
            }
        }

        private List<ProductModel> _archivedProducts;
        public List<ProductModel> ArchivedProducts
        {
            get => _archivedProducts?.Where(item => !item.IsActive).ToList();

            set
            {
                _archivedProducts = value;
                IsArchivedProductsEmpty = ArchivedProducts.Count() < 0;
                OnPropertyChanged("ArchivedProducts");
            }
        }

        private bool _isActiveProductsEmpty;
        public bool IsActiveProductsEmpty
        {
            get => _isActiveProductsEmpty;

            set
            {
                _isActiveProductsEmpty = value;
                OnPropertyChanged("IsActiveProductsEmpty");
            }
        }

        private bool _isArchivedProductsEmpty;
        public bool IsArchivedProductsEmpty
        {
            get => _isArchivedProductsEmpty;

            set
            {
                _isArchivedProductsEmpty = value;
                OnPropertyChanged("IsArchivedProductsEmpty");
            }
        }

        public async Task PopulateDataAsync()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;
                var res = await _getProductsByCompanyId.ExecuteAsync(CompanyId);
                Products = res?.Products?.Data?.Select(item =>
                    new ProductModel
                    {
                        Id = item.Id,
                        Name = item?.Attributes?.Name,
                        Description = item.Attributes.Description,
                        Price = item.Attributes.Price,
                        MemberPrice = item.Attributes.MemberPrice,
                        Discount = item.Attributes.Discount,
                        IsActive = item.Attributes.IsActive,
                        CreatedAt = item.Attributes.CreatedAt,
                        UpdatedAt = item.Attributes.UpdatedAt,
                        Quantity = item.Attributes.Quantity,
                        Image = new ImageModel
                        {
                            Url = $"{AppSettings.BASE_URL}{item.Attributes.Image.Data.Attributes.Url}",
                            Caption = item.Attributes.Image.Data.Attributes.Caption,
                            Name = item.Attributes.Image.Data.Attributes.Name
                        }
                    }
                ).ToList();
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Unable to load data", $"{e.Message}", "ok");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async void OnAppearing()
        {
            await PopulateDataAsync();
        }
    }
}
