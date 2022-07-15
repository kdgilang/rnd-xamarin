using System;
using Xamarin.Forms;
using Posaidon.Services.Graphql;
using System.Threading.Tasks;
using Posaidon.Usecases.Company.GetCompanyUseCase;

[assembly: Xamarin.Forms.Dependency(typeof(GetCompanyUseCase))]
namespace Posaidon.Usecases.Company.GetCompanyUseCase
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
