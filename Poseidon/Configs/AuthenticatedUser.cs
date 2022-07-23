using System.Threading.Tasks;
using Xamarin.Essentials;
using Poseidon.Usecases.User.GetUserByIdUseCase;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

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

            Preferences.Set("user", userJson);

            return JsonConvert.DeserializeObject<GetUserByIdResponse>(userJson);
        }

        public static GetUserByIdResponse getAuthenticatedUser()
        {
            string userJson = Preferences.Get("user", null);

            if (!string.IsNullOrEmpty(userJson))
            {
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
            try
            {
                var userStrJson = JsonConvert.SerializeObject(user);

                Preferences.Set("user", userStrJson);
                await SecureStorage.SetAsync("user", userStrJson);
                await SecureStorage.SetAsync("userToken", userToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
