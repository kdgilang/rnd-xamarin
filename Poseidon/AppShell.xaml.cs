using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Poseidon.Pages.Auth;

namespace Poseidon
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public ICommand HelpCommand => new Command<string>(async (url) =>
            await Browser.OpenAsync(url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            })
        );

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            //Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
            //Routes.Add("beardetails", typeof(BearDetailPage));
            //Routes.Add("catdetails", typeof(CatDetailPage));
            //Routes.Add("dogdetails", typeof(DogDetailPage));
            //Routes.Add("login", typeof(LoginPage));
            //Routing.RegisterRoute("elephantdetails", typeof(ElephantDetailPage));

            //foreach (var item in Routes)
            //{
            //    Routing.RegisterRoute(item.Key, item.Value);
            //}
        }



        public ICommand LogoutCommandAsync => new Command(async () =>
        {
            SecureStorage.Remove("userID");
            SecureStorage.Remove("userToken");

            App.Current.MainPage = new LoginPage();
        });
    }
}
