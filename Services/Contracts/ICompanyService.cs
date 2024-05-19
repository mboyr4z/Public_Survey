using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface ICompanyService
    {

        IQueryable<Company> GetAllCompanies(bool trackChanges);
        Company? GetOneCompany(string id, bool trackChanges);

        Company? GetOneCompany(int id, bool trackChanges);
        Company? GetOneCompanyWithName(string name, bool trackChanges);
        void CreateCompany(company_createDto company);
        void Delete(Company company);
        void UpdateOneCompany(company_updateDto entity);


    }
}