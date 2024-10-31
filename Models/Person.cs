using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Møteapplikasjon.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName {get; set;} = string.Empty;

        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }


    }
}