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
                Console.WriteLine($"Møtetittel: {item.Title},\n Dato: {item.Date},\n Klokkeslett: {item.TimeOfDay}, \n Deltakere: {participantString}, \n MøteId: {item.Id}");
            }
        }
        public void ViewById(int id)
        {
            var meeting = _meetingController.GetById(id);
            if(meeting == null)
            {
                Console.WriteLine("Det finnes intet møte med den møteId-en");
                return;
            }
            string participantString = String.Join(", ", meeting.Participants);     
            Console.WriteLine($"Møtetittel: {meeting.Title},\n Dato: {meeting.Date},\n Klokkeslett: {meeting.TimeOfDay},\n Deltakere: {participantString},\n MøteId: {meeting.Id}");
        }
    }
}