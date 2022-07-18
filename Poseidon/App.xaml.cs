using System.Threading.Tasks;
using Poseidon.Pages.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Poseidon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LoginPage());
        }

        protected override async void OnStart()
        {
            string userId = await SecureStorage.GetAsync("userID");
            if (!string.IsNullOrEmpty(userId))
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
