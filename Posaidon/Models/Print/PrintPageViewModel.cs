using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Posaidon.Services.BlueTooth;
using Xamarin.Forms;
using ESCPOS_NET.Templates;
using Posaidon.Services.Graphql;
using Posaidon.Usecases.Company;
using System.ComponentModel;
using System.Linq;

namespace Posaidon.Models.Print
{
    public class PrintPageViewModel : INotifyPropertyChanged
    {
        private readonly IBluetoothService _bluetoothService;
        private readonly IGraphqlService _graphqlService;
        public event PropertyChangedEventHandler PropertyChanged;

        private IList<string> _devices;
        public IList<string> Devices
        {
            get
            {
                if (_devices == null)
                    _devices = new ObservableCollection<string>();

                return _devices;
            }
            set
            {
                _devices = value;
                OnPropertyChanged("Devices");

            }
        }

        private string _printText;
        public string PrintText
        {
            get
            {
                return _printText;
            }

            set
            {
                _printText = value;
                OnPropertyChanged("PrintText");
            }
        }

        private string _selectedDevice;
        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        public ICommand PrintCommand => new Command(async () =>
        {
            //await _bluetoothService.Print(SelectedDevice, Receipt.Template());
            PrintText = "Loading...";
            var companyResponse = await _graphqlService.QueryAsync<CompaniesResponse>(@"query { companies { data { id attributes { name address email phone createdAt } } } }");

            PrintText = companyResponse?.Data?.Companies.Data.FirstOrDefault().Attributes.Email;

        });

        public PrintPageViewModel ()
        {
            //_bluetoothService = DependencyService.Get<IBluetoothService>();

            _graphqlService = DependencyService.Get<IGraphqlService>();

            //var list = _bluetoothService?.GetDevices();
            //Devices.Clear();

            //if (list != null)
            //{
            //    foreach (var item in list)
            //    {
            //        Devices.Add(item);
            //    }
            //}

        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
