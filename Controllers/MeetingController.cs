using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Møteapplikasjon.Data;
using Møteapplikasjon.Dto;
using Møteapplikasjon.Interfaces;
using Møteapplikasjon.Mappers;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.Controllers
{
    public class MeetingController : IMeetingController
    {
        public readonly ApplicationDbContext _context;
        public MeetingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public Meeting Create()
        {
            List<string> participants = new List<string>();
            bool flag = true;
            Console.WriteLine("Hvem skal være med på møtet? Skriv navn under:");
            while (flag == true) {
                var navn = Console.ReadLine();
                participants.Add(navn);
                Console.WriteLine("Skal møtet ha flere deltakere? Tast inn ja eller nei.");
                var answer = Console.ReadLine();
                if(answer.ToLower() == "ja"){
                    Console.WriteLine("Vennligst skriv inn navnet på en ny deltaker");
                    continue;
                } else {
                    flag = false;
                }
            }



                Console.WriteLine("Hva handler møtet om?");
                string title = Console.ReadLine();

            // DateOnly/DateTime-klassene er litt tungvinte å bruke i konsoll-applikasjoner. Jeg valgte
            // å gjøre det på denne måten hvor brukeren bare velger dager fra i dag, for å minske sjansene
            // for å få ugyldig input.
            Console.WriteLine("Hvor mange dager fra nå skal møtet finne sted? Vennligst skriv inn kun sifre.");
                
            int daysAway = int.Parse(Console.ReadLine());
            DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
            DateOnly date = dateNow.AddDays(daysAway);
            Console.WriteLine($"Møtetiden er satt til ${date}");

            Console.WriteLine("Hvilket klokkeslett skal møtet finne sted?");
            string timeOfDay = Console.ReadLine();

            var meetingDto = new MeetingDto {
                Participants = participants,
                Title = title,
                Date = date,
                TimeOfDay = timeOfDay
            };
            var meetingModel = meetingDto.ToMeetingFromCreate();

            _context.Add(meetingModel);
            _context.SaveChanges();

            return meetingModel;

            }
           

        public Meeting Delete(int id)
        {
            var meetingModel = _context.Meetings.FirstOrDefault(m => m.Id == id);
            if(meetingModel == null)
                return null;
            _context.Meetings.Remove(meetingModel);
            _context.SaveChanges();
            return meetingModel;

        }

        public List<Meeting> Get()
        {
            return _context.Meetings.ToList();
        }

        public Meeting? GetById(int id)
        {
            var meetingModel = _context.Meetings.FirstOrDefault(m => m.Id == id);
            if(meetingModel == null)
                return null;
            return meetingModel;
        }

        public Meeting Update(int id)
        {
            var existingMeeting = _context.Meetings.FirstOrDefault(m => m.Id == id);

            if(existingMeeting == null)
                return null;

            bool flag = true;
            List<string> participants = new List<string>();
            Console.WriteLine("Hvem skal være med på møtet? Skriv navn under:");
            while (flag == true) {
                var navn = Console.ReadLine();
                participants.Add(navn);
                Console.WriteLine("Skal møtet ha flere deltakere? Tast inn ja eller nei.");
                var answer = Console.ReadLine();
                if(answer.ToLower() == "ja"){
                    Console.WriteLine("Vennligst skriv inn navnet på en ny deltaker");
                    continue;
                } else {
                    flag = false;
                }
            }
            Console.WriteLine("Hva handler møtet om?");
            string title = Console.ReadLine();
            Console.WriteLine("Hvor mange dager fra nå skal møtet finne sted? Vennligst skriv inn kun sifre.");
                
            int daysAway = int.Parse(Console.ReadLine());
            DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
            DateOnly date = dateNow.AddDays(daysAway);
            Console.WriteLine($"Møtetiden er satt til ${date}");

            Console.WriteLine("Hvilket klokkeslett skal møtet finne sted?");
            string timeOfDay = Console.ReadLine();

            existingMeeting.Participants = participants;
            existingMeeting.Title = title;
            existingMeeting.Date = date;
            existingMeeting.TimeOfDay = timeOfDay;

            _context.SaveChanges();

            return existingMeeting;
        }
    }
}