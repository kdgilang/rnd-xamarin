using Xamarin.Forms;
using Poseidon.Product.ViewModels;

namespace Poseidon.Product.Pages
{
    public partial class ProductsPage : ContentPage
    {

        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = new ProductsPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ProductsPageViewModel)BindingContext).OnAppearing();
        }
    }
}
