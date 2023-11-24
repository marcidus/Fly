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

    bool isEmpty = ctx.AirlineSet.Any() &&
                    ctx.BookingSet.Any() &&
                    ctx.FlightSet.Any() &&
                    ctx.PassengerSet.Any() &&
                    ctx.PilotSet.Any();

    if (!isEmpty)
    {
        Console.WriteLine("The database is empty. Seed it.");
        seedDB(ctx);

    }
    else
    {
        Console.WriteLine("The database is not empty. No need to seed it.");
    }

    PrintFlights(ctx);

    Console.WriteLine("\nProgramme terminé.");

}

void PrintFlights(Context context)
{

    Console.WriteLine("******************************************************************");
    Console.WriteLine("\nAffichage des vols libres :");

    var volsLibres = context.FlightSet.Where(i => i.FreeSeat > 0).ToList();

    foreach (var vol in volsLibres)
    {
        Console.WriteLine("******************************************************************");
        Console.WriteLine("Vol N°" + vol.FlightNo +
                                        "\nDépart : " + vol.Depart +
                                        "\nDestination : " + vol.Destination +
                                        "\nDate du vol : " + vol.Date +
                                         "\nMois entre le départ et aujourd'hui : " + NbrMonthsBeforeDeparture(vol.Date, DateTime.Now) +
                                        "\nSièges libres : " + vol.FreeSeat +
                                        "\n% sièges remplis : " + CalculateFillingseats(vol) +
                                        "\nPrix de base du ticket : " + vol.Price + " CHF" +
                                        "\nPrix calculé du ticket : " + CalculateSalePrice(vol) + " CHF\n");
    }
    Console.WriteLine("******************************************************************");

}

void seedDB(Context context)
{

    Console.WriteLine("Seeding the DB");

    var airline1 = new Airline() { Name = "AirlineAlex" };
    var airline2 = new Airline() { Name = "AirlineJeJe" };

    var pilot1 = new Pilot() { FullName = "Radagst", Email = "radagast@gmail.com", Address = "Address3", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "pilot1" };
    var pilot2 = new Pilot() { FullName = "dagast", Email = "radagast@gmail.com", Address = "Address3", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "pilot2" };
    var pilot3 = new Pilot() { FullName = "dagast", Email = "radagast@gmail.com", Address = "Address3", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "pilot3" };

    var flight1 = new Flight() { Depart = "Genève", Destination = "Tokyo", Date = new DateTime(2024, 1, 22, 12, 0, 0), Price = 60.00, NbrSeat = 100, FreeSeat = 81, FlightNo = 3245, Occupation = 81, airline = airline1, Pilot = pilot1 };
    var flight2 = new Flight() { Depart = "Sion", Destination = "Londres", Date = new DateTime(2024, 1, 25, 18, 30, 0), Price = 80.00, NbrSeat = 200, FreeSeat = 101, FlightNo = 32457, Occupation = 101, airline = airline1, Pilot = pilot2 };
    var flight3 = new Flight() { Depart = "Sumaru City", Destination = "Tokyo", Date = new DateTime(2024, 6, 11, 17, 20, 0), Price = 47.00, NbrSeat = 65, FreeSeat = 1, FlightNo = 97583, Occupation = 1, airline = airline2, Pilot = pilot3 };

    var passenger1 = new Passenger() { FullName = "Gandalf", Email = "gandalf@gmail.com", Address = "Address1", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "Alex" };
    var passenger2 = new Passenger() { FullName = "Saruman", Email = "saruman@gmail.com", Address = "Address2", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "Alex" };
    var passenger3 = new Passenger() { FullName = "Radagast", Email = "radagast@gmail.com", Address = "Address3", Birthday = new DateTime(2023, 1, 22, 12, 0, 0), Country = "Switzerland", Surname = "Alex" };




    Booking booking1 = new Booking()
    {
        Flight = flight1,
        Passenger = passenger1,
        SalePrice = CalculateSalePrice(flight1)
    };
    flight1.FreeSeat--;


    Booking booking2 = new Booking()
    {
        Flight = flight1,
        Passenger = passenger2,
        SalePrice = CalculateSalePrice(flight1)
    };
    flight1.FreeSeat--;

    Booking booking3 = new Booking()
    {
        Flight = flight2,
        Passenger = passenger2,
        SalePrice = CalculateSalePrice(flight2)
    };
    flight2.FreeSeat--;

    Booking booking4 = new Booking()
    {
        Flight = flight2,
        Passenger = passenger3,
        SalePrice = CalculateSalePrice(flight2)
    };
    flight2.FreeSeat--;

    Booking booking5 = new Booking()
    {
        Flight = flight3,
        Passenger = passenger1,
        SalePrice = CalculateSalePrice(flight3)
    };
    flight3.FreeSeat--;

    if (true)
    {
        Console.WriteLine("Adding to the context");
        context.FlightSet.Add(flight1);
        context.FlightSet.Add(flight2);
        context.FlightSet.Add(flight3);

        context.PassengerSet.Add(passenger1);
        context.PassengerSet.Add(passenger2);
        context.PassengerSet.Add(passenger3);

        context.AirlineSet.Add(airline1);
        context.AirlineSet.Add(airline2);

        context.PilotSet.Add(pilot1);
        context.PilotSet.Add(pilot2);
        context.PilotSet.Add(pilot3);

        context.BookingSet.Add(booking1);
        context.BookingSet.Add(booking2);
        context.BookingSet.Add(booking3);
        context.BookingSet.Add(booking4);
        context.BookingSet.Add(booking5);

        Console.WriteLine("Save Changes to DB");
        context.SaveChanges();

        Console.WriteLine("SEEDING DONE");
    }

}

double CalculateSalePrice(Flight flight)
{
    // % seats fillled = (total - free) / total * 100
    double FillingSeatsPercent = CalculateFillingseats(flight);
    //Console.WriteLine("Filling Seats % = " + FillingSeatsPercent);

    if (FillingSeatsPercent >= 80)
    {
        //Console.WriteLine("1.\tIf the airplane is more than 80% full regardless of the date. \ta. sale price = 150% of the base price\r\n");
        return flight.Price * 1.5;
    }
    else if (FillingSeatsPercent < 20 &&
                NbrMonthsBeforeDeparture(flight.Date, DateTime.Now) < 2)
    {
        //Console.WriteLine("2.\tIf the plane is filled less than 20% less than 2 months before departure: \ta. sale price = 80% of the base price\r\n");
        return flight.Price * 0.8;
    }
    else if (FillingSeatsPercent < 50 &&
                NbrMonthsBeforeDeparture(flight.Date, DateTime.Now) < 1)
    {
        //Console.WriteLine("3.\tIf the plane is filled less than 50% less than 1 month before departure: \ta. sale price = 70% of the base price\r\n");
        return flight.Price * 0.7;
    }
    else
    {
        //Console.WriteLine("4.\tIn all other cases: \ta. sale price = base price\r\n");
        return flight.Price;
    }
}

double CalculateFillingseats(Flight flight)
{
    return ((double)flight.NbrSeat - (double)flight.FreeSeat) / (double)flight.NbrSeat * 100.00;
}

int NbrMonthsBeforeDeparture(DateTime FlightDate, DateTime ActualDate)
{
    int monthsbetween = 0;

    if (FlightDate.Year == ActualDate.Year)
    {
        monthsbetween = Math.Abs(FlightDate.Month - ActualDate.Month);
    }
    else
    {
        int yearsBetween = Math.Abs(FlightDate.Year - ActualDate.Year);
        int monthsInFirstYear = 12 - ActualDate.Month;
        monthsbetween = monthsInFirstYear;

        for (int i = 1; i < yearsBetween; i++)
        {
            monthsbetween += 12;
        }

    }

    //Console.WriteLine("Months between departure : " + monthsbetween);
    return monthsbetween;



}

