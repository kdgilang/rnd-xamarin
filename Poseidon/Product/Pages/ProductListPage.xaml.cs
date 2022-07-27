using Xamarin.Forms;
using Poseidon.Product.ViewModels;

namespace Poseidon.Product.Pages
{
    public partial class ProductListPage : ContentPage
    {

        public ProductListPage()
        {
            InitializeComponent();

            BindingContext = new ProductListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ProductListPageViewModel)BindingContext).OnAppearing();
        }
    }
}
