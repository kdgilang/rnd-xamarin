using System;

using Xamarin.Forms;

namespace Poseidon.Pages
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            BackgroundColor = Color.LightGray;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}


