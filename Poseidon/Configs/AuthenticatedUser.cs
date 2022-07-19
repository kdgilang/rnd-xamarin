using System.Threading.Tasks;
using Xamarin.Essentials;
using Poseidon.Usecases.User.GetUserByIdUseCase;
using Newtonsoft.Json;

namespace Poseidon.Configs
{
    public static class AuthenticatedUser
    {

        public static async Task<GetUserByIdResponse> getAuthenticatedUserAsync()
        {

            var userJson = await SecureStorage.GetAsync("user");


            if (userJson == null)
            {
                return null;
            }

            App.Current.Properties["user"] = userJson;

            return JsonConvert.DeserializeObject<GetUserByIdResponse>(userJson);
        }

        public static GetUserByIdResponse getAuthenticatedUser()
        {

            if (App.Current.Properties.ContainsKey("user"))
            {
                var userJson = App.Current.Properties["user"].ToString();

                return JsonConvert.DeserializeObject<GetUserByIdResponse>(userJson);
            }

            return null;
        }

        public static void logutUser()
        {
            SecureStorage.Remove("user");
            SecureStorage.Remove("userToken");
        }

        public static async void Save(string userToken, object user)
        {
            App.Current.Properties["user"] = user;
            await SecureStorage.SetAsync("user", JsonConvert.SerializeObject(user));
            await SecureStorage.SetAsync("userToken", userToken);
        }
    }
}
