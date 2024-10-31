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
        List<Meeting> meetings = controller.Get();
        view.ViewData(meetings);
    }
}
