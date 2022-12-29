using Fly.Entities;
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
        public DbSet<Pilot> PilotSet { get; set; }
        public DbSet<Flight> FlightSet { get; set; }
        public DbSet<Passenger> PassengerSet { get; set; }
        public DbSet<Seat> SeatSet { get; set; }

        public static string ConnectionString { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jerem\Documents\FlySierre.mdf;Integrated Security=True;Connect Timeout=30";

        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseSqlServer(ConnectionString);
        }
    }
}
