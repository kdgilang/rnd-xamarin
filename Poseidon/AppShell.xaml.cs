using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Poseidon.Pages.Auth;
using Poseidon.Configs;
using Poseidon.Usecases.User.GetUserByIdUseCase;

namespace Poseidon
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        private readonly GetUserByIdResponse _user;

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

            _user = AuthenticatedUser.getAuthenticatedUser();

            BindingContext = this;
        }

        public string Name
        {
            get
            {
                return _user?.UsersPermissionsUser?.Data?.Attributes?.Name;
            }
        }

        public string ImageUrl
        {
            get
            {
                return $"{AppSettings.BASE_URL}{_user?.UsersPermissionsUser?.Data?.Attributes?.Image.Data.Attributes.Url}";
            }
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

        public ICommand LogoutCommandAsync => new Command(() =>
        {
            AuthenticatedUser.logutUser();

            App.Current.MainPage = new LoginPage();
        });
    }
}
