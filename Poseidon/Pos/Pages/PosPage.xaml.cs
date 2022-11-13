using System;
using Poseidon.Pages;
using Poseidon.Pos.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Poseidon.Models;

namespace Poseidon.Pos.Pages
{
    public partial class PosPage : BaseContentPage
    {
        private PosPageViewModel _vm;
        public PosPage()
        {
            InitializeComponent();
            _vm = new PosPageViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _vm.OnAppearing();
        }

        public void OnToggleScanner(object sender, EventArgs e)
        {
            _vm.IsCameraViewVisible = !_vm.IsCameraViewVisible;
            _vm.ScanButtonText = _vm.IsCameraViewVisible ? "Close" : "Scan";
            _vm.Cart.Items[0].Quantity = 20;

            if (_vm.IsCameraViewVisible)
            {
                ZXingScannerView scanner = new ZXingScannerView
                {
                    IsScanning = true,
                    WidthRequest = 200,
                    HeightRequest = 200,
                    ScanResultCommand = _vm.ScanCodeCommand
                };

                gridCam.Children.Add(scanner);
            }
            else
            {
                gridCam.Children.RemoveAt(0);
            }
        }

        public void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            //var stepper = (Stepper)sender;
            //var widget = (CartItemModel)stepper.BindingContext;
        }
    }
}

