using FlyAlex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex
{
    public class Context : DbContext
    {
        public DbSet<Airline> AirlineSet { get; set; }
        public DbSet<Baggage> BaggageSet { get; set;}
        public DbSet<Booking> BookingSet { get; set; }
        public DbSet<Flight> FlightSet { get; set; }
        public DbSet<Passenger> PassengerSet { get; set;}
        public DbSet<Pilot> PilotSet { get; set; }

        public static string ConnectionString { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alexandre The Goat\Documents\AlexFly.mdf"";Integrated Security=True;Connect Timeout=30";
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseSqlServer(ConnectionString);
        }
    }
}
