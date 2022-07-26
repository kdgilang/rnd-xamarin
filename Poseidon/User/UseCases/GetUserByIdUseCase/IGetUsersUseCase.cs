using System.Threading.Tasks;

namespace Poseidon.User.UseCases.GetUserByIdUseCase
{
    public interface IGetUserByIdUseCase
    {
        Task<GetUserByIdResponse> GetUserByIdAsycn(int id);
    }
}
