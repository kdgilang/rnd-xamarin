using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase;
using Poseidon.Product.Models;
using Poseidon.Models;
using Poseidon.Configs;

namespace Poseidon.ViewModels
{
    public class ProductsViewModel : UserViewModel
    {
        private readonly IGetProductsByCompanyIdUseCase _getProductsByCompanyId;

        public ProductsViewModel()
        {
            _getProductsByCompanyId = DependencyService.Get<IGetProductsByCompanyIdUseCase>();

            PopulateDataAsync();
        }

        private List<ProductModel> _products;
        public List<ProductModel> Products
        {
            set
            {
                _products = value;
                ActiveProducts = value;
                OnPropertyChanged("Products");
            }

            get => _products;
        }

        private List<ProductModel> _activeProducts;
        public List<ProductModel> ActiveProducts
        {
            set
            {
                _activeProducts = value;
                OnPropertyChanged("ActiveProducts");
            }

            get => _activeProducts?.Where(item => item.IsActive).ToList();
        }

        public async Task PopulateDataAsync()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;

            try
            {
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

                IsLoading = false;
            }
            catch(Exception e)
            {
                IsLoading = false;
                await App.Current.MainPage.DisplayAlert("Unable to load data", $"{e.Message}", "ok");
            }
        }
    }
}
