using Inviter.Domain.IRepositories;
using Inviter.Domain.Models;
using Inviter.Application.IServices;

namespace Inviter.Application.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IGuestRepository _guestRepository;

        public InvitationService(IInvitationRepository invitationRepository, IGuestRepository guestRepository)
        {
            _invitationRepository = invitationRepository;
            _guestRepository = guestRepository;
        }

        public async Task<Invitation> Find(Guid code)
        {
            var invitationDto = await _invitationRepository.GetInvitation(code);
            var invitationGuestList = await _guestRepository.GetInvitationGuests(code);

            return new Invitation()
            {
                Code = invitationDto.Id,
                DisplayText = invitationDto.DisplayText,
                AccompanyingPerson = invitationDto.AccompanyingPerson,
                AskForRoom = invitationDto.AskForRoom,
                RelationType = invitationDto.RelationType,
                GuestList = invitationGuestList.Select(i => new Guest
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    IsChild = i.IsChild
                }).ToList()
            };
        }
    }
}
