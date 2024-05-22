using Entities;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateCompany(Company company) => Create(company);

        public void Delete(Company company) => Remove(company);
       
        public IQueryable<Company> GetAllCompanies(bool trackChanges) =>  FindAll(trackChanges);

        public Company GetOneCompany(string id, bool trackChanges) => FindByCondition(p=> p.Id.Equals(id),false);

        public Company GetOneCompany(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id == id, false);
        }

        public Company GetOneCompanyWithName(string name, bool trackChanges)
        {
            return FindByCondition(p => p.Name.Equals(name), false);
        }

        public void UpdateOneCompany(Company entity) => Update(entity);
    }
}