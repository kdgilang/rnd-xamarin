using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Poseidon.Configs;
using Poseidon.Models;
using Xamarin.Essentials;

namespace Poseidon.ViewModels
{
    public class AppShellViewModel : UserViewModel
    {

        public AppShellViewModel()
        {
        }

        public ICommand LogoutCommandAsync => new Command(async () =>
        {
            Shell.Current.FlyoutIsPresented = false;

            AuthenticatedUser.logutUser();

            await Task.Delay(1000);

            await Shell.Current.GoToAsync("///login");
        });

        public ICommand HelpCommand => new Command<string>(async (url) =>
            await Browser.OpenAsync(url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            })
        );
    }
}
