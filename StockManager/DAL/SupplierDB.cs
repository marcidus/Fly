using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplierDB : ISupplierDB
    {
        private readonly Context _context;

        public SupplierDB(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var result = await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            var result = _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
