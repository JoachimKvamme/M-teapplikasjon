using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Møteapplikasjon.Controllers;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.View
{
    public class MeetingView
    {
        private readonly MeetingController _meetingController;
        public MeetingView(MeetingController meetingController)
        {
            _meetingController = meetingController;
        }

        public void ViewData(List<Meeting> meetings)
        {
            foreach (var item in meetings)
            {
                string participantString = String.Join(", ", item.Participants);
                Console.WriteLine($"Møtetittel: {item.Title}, Dato: {item.Date}, Klokkeslett: {item.TimeOfDay}, Deltakere: {participantString}, MøteId: {item.Id}");
            }
        }
    }
}