﻿using System.ComponentModel;

namespace Poseidon.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
        }

        private bool _isloading;
        public bool IsLoading
        {
            get
            {
                return _isloading;
            }

            set
            {
                _isloading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
