using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using Poseidon.Usecases.Auth.LoginUseCase;

namespace Poseidon.Pages.Auth
{
    public class LoginPageModel : INotifyPropertyChanged
    {
        private readonly ILoginUseCase _loginUseCase;
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageModel()
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

        private bool _isError;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                OnPropertyChanged("IsError");
            }
        }

        private bool _isAuthtenticated;
        public bool IsAuthtenticated
        {
            get
            {
                return _isAuthtenticated;
            }
            set
            {
                _isAuthtenticated = value;
                OnPropertyChanged("IsAuthtenticated");
            }
        }

        public ICommand LoginCommandAsync => new Command(async () =>
        {
            //await _bluetoothService.Print(SelectedDevice, Receipt.Template());
            try
            {
                await _loginUseCase.LoginAsync(Email, Password);
                IsAuthtenticated = true;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Login failed", $"{e.Message}, \nplease try again later.", "Ok");
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
