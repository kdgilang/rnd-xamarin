using System;
using Xamarin.Forms;
using Poseidon.Configs;
using System.Threading.Tasks;
using Poseidon.Services.Graphql;
using Poseidon.Auth.UseCases.LoginUseCase;
using Poseidon.User.UseCases.GetUserByIdUseCase;

[assembly: Dependency(typeof(LoginUseCase))]
namespace Poseidon.Auth.UseCases.LoginUseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IGraphqlService _graphqlService;
        private readonly IGetUserByIdUseCase _getUserByIdUseCase;

        public LoginUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
            _getUserByIdUseCase = DependencyService.Get<IGetUserByIdUseCase>();
        }

        public async Task<LoginResponse> ExecuteAsync(string email, string password)
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
                    var userByID = await _getUserByIdUseCase.ExecuteAsync(user.Login.User.Id);

                    if (userByID.UsersPermissionsUser.Data.Attributes.Confirmed)
                    {
                        AuthenticatedUser.Save(user.Login.Jwt, userByID);

                        return user;
                    }

                    throw new InvalidOperationException("user not confirmed");
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
