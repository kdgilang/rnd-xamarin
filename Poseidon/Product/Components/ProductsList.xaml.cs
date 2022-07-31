using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Poseidon.Product.Models;
using System.Windows.Input;

namespace Poseidon.Product.Components
{
    public partial class ProductsList : ContentView
    {
        public static readonly BindableProperty ProductsProperty = BindableProperty.Create(
            "Products",
            typeof(List<ProductModel>),
            typeof(ProductsList),
            null);

        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
            "IsBusy",
            typeof(bool),
            typeof(ProductsList),
            null);

        public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
            "EditCommand",
            typeof(ICommand),
            typeof(ProductsList),
            null);

        public static readonly BindableProperty ArchiveCommandProperty = BindableProperty.Create(
            "ArchiveCommand",
            typeof(ICommand),
            typeof(ProductsList),
            null);

        public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
            "DeleteCommand",
            typeof(ICommand),
            typeof(ProductsList),
            null);

        public static readonly BindableProperty RefreshCommandProperty = BindableProperty.Create(
            "RefreshCommand",
            typeof(ICommand),
            typeof(ProductsList),
            null);

        public ProductsList()
        {
            InitializeComponent();
        }

        public List<ProductModel> Products
        {
            get => (List<ProductModel>)GetValue(ProductsProperty);
            set
            {
                SetValue(ProductsProperty, value);
            }
        }

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set
            {
                SetValue(IsBusyProperty, value);
            }
        }

        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        public ICommand ArchiveCommand
        {
            get => (ICommand)GetValue(ArchiveCommandProperty);
            set => SetValue(ArchiveCommandProperty, value);
        }

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public ICommand RefreshCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }
    }
}
