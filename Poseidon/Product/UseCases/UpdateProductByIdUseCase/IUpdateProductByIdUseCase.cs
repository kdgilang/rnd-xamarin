using System.Threading.Tasks;
using Poseidon.Product.Models;
namespace Poseidon.Product.UseCases.UpdateProductByIdUseCase
{
    public interface IUpdateProductByIdUseCase
    {
        Task<UpdateProductByIdResponse> ExecuteAsync(ProductModel product);
    }
}
