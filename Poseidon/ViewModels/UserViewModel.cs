using Poseidon.Configs;
using Poseidon.User.UseCases.GetUserByIdUseCase;
using Poseidon.User.Models;
using Poseidon.Models;
using Poseidon.Company.Models;

namespace Poseidon.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly GetUserByIdResponse _userRes;

        public UserViewModel()
        {
            _userRes = AuthenticatedUser.getAuthenticatedUser();

            ApplyPopulateData();
        }

        private UserModel _user;
        public UserModel User
        {
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
            get => _user;
        }

        public string Name
        {
            get => User.Name;
        }

        public string TaxFormattedText
        {
            get => $" ({User.Company.Tax.ToString()}%)";
        }

        public long CompanyId
        {
            get => User.Company.Id;
        }

        public string ImageUrl
        {
            get
            {
                string imgUrl = User?.Image?.Url;
                return string.IsNullOrEmpty(imgUrl) ? "poseidon.png" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }

        public string ImageCoverUrl
        {
            get
            {
                string imgUrl = User?.Company?.Image?.Url;
                return string.IsNullOrEmpty(imgUrl) ? "bg1.jpeg" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }

        public void ApplyPopulateData()
        {

            if (_userRes == null)
            {
                return;
            }

            var userData = _userRes.UsersPermissionsUser.Data;
            var companyData = userData.Attributes.Company.Data;

            User = new UserModel
            {
                Id = userData.Id,
                UserName = userData.Attributes.Username,
                Name = userData.Attributes.Name,
                Address = userData.Attributes.Address,
                Email = userData.Attributes.Email,
                Phone = userData.Attributes.Phone,
                CreatedAt = userData.Attributes.CreatedAt,
                UpdatedAt = userData.Attributes.UpdatedAt,
                IsBlocked = userData.Attributes.IsBlocked,
                IsConfirmed = userData.Attributes.IsConfirmed,
                Image = new ImageModel
                {
                    Id = userData.Attributes.Image.Data.Id,
                    Url = userData?.Attributes?.Image?.Data?.Attributes?.Url,
                    Caption = userData?.Attributes?.Image?.Data?.Attributes?.Caption,
                    Name = userData?.Attributes?.Image?.Data?.Attributes?.Name
                },
                Company = new CompanyModel
                {
                    Id = companyData.Id,
                    Name = companyData.Attributes.Name,
                    Tax = companyData.Attributes.Tax,
                    IsActive = companyData.Attributes.IsActive,
                    Email = "",
                    Phone = "",
                    Address = "",
                    CreatedAt = new System.DateTime(),
                    UpdatedAt = new System.DateTime(),
                    Image = new ImageModel
                    {
                        Id = companyData.Attributes.Image.Data.Id,
                        Url = companyData?.Attributes?.Image?.Data?.Attributes?.Url,
                        Caption = companyData?.Attributes?.Image?.Data?.Attributes?.Caption,
                        Name = companyData?.Attributes?.Image?.Data?.Attributes?.Name
                    }
                }
            };
        }
    }
}
