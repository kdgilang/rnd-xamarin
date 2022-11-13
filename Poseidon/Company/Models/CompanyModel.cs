using System;
using System.Collections.ObjectModel;
using Poseidon.Product.Models;
using Poseidon.Models;

namespace Poseidon.Company.Models
{
    public class CompanyModel : BaseModel
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public bool IsActive { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public int Tax { set; get; }
        public ImageModel Image { set; get; }
        private ObservableCollection<ProductModel> Products { set; get; }
    }
}

