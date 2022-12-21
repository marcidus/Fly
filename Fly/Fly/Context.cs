using Fly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Context : DbContext
    {
        public DbSet<Airline> AirlineSet { get; set; }
        public DbSet<Baggage> BaggageSet { get; set; }
        public DbSet<FlightPassenger> FlightsPassengerSet { get; set; }
        public DbSet<Flight> FlightSet { get; set; }
        public DbSet<Paiement> PaiementSet { get; set; }
        public DbSet<Passenger> PassengerSet { get; set; }
        public DbSet<Seat> SeatSet { get; set; }

        public static string ConnectionString { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alexandre The Goat\Documents\fly2.0.mdf"";Integrated Security=True;Connect Timeout=30";

        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseSqlServer(ConnectionString);
        }
    }
}
