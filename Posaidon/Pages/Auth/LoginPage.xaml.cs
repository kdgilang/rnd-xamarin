﻿using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Posaidon.Pages.Auth
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageModel();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
           
        }
    }
}
