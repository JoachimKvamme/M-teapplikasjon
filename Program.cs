using Møteapplikasjon.Controllers;
using Møteapplikasjon.Data;
using Møteapplikasjon.Models;
using Møteapplikasjon.View;

namespace Møteapplikasjon;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var context = new ApplicationDbContext();
        MeetingController controller = new MeetingController(context);
        var view = new MeetingView(controller);

        //controller.Create();
        // List<Meeting> meetings = controller.Get();
        // view.ViewData(meetings);
        bool flag = true;
        while(flag == true)
        {
            Console.WriteLine("Velkommen til møteapplikasjonen! Her kan du se hvilke møter du har lagret, legge til nye møter, endre eller slette møter.");
            Console.WriteLine("Her er møtene du har lagret per nå:");
            view.ViewData(controller.Get());
            Console.WriteLine("For å legge til et nytt møte, skriv 'Legg til', for å slette skriv 'slett' og for å oppdatere møtedata, skriv 'oppdater'. Hvis du vil ha opp møtelisten igjen, skriv 'se'. Vil du se et enkelt møte, skriv 'enkel'. For å gå ut av applikasjonen, skriv q eller quit.");
            string answer = Console.ReadLine().ToLower();
            switch(answer)
            {
                case "legg til":
                    controller.Create();
                    break;
                case "slett":
                    Console.WriteLine("Skriv inn møteId-en til det møtet du vil slette.");
                    int id = int.Parse(Console.ReadLine());
                    controller.Delete(id);
                    break;
                case "oppdater":
                    Console.WriteLine("Skriv inn møteId-en til det møtet du vil oppdatere.");
                    int updateid = int.Parse(Console.ReadLine());
                    controller.Update(updateid);
                    break;
                case "se":
                    view.ViewData(controller.Get());
                    break;
                case "enkel":
                    Console.WriteLine("Skriv inn møteId-en til det møtet du vil hente.");
                    int viewId = int.Parse(Console.ReadLine());
                    view.ViewById(viewId);
                    break;
                case "q":
                case "quit":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Noe gikk galt, prøv igjen");
                    continue;
            }
        }
    }
}
