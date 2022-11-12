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

        public double Price { get; set; }

        public double MemberPrice { get; set; }

        public int Discount { get; set; }

        public ImageModel Image { get; set; }
    }
}
