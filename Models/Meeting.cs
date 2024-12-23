using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Møteapplikasjon.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public List<string> Participants {get; set;} = new List<string>();
        public string Title { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string TimeOfDay { get; set; } = string.Empty;
    }
}