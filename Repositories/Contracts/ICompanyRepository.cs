using Entities;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>{
        
        IQueryable<Company> GetAllCompanies(bool trackChanges);
        Company? GetOneCompany(string id, bool trackChanges);
        Company? GetOneCompanyWithName(string name, bool trackChanges);

        
        public Company? GetOneCompany(int id, bool trackChanges);
        void  CreateCompany(Company company);
        void Delete(Company company);
        void UpdateOneCompany(Company entity);
    }
}