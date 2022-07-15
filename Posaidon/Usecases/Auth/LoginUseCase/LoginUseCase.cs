using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Posaidon.Services.Graphql;
using Posaidon.Usecases.Auth.LoginUseCase;

[assembly: Xamarin.Forms.Dependency(typeof(LoginUseCase))]
namespace Posaidon.Usecases.Auth.LoginUseCase
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
                mutation Login($email: String, $password: String) {
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

                return res.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
    }
}
