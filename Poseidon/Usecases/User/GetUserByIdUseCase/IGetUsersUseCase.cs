using System.Threading.Tasks;

namespace Poseidon.Usecases.User.GetUserByIdUseCase
{
    public interface IGetUserByIdUseCase
    {
        Task<GetUserByIdResponse> GetUserByIdAsycn(int id);
    }
}
