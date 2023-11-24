using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICompanyManager
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(int id);
    }
}
