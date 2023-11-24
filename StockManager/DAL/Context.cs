using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Stocks)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId);

            modelBuilder.Entity<Stock>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Stock)
                .HasForeignKey(i => i.StockId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Deliveries)
                .WithOne(d => d.Supplier)
                .HasForeignKey(d => d.SupplierId);

            modelBuilder.Entity<Delivery>()
                .HasMany(d => d.Items)
                .WithOne(i => i.Delivery)
                .HasForeignKey(i => i.DeliveryId);
        }
    }
}
