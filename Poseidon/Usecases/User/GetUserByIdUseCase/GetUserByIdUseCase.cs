using System;
using System.Threading.Tasks;
using Poseidon.Services.Graphql;
using Xamarin.Forms;
using Poseidon.Usecases.User.GetUserByIdUseCase;

[assembly: Dependency(typeof(GetUserByIdUseCase))]
namespace Poseidon.Usecases.User.GetUserByIdUseCase
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IGraphqlService _graphqlService;

        public GetUserByIdUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<GetUserByIdResponse> GetUserByIdAsycn(int id)
        {
            try
            {
                string query = @"
                query User($id: ID!) {
                    usersPermissionsUser(id: $id) {
                        data {
                            id
                            attributes {
                                email
                                username
                                name
                                phone
                                address
                                confirmed
                                updatedAt
                                createdAt
                                company {
                                  data{
                                    id
                                    attributes {
                                      name
                                    }
                                  }
                                }
                                image {
                                  data {
                                    attributes {
                                      url
                                      name
                                      caption
                                      alternativeText
                                    }
                                  }
                                }
                                role {
                                    data {
                                        attributes {
                                            type
                                        }
                                    }
                                }
                            }
                        }
                    }
                }";

                var res = await _graphqlService.QueryAsync<GetUserByIdResponse>
                    (
                        query,
                        "User",
                        new { id = id }
                    );

                var user = res.Data;

                if (user?.UsersPermissionsUser?.Data?.Id > 0)
                {

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
