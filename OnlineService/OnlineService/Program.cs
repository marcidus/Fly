using OnlineService;
using OnlineService.Model;
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

    Console.WriteLine("Seeding the DB");


    var Employee1 = new Employee() {FirstName ="Bill", LastName= "Gates", BirthDate = new DateTime(1965, 07, 07, 12, 0, 0), HireDate = new DateTime(2000, 04, 04, 12, 0, 0) };
    var Employee2 = new Employee() { FirstName = "Jeff", LastName = "Besos", BirthDate = new DateTime(1980, 09, 04, 12, 0, 0), HireDate = new DateTime(2012, 03, 02, 12, 0, 0) };
    var Employee3 = new Employee() { FirstName = "Jeff", LastName = "Olm", BirthDate = new DateTime(1975, 12, 02, 12, 0, 0), HireDate = new DateTime(2015, 10, 06, 12, 0, 0) };

    var Client1 = new Client() { Name = "Microsoft", Address = "Seattle et le lier au projet Microsoft Windows" };
    var Client2 = new Client() { Name = "Amazon", Address = "Palo Alto et lier à Amazon Glasses" };

    var Projet1 = new Projet() {Name ="Microsoft Windows 12", Description = "OS for the people", StartDate = new DateTime(2012, 01, 01, 12, 0, 0), EndDate = new DateTime(2014, 12, 31, 12, 0, 0), Budget = 2500000, client = Client1, Employee = Employee1 };
    var Projet2 = new Projet() { Name = "Amazon Glasses", Description = "Lunettes AR pour les gens", StartDate = new DateTime(2016, 05, 01, 12, 0, 0), EndDate = new DateTime(2018, 12, 31, 12, 0, 0), Budget = 11000000, client = Client2, Employee = Employee2 };


    Console.WriteLine("Adding to the context");
    ctx.EmployeeSet.Add(Employee1);
    ctx.EmployeeSet.Add(Employee2);
    ctx.EmployeeSet.Add(Employee3);

    ctx.ClientSet.Add(Client1);
    ctx.ClientSet.Add(Client2);

    ctx.ProjetSet.Add(Projet1);
    ctx.ProjetSet.Add(Projet2);



    Console.WriteLine("Save Changes to DB");
    ctx.SaveChanges();

    Console.WriteLine("SEEDING DONE");

    Console.WriteLine("\nProgramme terminé.");

}