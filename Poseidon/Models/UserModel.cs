using Poseidon.Configs;
using Poseidon.Usecases.User.GetUserByIdUseCase;

namespace Poseidon.Models
{
    public class UserModel
    {
        private readonly GetUserByIdResponse _user;

        public UserModel()
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

        public string ImageCoverUrl
        {
            get
            {
                string imgUrl = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Company.Data.Attributes.Image.Data.Attributes.Url;
                return string.IsNullOrEmpty(imgUrl) ? "bg1.jpeg" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }
    }
}
