using System.Threading.Tasks;
using Poseidon.Pages.Auth;
using Xamarin.Forms;
using Poseidon.Configs;

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
            var user = await AuthenticatedUser.getAuthenticatedUserAsync();
            var userId = user?.UsersPermissionsUser?.Data?.Id.ToString();

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
