using System;

namespace Fly
{
    class Program
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
    }
}