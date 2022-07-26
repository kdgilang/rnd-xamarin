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
        private List<ProductModel> _products;

        public ProductsViewModel()
        {
            _getProductsByCompanyId = DependencyService.Get<IGetProductsByCompanyIdUseCase>();

            PopulateDataAsync();
        }

        public List<ProductModel> Products
        {
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
            get => _products;
        }

        public async Task PopulateDataAsync()
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

            IsLoading = false;
        }
    }
}
