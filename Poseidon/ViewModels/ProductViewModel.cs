using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Poseidon.Product.Models;
using Poseidon.Models;
using Poseidon.Configs;
using Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase;
using System.Windows.Input;

namespace Poseidon.ViewModels
{
    public class ProductViewModel : UserViewModel
    {
        private readonly IGetProductsByCompanyIdUseCase _getProductsByCompanyId;

        public ProductViewModel()
        {
            _getProductsByCompanyId = DependencyService.Get<IGetProductsByCompanyIdUseCase>();
        }

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
            try
            {
                if (IsBusy)
                {
                    return;
                }

                 IsBusy = true;

                var res = await _getProductsByCompanyId.ExecuteAsync(CompanyId);

                Device.BeginInvokeOnMainThread(() => {

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
                });
                IsBusy = false;
            }
            catch(Exception e)
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Unable to load data", $"{e.Message}", "ok");
            }
        }

        public ICommand RefreshCommandAsync =>
            new Command(() =>
            {
                Device.InvokeOnMainThreadAsync(PopulateDataAsync);
            }
        );

        public virtual void OnAppearing()
        {
            Device.InvokeOnMainThreadAsync(PopulateDataAsync);
        }
    }
}
