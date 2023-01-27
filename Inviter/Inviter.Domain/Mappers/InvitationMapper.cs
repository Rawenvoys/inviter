using Inviter.Domain.DbModels;
using Inviter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Mappers
{
    public static class InvitationMapper
    {
        public static Invitation Map(InvitationDto invitationDto, List<GuestDto> guestsDto) => new()
        {
            Code = invitationDto.Id,
            DisplayText = invitationDto.DisplayText,
            IsAccompanyingPerson = invitationDto.AccompanyingPerson,
            AskForRoom = invitationDto.AskForRoom,
            RelationType = invitationDto.RelationType,
            AccompanyingPerson = new()
            {
                IsChild = false,
                Response = new Response()
            },
            Guests = guestsDto.Select(i => new Guest
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                IsChild = i.IsChild,
                Response = new Response()
            }).ToList()
        };
    }
}
