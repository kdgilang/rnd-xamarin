using System;
using Xamarin.Forms;
using Poseidon.Configs;

namespace Poseidon.Pages.Auth
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageModel();
        }
    }
}
