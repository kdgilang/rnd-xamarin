using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using Posaidon.Usecases.Auth.LoginUseCase;

namespace Posaidon.Pages.Auth
{
    public class AuthPageModel : INotifyPropertyChanged
    {
        private readonly ILoginUseCase _loginUseCase;
        public event PropertyChangedEventHandler PropertyChanged;

        public AuthPageModel()
        {
            _loginUseCase = DependencyService.Get<ILoginUseCase>();
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommandAsync => new Command(async () =>
        {
            //await _bluetoothService.Print(SelectedDevice, Receipt.Template());
            try
            {
                var loginRes = await _loginUseCase.LoginAsync(Email, Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        });

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
