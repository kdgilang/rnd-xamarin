using System;
using Xamarin.Forms;
using Poseidon.ViewModels;
using Poseidon.Product.UseCases.UpdateProductByIdUseCase;

namespace Poseidon.Product.ViewModels
{
    public class ProductArchivesPageViewModel : ProductsViewModel
    {
        private readonly IUpdateProductByIdUseCase _updateProductById;

        public ProductArchivesPageViewModel()
        {
            _updateProductById = DependencyService.Get<IUpdateProductByIdUseCase>();
        }


        public override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
