using System;
using Xamarin.Forms;
using Poseidon.Auth.ViewModels;

namespace Poseidon.Auth.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}
