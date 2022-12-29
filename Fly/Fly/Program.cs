using System;

namespace Fly
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
            var Passenger1 = new Passenger { Birthday = new DateTime(1992, 07, 22), Email = "jeremie@gmail.com", FullName = "Dellea", Surname = "Jeremie", };
            var Passenger2 = new Passenger { Birthday = new DateTime(1973, 06, 11), Email = "alex@hotmail.com", FullName = "Martroye", Surname = "Alexandre", };
            var Passenger3 = new Passenger { Birthday = new DateTime(1988, 10, 08), Email = "darkside@deathstar.com", FullName = "Skywalker", Surname = "Anakin" };
            var Passenger4 = new Passenger { Birthday = new DateTime(1955, 04, 22), Email = "hellothere@force.com", FullName = "Kenobi", Surname = "Obi-wan" };

            ctx.PassengerSet.Add(Passenger1);
            ctx.PassengerSet.Add(Passenger2);
            ctx.PassengerSet.Add(Passenger3);
            ctx.PassengerSet.Add(Passenger4);

            ctx.SaveChanges();
        }
    }
}