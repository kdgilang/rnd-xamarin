using System;
using System.Windows.Input;
using Poseidon.Product.Models;
using Xamarin.Forms;

namespace Poseidon.Product.Components
{
    public partial class ProductItem : ContentView
    {

        public static readonly BindableProperty ProductProperty = BindableProperty.Create(
            "Product",
            typeof(ProductModel),
            typeof(ProductItem),
            null);

        public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
            "EditCommand",
            typeof(ICommand),
            typeof(ProductItem),
            null);

        public static readonly BindableProperty ArchiveCommandProperty = BindableProperty.Create(
            "ArchiveCommand",
            typeof(ICommand),
            typeof(ProductItem),
            null);

        public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
            "DeleteCommand",
            typeof(ICommand),
            typeof(ProductItem),
            null);

        public ProductItem()
        {
            InitializeComponent();
        }

        public ProductModel Product
        {
            get => (ProductModel)GetValue(ProductProperty);
            set
            {
                SetValue(ProductProperty, value);
                //OnPropertyChanged("Product");
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
    }
}
