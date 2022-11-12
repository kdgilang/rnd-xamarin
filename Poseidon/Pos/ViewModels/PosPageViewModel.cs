using System;
using System.Windows.Input;
using Poseidon.ViewModels;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ZXing.Net.Mobile.Forms;
using Poseidon.Models;
using Poseidon.Product.Models;
using System.Globalization;

namespace Poseidon.Pos.ViewModels
{
    public class PosPageViewModel : ProductViewModel
    {
        public PosPageViewModel()
        {
        }

        private CartModel _cart;
        public CartModel Cart
        {
            get => _cart;

            set
            {
                _cart = value;

                CultureInfo culture = new CultureInfo("id-ID");

                double totalPrice = 0;

                foreach (var item in Cart.Items)
                {
                    totalPrice += (item.Product.Price * item.Quantity);
                }

                TotalPrice = totalPrice.ToString("C", culture);

                OnPropertyChanged(nameof(Cart));
            }
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

        private string _totalPrice = "0";
        public string TotalPrice
        {
            get => _totalPrice;

            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
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

        public override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() =>
            {
                Cart = new CartModel
                {
                    Id = 1,
                    Note = "Sebuah note di cart",
                    Status = CartStatus.pending,
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Items = new ObservableCollection<CartItemModel>
                    {
                        new CartItemModel {
                            Id = 1,
                            Quantity = 4,
                            Product = new ProductModel
                            {
                                Id = 1,
                                Name = "Sushi ala ala",
                                Price = 20000,
                                MemberPrice = 10000,
                                Description = "Sushi mixed salad with stone & rock",
                                Discount = 4,
                                IsActive = true,
                                Quantity = 5,
                                QuantityNotify = 2,
                                Image = new ImageModel
                                {
                                    Id = 1,
                                    Url = "https://picsum.photos/200/300",
                                    Caption = "image caption 1",
                                    Name = "Image 1"
                                }
                            }
                        },
                        new CartItemModel {
                            Id = 2,
                            Quantity = 1,
                            Product = new ProductModel
                            {
                                Id = 2,
                                Name = "Nasi ala ala",
                                Price = 20000,
                                MemberPrice = 10000,
                                Description = "Nasi mixed salad with stone & rock",
                                Discount = 4,
                                IsActive = true,
                                Quantity = 5,
                                QuantityNotify = 2,
                                Image = new ImageModel
                                {
                                    Id = 1,
                                    Url = "https://picsum.photos/200/300",
                                    Caption = "image caption 1",
                                    Name = "Image 1"
                                }
                            }
                        },
                        new CartItemModel {
                            Id = 3,
                            Quantity = 2,
                            Product = new ProductModel
                            {
                                Id = 3,
                                Name = "Gorengan ala ala",
                                Price = 20000,
                                MemberPrice = 10000,
                                Description = "Gorengan mixed salad with stone & rock",
                                Discount = 4,
                                IsActive = true,
                                Quantity = 5,
                                QuantityNotify = 2,
                                Image = new ImageModel
                                {
                                    Id = 1,
                                    Url = "https://picsum.photos/200/300",
                                    Caption = "image caption 1",
                                    Name = "Image 1"
                                }
                            }
                        }
                    }
                };
            });
        }
    }
}

