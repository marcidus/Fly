using FlyAlex;
using FlyAlex.Models;
using Microsoft.EntityFrameworkCore;
using System;

using (var ctx = new Context())
{
    var dbCreated = ctx.Database.EnsureCreated();

    if (dbCreated)
    {
        Console.WriteLine("Création de la base de données.");
    }
    else
    {
        Console.WriteLine("Voilà la database est créée.");
    }

    if (false)
    {
        // ------------ Insertion des données

        //Airlines
        var airline1 = new Airline() { Name = "JeremieAirlines"};
        var airline2 = new Airline() { Name = "DeJolyAirlines"};

        //Baggage
        var baggage1 = new Baggage() { BaggageSizer = 100, BaggageWeight = 30};
        var baggage2 = new Baggage() { BaggageSizer = 200, BaggageWeight = 60};
        var baggage3 = new Baggage() { BaggageSizer = 30, BaggageWeight = 10};

        //Booking
        var booking1 = new Booking() { SalePrice = 100};
        var booking2 = new Booking() { SalePrice = 200 };

        //flight

        var flight1= new Flight() { Date = DateTime.Now, Depart = "Sierre", Destination = "sion", Price = 100, FlightNo = 125, Occupation = 12, NbrSeat = 30, FreeSeat = 12 };
        var flight2 = new Flight() { Date = DateTime.Now, Depart = "Sion", Destination = "Genève", Price = 300, FlightNo = 346, Occupation = 100, NbrSeat = 500, FreeSeat = 123 };

        //passenger
        var passenger1 = new Passenger() { Birthday = new DateTime(2000,1,12), Email ="exemple@gmail.com", FullName = "Samalin", Surname ="Bustin", Country= "Swiss", Address= "Tambouctou"};
        var passenger2 = new Passenger() { Birthday = new DateTime(2000, 1, 12), Email = "exemple2@gmail.com", FullName = "Ferrari", Surname = "Simonellone", Country = "Swiss", Address = "Valais" };

        //foreign key
        ctx.AirlineSet.Add(airline1);
        ctx.AirlineSet.Add(airline2);

        ctx.BaggageSet.Add(baggage1);
        ctx.BaggageSet.Add(baggage2);
        ctx.BaggageSet.Add(baggage3);

        ctx.BookingSet.Add(booking1);
        ctx.BookingSet.Add(booking2);

        ctx.FlightSet.Add(flight1);
        ctx.FlightSet.Add(flight2);

        ctx.PassengerSet.Add(passenger1);
        ctx.PassengerSet.Add(passenger2);


    }

    ctx.SaveChanges();
}
