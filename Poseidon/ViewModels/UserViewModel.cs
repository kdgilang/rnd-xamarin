using Poseidon.Configs;
using Poseidon.User.UseCases.GetUserByIdUseCase;

namespace Poseidon.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly GetUserByIdResponse _user;

        public UserViewModel()
        {
            _user = AuthenticatedUser.getAuthenticatedUser();
        }

        public string Name
        {
            get => _user?.UsersPermissionsUser?.Data?.Attributes?.Name;
        }

        public string ImageUrl
        {
            get
            {
                string imgUrl = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Image?.Data?.Attributes?.Url;
                return string.IsNullOrEmpty(imgUrl) ? "poseidon.png" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }

        public long CompanyId
        {
            get => _user.UsersPermissionsUser.Data.Attributes.Company.Data.Id;
        }

        public string ImageCoverUrl
        {
            get
            {
                string imgUrl = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Company?.Data?.Attributes?.Image?.Data?.Attributes?.Url;
                return string.IsNullOrEmpty(imgUrl) ? "bg1.jpeg" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }
    }
}
