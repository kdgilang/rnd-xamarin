using System;
using System.Threading.Tasks;

namespace Poseidon.Auth.UseCases.LoginUseCase
{
    public interface ILoginUseCase
    {
        Task<LoginResponse> LoginAsync(string email, string password);
    }
}
