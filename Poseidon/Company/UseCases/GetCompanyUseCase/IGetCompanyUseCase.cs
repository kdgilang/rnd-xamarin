using System;
using System.Threading.Tasks;

namespace Poseidon.Company.UseCases.GetCompanyUseCase
{
    public interface IGetCompaniesUseCase
    {
        Task<CompaniesResponse> GetCompaniesAsync();
    }
}
