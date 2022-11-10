using System;
using Poseidon.Models;
using Poseidon.Company.Models;

namespace Poseidon.User.Models
{
    public class UserModel
    {
        public long Id { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public bool IsConfirmed { set; get; }
        public bool IsBlocked { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public ImageModel Image { set; get; }
        public CompanyModel Company { set; get; }
    }
}

