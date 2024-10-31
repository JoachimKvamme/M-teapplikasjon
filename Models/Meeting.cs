using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Møteapplikasjon.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        List<Person> Participants {get; set;} = new List<Person>();
        public string Title { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public DateTime TimeOfDay { get; set; }
    }
}