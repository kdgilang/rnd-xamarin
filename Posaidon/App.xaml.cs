using System;
using Posaidon.Pages.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Posaidon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
