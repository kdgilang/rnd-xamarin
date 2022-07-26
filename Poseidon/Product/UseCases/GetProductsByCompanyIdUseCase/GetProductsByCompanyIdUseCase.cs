using System;
using System.Threading.Tasks;
using Poseidon.Services.Graphql;
using Xamarin.Forms;
using Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase;

[assembly: Dependency(typeof(GetProductsByCompanyIdUseCase))]
namespace Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase
{
    public class GetProductsByCompanyIdUseCase : IGetProductsByCompanyIdUseCase
    {
        private readonly IGraphqlService _graphqlService;

        public GetProductsByCompanyIdUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<GetProductsByCompanyIdResponse> ExecuteAsync(long id)
        {
            string query = @"query ProductsByCompanyId($id: ID!){
                products(filters: {company: {id: { eq: $id}}}){
                data{
                    id
                    attributes{
                    name
                    quantity
                    description
                    is_active
                    createdAt
                    updatedAt
                    price
                    member_price
                    discount
                    image{
                        data{
                        attributes{
                            name
                            url
                            caption
                        }
                        }
                    }
                    }
                }
                }
            }";

            try
            {
                var res = await _graphqlService.QueryAsync<GetProductsByCompanyIdResponse>
                (
                    query,
                    "ProductsByCompanyId",
                    new { id = id }
                );

                return res.Data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
