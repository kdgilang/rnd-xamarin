using System;
using System.Threading.Tasks;

namespace Posaidon.Usecases.Auth.LoginUseCase
{
    public interface ILoginUsecase
    {
        Task<LoginResponse> LoginAsync();
    }
}
