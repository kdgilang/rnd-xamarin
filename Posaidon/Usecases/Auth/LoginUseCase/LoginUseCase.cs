using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Posaidon.Services.Graphql;
using Posaidon.Usecases.Auth.LoginUseCase;

[assembly: Xamarin.Forms.Dependency(typeof(LoginUseCase))]
namespace Posaidon.Usecases.Auth.LoginUseCase
{
    public class LoginUseCase : ILoginUsecase
    {
        private readonly IGraphqlService _graphqlService;

        public LoginUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<LoginResponse> LoginAsync()
        {
            try
            {
                var res = await _graphqlService.QueryAsync<LoginResponse>
                 (
                     @"
                    mutation {
                        login(input: { identifier: roby@gmail.com, password: Roby123 }) {
                            jwt
                            user {
                                id
                                username
                            }
                        }
                    }"
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
