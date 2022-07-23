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
                var imgId = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Image?.Data?.Id;
                string imgUrl = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Image?.Data?.Attributes?.Url;
                return imgId < 1 ? "poseidon.png" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }

        public string ImageCoverUrl
        {
            get
            {
                var imgId = _user?.UsersPermissionsUser?.Data?.Attributes?
                    .Company.Data.Attributes.Image.Data.Id;
                string imgUrl = _user?.UsersPermissionsUser?.Data?.Attributes?
                                    .Company.Data.Attributes.Image.Data.Attributes.Url;
                return imgId < 1 ? "bg1.jpeg" : $"{AppSettings.BASE_URL}{imgUrl}";
            }
        }
    }
}
