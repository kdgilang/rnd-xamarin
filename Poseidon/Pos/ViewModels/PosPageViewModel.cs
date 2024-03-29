﻿using System;
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
                OnPropertyChanged(nameof(Cart));
            }
        }

        private PriceModel _totalPrice = new PriceModel();
        public PriceModel TotalPrice
        {
            get => _totalPrice;

            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private PriceModel _subTotalPrice = new PriceModel();
        public PriceModel SubTotalPrice
        {
            get => _subTotalPrice;

            set
            {
                _subTotalPrice = value;
                OnPropertyChanged(nameof(SubTotalPrice));
            }
        }

        private PriceModel _taxPrice = new PriceModel();
        public PriceModel TaxPrice
        {
            get => _taxPrice;

            set
            {
                _taxPrice = value;
                OnPropertyChanged(nameof(TaxPrice));
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
            new Command(() =>
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

        public void ApplyCalculatePrice()
        {
            double subPrice = 0;

            foreach (var item in Cart.Items)
            {
                subPrice += (item.Product.Price.Value * item.Quantity);
            }

            int tax = User.Company.Tax;

            SubTotalPrice.Value = subPrice;

            if (tax > 0)
            {
                TaxPrice.Value = (subPrice * tax) / 100;
            }
            else
            {
                TaxPrice.Value = 0;
            }

            TotalPrice.Value = subPrice + TaxPrice.Value;
        }

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
                                Price = new PriceModel
                                {
                                    Value = 35000
                                },
                                MemberPrice = new PriceModel
                                {
                                    Value = 10000
                                },
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
                                Price = new PriceModel
                                {
                                    Value = 40000
                                },
                                MemberPrice = new PriceModel
                                {
                                    Value = 15000
                                },
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
                                Price = new PriceModel
                                {
                                    Value = 10000
                                },
                                MemberPrice = new PriceModel
                                {
                                    Value = 10000
                                },
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

