using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Poseidon.Models;

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
            //RegisterRoutes();

            BindingContext = new AppShellViewModel();
        }

        //void RegisterRoutes()
        //{
        //    Routes.Add("login", typeof(LoginPage));
        //    Routes.Add("home", typeof(MainPage));

        //    foreach (var item in Routes)
        //    {
        //        Routing.RegisterRoute(item.Key, item.Value);
        //    }
        //}
    }
}
