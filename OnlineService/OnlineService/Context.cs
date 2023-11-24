using Microsoft.EntityFrameworkCore;
using OnlineService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineService
{
    internal class Context : DbContext
    {
        public DbSet<Client> ClientSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<Projet> ProjetSet { get; set; }

        public static string ConnectionString { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alexandre The Goat\Documents\OnlineProjet.mdf"";Integrated Security=True;Connect Timeout=30";
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseSqlServer(ConnectionString);
        }
    }
}
