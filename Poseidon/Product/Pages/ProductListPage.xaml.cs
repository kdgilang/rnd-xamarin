using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Poseidon.Product.ViewModels;

namespace Poseidon.Product.Pages
{
    public partial class ProductListPage : ContentPage
    {
        private ProductListPageViewModel _productList;
        public ProductListPage()
        {
            InitializeComponent();

            _productList = new ProductListPageViewModel();
            BindingContext = _productList;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await _productList.OnAppearing();
        }
    }
}
