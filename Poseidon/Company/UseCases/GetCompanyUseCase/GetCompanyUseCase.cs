using System;
using Xamarin.Forms;
using Poseidon.Services.Graphql;
using System.Threading.Tasks;
using Poseidon.Company.UseCases.GetCompanyUseCase;

[assembly: Dependency(typeof(GetCompanyUseCase))]
namespace Poseidon.Company.UseCases.GetCompanyUseCase
{
    public class GetCompanyUseCase : IGetCompaniesUseCase
    {

        private readonly IGraphqlService _graphqlService;

        public GetCompanyUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<CompaniesResponse> GetCompaniesAsync()
        {
            try
            {
                var res = await _graphqlService.QueryAsync<CompaniesResponse>
                (
                    @"query {
                        companies {
                            data {
                                id
                                attributes {
                                    name
                                    address
                                    email
                                    phone
                                    createdAt
                                }
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
