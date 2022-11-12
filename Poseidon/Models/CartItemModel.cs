using System;
using Poseidon.Product.Models;

namespace Poseidon.Models
{
    public class CartItemModel: BaseModel
    {
        private int _quantity;
        public int Quantity
        {
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
            get => _quantity;
        }

        private ProductModel _product;
        public ProductModel Product
        {
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
            get => _product;
        }
    }
}

