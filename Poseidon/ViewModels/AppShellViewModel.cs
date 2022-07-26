using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Poseidon.Configs;
using Poseidon.Models;

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
    }
}
