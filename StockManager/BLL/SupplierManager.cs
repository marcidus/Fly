using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplierManager : ISupplierManager
    {
        private readonly ISupplierDB _supplierRepository;

        public SupplierManager(ISupplierDB supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _supplierRepository.GetAllSuppliers();
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _supplierRepository.GetSupplierById(id);
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            return await _supplierRepository.AddSupplier(supplier);
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            return await _supplierRepository.UpdateSupplier(supplier);
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return await _supplierRepository.DeleteSupplier(id);
        }
    }
}
}
