using System;
using System.Threading.Tasks;

namespace Posaidon.Usecases.Company.GetCompanyUseCase
{
    public interface IGetCompaniesUseCase
    {
        Task<CompaniesResponse> GetCompaniesAsync();
    }
}
