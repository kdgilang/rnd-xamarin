﻿using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using Poseidon.Auth.UseCases.LoginUseCase;

namespace Poseidon.Auth.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly ILoginUseCase _loginUseCase;
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
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

        private bool _isEmailError;
        public bool IsEmailError
        {
            get
            {
                return _isEmailError;
            }
            set
            {
                _isEmailError = value;
                OnPropertyChanged("IsEmailError");
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

        private bool _isPasswordError;
        public bool IsPasswordError
        {
            get
            {
                return _isPasswordError;
            }
            set
            {
                _isPasswordError = value;
                OnPropertyChanged("IsPasswordError");
            }
        }


        private bool _isSubmitted;
        public bool IsSubmitted
        {
            get
            {
                return _isSubmitted;
            }
            set
            {
                _isSubmitted = value;
                OnPropertyChanged("IsSubmitted");
            }
        }

        public ICommand LoginCommandAsync => new Command(async () =>
        {
            IsEmailError = string.IsNullOrEmpty(Email);
            IsPasswordError = string.IsNullOrEmpty(Password);

            if (IsPasswordError || IsEmailError || IsSubmitted)
            {
                return;
            }

            IsSubmitted = true;

            try
            {
                await _loginUseCase.ExecuteAsync(Email, Password);
                await Shell.Current.GoToAsync("///home");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Login failed", $"{e.Message}, \nplease try again.", "Ok");
            }
            finally
            {
                IsSubmitted = false;
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