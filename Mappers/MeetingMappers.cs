using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Møteapplikasjon.Dto;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.Mappers
{
    public static class MeetingMappers
    {
        public static Meeting ToMeetingFromCreate(this MeetingDto meetingDto)
        {
            return new Meeting 
            {
                Participants = meetingDto.Participants,
                Title = meetingDto.Title,
                Date = meetingDto.Date,
                TimeOfDay = meetingDto.TimeOfDay
            };
        }
    }
}