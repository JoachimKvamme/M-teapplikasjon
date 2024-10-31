using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.Dto
{
    public class MeetingDto
    {
        public List<string> Participants {get; set;}
        public string Title { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string TimeOfDay { get; set; } = string.Empty;
    }
}