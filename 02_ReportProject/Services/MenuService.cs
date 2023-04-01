using _02_ReportProject.Context;
using _02_ReportProject.Models.Entitites;
using System.Security.Cryptography.X509Certificates;

namespace _02_ReportProject.Services;

internal class MenuService
{
    private readonly CaseServices _CaseServices = new CaseServices();
    public async Task MainCase()
    {
        Console.Clear();
        Console.WriteLine("### HUVUDCase ###");
        Console.WriteLine("1. skapa en ny case");
        Console.WriteLine("2. visa alla case");
        Console.WriteLine("3. visa en specifik case");
        Console.WriteLine("4. Ändra status på ärendet");
        Console.Write("\nange ett av följande alternativ (1-4): ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                 CreateCase();
                break;

            case "2":
                await ShowAllCase();
                break;

            case "3":
                await ShowSpecificCase();
                break;

            case"4":
                Convertstatus();
                break;
        }
        Console.ReadKey();

    }

    public void  CreateCase()
    {
        using (var context = new DataContext())
        {
            Console.Clear();
            Console.WriteLine("\n §£§£§£§£ SKAPA NY ÄRENDE §£§£§£§£");
            
            Console.Write("\nAnge förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("\nAnge efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("\nAnge e-post: ");
            var email = Console.ReadLine();

            Console.Write("\nAnge telefonnummer: ");
            var phoneNumber = Console.ReadLine();

            Console.Write("\nBeskriv ärendet: ");
            var description = Console.ReadLine();

            var time = DateTime.Now;
            var status = "Ej påbörjad";

            
            var x = new Client
            {
                FirstName = firstName,
                LasttName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

           var y = new Case
           {
               Client = x,
               Description = description,
               Time = time,
               Status = status,
           };

            context.Clients.Add(x);
            context.Cases.Add(y);

           
            context.SaveChanges();
            Console.WriteLine("\n Felanmälan skapad!");
            Console.WriteLine("\n  §£§£§£§£ §£§£§£§£ §£§£§£§£ §£§£§£§£");
        }
    }
    public async Task ShowAllCase()
    {
        Console.Clear();
        Console.WriteLine("### CASEKATALOG ###");
        foreach (var Case in await _CaseServices.GetAllAsync())
            Console.WriteLine($"{Case.CaseID}, {Case.Description}, {Case.Client.FirstName} {Case.Client.LasttName}, {Case.Status}");
    }
    public async Task ShowSpecificCase()
    {
        await ShowAllCase();

        Console.Write("Ange CaseID: ");
        var CaseID = Console.ReadLine();

        if (!string.IsNullOrEmpty(CaseID))
        {
            var Case = await _CaseServices.GetAsynsc(CaseID);
            if (Case != null)
            {
                Console.Clear();
                Console.WriteLine("### CASEINFORMATION ###");
                Console.WriteLine($" CaseID: {Case.CaseID}");
                Console.WriteLine($" FirstName: {Case.Client.FirstName}");
                Console.WriteLine($" LasttName:  {Case.Client.LasttName}");
                Console.WriteLine($" Email: {Case.Client.Email}");
                Console.WriteLine($" PhoneNumber: {Case.Client.PhoneNumber}");
                Console.WriteLine($" Description: {Case.Description}");
                Console.WriteLine($" Time: {Case.Time}");
                Console.WriteLine($" Status: {Case.Status}");
            }
            else
            {
                Console.WriteLine($"\nIngen case med CaseID {CaseID} kunde hittas.");
            }



        }
        else
        {
            Console.WriteLine("\nIngen CaseID specificerades");
        }


    }
    public void Convertstatus()
    {
        using (var context = new DataContext())
        {

            Console.Write("\nAnge ID för ärendet du vill ändra statuset: ");

            var id = int.Parse(Console.ReadLine());
            var caseById = context.Cases.FirstOrDefault(e => e.CaseID == id);


            if (caseById != null)
            {

                Console.WriteLine("\n §£§£§£§£    ÄNDRA STATUS    §£§£§£§£");
                Console.Write("Vilken status vill du sätta för ärendet? (Ej påbörjad , Påbörjad, Avslutad):");
                Console.WriteLine("\n §£§£§£§£ §£§£§£§£ §£§£§£§£ §£§£§£§£");
                var newStatus = Console.ReadLine();


                caseById.Status = newStatus;

                context.SaveChanges();

                Console.WriteLine($"Ärendet med ID {id} har uppdaterats till statusen {newStatus}.");


            }
            else
            {
                Console.WriteLine($"Ett ärende med det angivna  ID:t {id} kunde inte hittas.");
            }

        }
    }
}
