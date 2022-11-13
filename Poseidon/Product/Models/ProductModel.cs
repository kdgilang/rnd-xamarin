using System;
using Poseidon.Models;

namespace Poseidon.Product.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }

        public long Quantity { get; set; }

        public long QuantityNotify { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        private PriceModel _price;
        public PriceModel Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public PriceModel MemberPrice { get; set; }

        public int Discount { get; set; }

        public ImageModel Image { get; set; }
    }
}
