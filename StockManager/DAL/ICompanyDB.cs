using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public interface ICompanyDB
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(int id);
    }
}
