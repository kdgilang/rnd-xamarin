using System;
using System.Collections.Generic;
using Poseidon.Pos.ViewModels;
using Poseidon.Product.ViewModels;
using Xamarin.Forms;

namespace Poseidon.Pos.Pages
{
    public partial class PosPage : ContentPage
    {
        public PosPage()
        {
            InitializeComponent();
            BindingContext = new PosPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((PosPageViewModel)BindingContext).OnAppearing();
        }
    }
}

