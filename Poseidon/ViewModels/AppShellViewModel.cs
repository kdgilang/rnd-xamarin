using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Poseidon.Configs;
using Poseidon.Models;

namespace Poseidon.ViewModels
{
    public class AppShellViewModel
    {

        private readonly UserModel _user;

        public AppShellViewModel()
        {
            _user = new UserModel();
        }

        public string ImageUrl
        {
            get => _user.ImageUrl;
        }

        public string ImageCoverUrl
        {
            get => _user.ImageCoverUrl;
        }

        public string Name
        {
            get => _user.Name;
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
