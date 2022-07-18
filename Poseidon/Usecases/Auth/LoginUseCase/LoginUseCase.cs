using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Poseidon.Services.Graphql;
using Poseidon.Usecases.Auth.LoginUseCase;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(LoginUseCase))]
namespace Poseidon.Usecases.Auth.LoginUseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IGraphqlService _graphqlService;

        public LoginUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            try
            {
                string query = @"
                mutation Login($email: String!, $password: String!) {
                    login(input: { identifier: $email, password: $password }) {
                        jwt
                        user {
                            id
                            username
                        }
                    }
                }";

                var res = await _graphqlService.QueryAsync<LoginResponse>
                    (
                        query,
                        "Login",
                        new { email = email, password = password }
                    );

                var user = res.Data;

                if (user?.Login?.User?.Id > 0)
                {
                    await SecureStorage.SetAsync("userID", user.Login.User.Id.ToString());
                    await SecureStorage.SetAsync("userToken", user.Login.Jwt);

                    return user;
                }

                throw new InvalidOperationException(res.Errors[0].Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                throw e;
            }
        }
    }
}
