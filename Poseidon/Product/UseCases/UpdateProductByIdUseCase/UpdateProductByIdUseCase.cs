using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Poseidon.Product.Models;
using Poseidon.Services.Graphql;
using Poseidon.Product.UseCases.UpdateProductByIdUseCase;

[assembly: Dependency(typeof(UpdateProductByIdUseCase))]
namespace Poseidon.Product.UseCases.UpdateProductByIdUseCase
{
    public class UpdateProductByIdUseCase : IUpdateProductByIdUseCase
    {

        private readonly IGraphqlService _graphqlService;

        public UpdateProductByIdUseCase()
        {
            _graphqlService = DependencyService.Get<IGraphqlService>();
        }

        public async Task<UpdateProductByIdResponse> ExecuteAsync(ProductModel product)
        {
            string query = @"mutation UpdateProductById(
                    $id: ID!,
                    $name: String!,
                    $description: String,
                    $isActive: Boolean!,
                    $price: Float!,
                    $memberPrice: Float,
                    $discount: Int,
                    $quantity: Int!,
                    $quantityNotify: Int
                ){
                updateProduct(
                    id: $id,
                    data:
                    {
                        name: $name,
                        description: $description,
                        is_active: $isActive,
                        price: $price,
                        member_price: $memberPrice,
                        discount: $discount,
                        quantity: $quantity,
                        quantity_notify: $quantityNotify
                    }) {
                    data{
                        id
                        attributes {
                        name
                        quantity,
                        quantity_notify
                        description
                        is_active
                        createdAt
                        updatedAt
                        price
                        member_price
                        discount
                             image{
                                data{
                                    attributes {
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
                var res = await _graphqlService.QueryAsync<UpdateProductByIdResponse>
                (
                    query,
                    "UpdateProductById",
                    new
                    {
                        id = product.Id,
                        name = product.Name,
                        description = product?.Description,
                        price = product.Price,
                        memberPrice = product?.MemberPrice,
                        discount = product?.Discount,
                        quantity = product.Quantity,
                        quantityNotify = product?.QuantityNotify,
                        isActive = product?.IsActive
                    }
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
