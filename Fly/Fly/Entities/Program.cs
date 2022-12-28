using System;

namespace Fly.Entities
{
    internal class Program
    {
        static Context ctx;

        static void Main(string[] args)
        {
            ctx = new Context();

            var e = ctx.Database.EnsureCreated();

            if (e)
                Console.WriteLine("Database has been created.");
            else
                Console.WriteLine("Database already exists");

            Console.WriteLine("done");
        }

        public static void importData()
        {
            var Passenger1 = new Passenger {Birthday= new DateTime(1992, 07, 22),Email = "jeremie@gmail.com", FullName="Dellea", Surname = "Jeremie",   };
        }
    }
}