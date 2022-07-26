using System;
using Poseidon.Models;

namespace Poseidon.Product.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long Quantity { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public long Price { get; set; }

        public long MemberPrice { get; set; }

        public long Discount { get; set; }

        public ImageModel Image { get; set; }
    }
}
