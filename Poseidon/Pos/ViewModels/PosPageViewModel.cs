using System;
using System.Windows.Input;
using Poseidon.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace Poseidon.Pos.ViewModels
{
    public class PosPageViewModel : ProductViewModel
    {
        public PosPageViewModel() : base()
        {
        }

        private bool _isCameraViewVisible;
        public bool IsCameraViewVisible
        {
            get => _isCameraViewVisible;

            set
            {
                _isCameraViewVisible = value;
                OnPropertyChanged(nameof(IsCameraViewVisible));
            }
        }

        private string _scanButtonText = "Scan";
        public string ScanButtonText
        {
            get => _scanButtonText;

            set
            {
                _scanButtonText = value;
                OnPropertyChanged(nameof(ScanButtonText));
            }
        }

        public ICommand TapProductCommandAsync =>
            new Command(async () =>
            {
                
            }
        );

        public ICommand ScanCodeCommand =>
            new Command<ZXing.Result>( (ZXing.Result result) =>
            {
                ScanButtonText += $"{result.Text} (test)";
            }
        );
        
        public ICommand ToggleCameraComand =>
            new Command(async () =>
            {
                IsCameraViewVisible = !IsCameraViewVisible;

                ScanButtonText = IsCameraViewVisible ? "Close" : "Scan";

                if (IsCameraViewVisible)
                {
                    var scanner = new ZXingScannerView
                    {
                        IsScanning = true,
                        WidthRequest = 200,
                        HeightRequest = 200
                    };

                }
            }
        );
        
    }
}

