using System.Threading.Tasks;

namespace Poseidon.User.UseCases.GetUserByIdUseCase
{
    public interface IGetUserByIdUseCase
    {
        Task<GetUserByIdResponse> ExecuteAsync(int id);
    }
}
