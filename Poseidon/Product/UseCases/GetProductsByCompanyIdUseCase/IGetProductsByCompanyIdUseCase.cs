using System.Threading.Tasks;

namespace Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase
{
    public interface IGetProductsByCompanyIdUseCase
    {
        Task<GetProductsByCompanyIdResponse> ExecuteAsync(int id);
    }
}
