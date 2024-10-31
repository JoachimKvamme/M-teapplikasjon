using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.Interfaces
{
    public interface IMeetingController
    {
        Meeting Create();
        Meeting Delete(int id);
        List<Meeting> Get();
        Meeting Update(int id);
    }
}