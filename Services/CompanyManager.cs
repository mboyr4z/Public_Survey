using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using SQLitePCL;
using Survey.Benimkiler;

namespace Services
{
    public class CompanyManager : ICompanyService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CompanyManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreateCompany(company_createDto company)
        {
            Company newCompany = _mapper.Map<Company>(company);
            _manager.Company.CreateCompany(newCompany);
            _manager.Save();
        }

        public void Delete(Company company)
        {
            _manager.Company.Delete(company);
            _manager.Save();
        }

        public IQueryable<Company> GetAllCompanies(bool trackChanges)
        {
           return _manager.Company.GetAllCompanies(trackChanges);
        }
     
        public Company GetOneCompany(int id, bool trackChanges)
        {
            return _manager.Company.GetOneCompany(id, trackChanges);
        }

        public Company GetOneCompanyWithName(string name, bool trackChanges)
        {
            return _manager.Company.GetOneCompanyWithName(name,trackChanges);
        }

        public void UpdateOneCompany(company_updateDto entity)
        {
            Company updateingCompany = _mapper.Map<Company>(entity);

            _manager.Company.UpdateOneCompany(updateingCompany);
            _manager.Save();
        }
    }
}