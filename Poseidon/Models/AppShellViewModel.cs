using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Poseidon.Configs;

namespace Poseidon.Models
{
    public class AppShellViewModel : UserModel
    {
        public AppShellViewModel()
        {
           
        }


        public ICommand LogoutCommandAsync => new Command(async () =>
        {
            Shell.Current.FlyoutIsPresented = false;

            AuthenticatedUser.logutUser();

            await Task.Delay(1000);

            await Shell.Current.GoToAsync("//login");
        });
    }
}
