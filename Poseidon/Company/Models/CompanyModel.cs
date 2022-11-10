using System;
using System.Collections.Generic;
using Poseidon.Product.Models;
using Poseidon.Models;

namespace Poseidon.Company.Models
{
    public class CompanyModel
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public bool IsConfirmed { set; get; }
        public bool IsBlocked { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public ImageModel Image { set; get; }
        private List<ProductModel> Products { set; get; }
    }
}

