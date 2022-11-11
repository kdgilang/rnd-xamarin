using System;
using System.Collections.Generic;
using Poseidon.Pages;
using Poseidon.Pos.ViewModels;
using Poseidon.Product.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

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

            ((PosPageViewModel)BindingContext).OnAppearing();
        }

        public void OnToggleScanner(object sender, EventArgs e)
        {
            _vm.IsCameraViewVisible = !_vm.IsCameraViewVisible;

            _vm.ScanButtonText = _vm.IsCameraViewVisible ? "Close" : "Scan";

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

        public void OnQuantityChanged(object sender, ValueChangedEventArgs e)
        {
            _vm.Cart.Items[0].Quantity += 1;
        }
    }
}

