using System;
using System.Threading.Tasks;

namespace Poseidon.Usecases.Auth.LoginUseCase
{
    public interface ILoginUseCase
    {
        Task<LoginResponse> LoginAsync(string email, string password);
    }
}
