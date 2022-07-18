using System;
using System.Threading.Tasks;

namespace Poseidon.Usecases.Company.GetCompanyUseCase
{
    public interface IGetCompaniesUseCase
    {
        Task<CompaniesResponse> GetCompaniesAsync();
    }
}
