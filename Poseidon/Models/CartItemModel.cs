using System;
using Poseidon.Product.Models;

namespace Poseidon.Models
{
    public class CartItemModel
    {
        public long Id { set; get; }
        public int Quantity { set; get; }
        public ProductModel Product { set; get; }
    }
}

