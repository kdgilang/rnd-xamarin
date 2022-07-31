using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Poseidon.Product.ViewModels;

namespace Poseidon.Product.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : TabbedPage
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
