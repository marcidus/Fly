using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyDB _companyRepository;

        public CompanyManager(ICompanyDB companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id);
        }

        public async Task<Company> AddCompany(Company company)
        {
            return await _companyRepository.AddCompany(company);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return await _companyRepository.UpdateCompany(company);
        }

        public async Task<bool> DeleteCompany(int id)
        {
            return await _companyRepository.DeleteCompany(id);
        }
    }
}
