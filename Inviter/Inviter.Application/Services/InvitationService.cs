using Inviter.Domain.Models;
using Inviter.Application.Interfaces.IServices;
using Inviter.Application.Interfaces.IRepositories;
using Inviter.Domain.Mappers;

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
            return InvitationMapper.Map(invitationDto, invitationGuestList);
        }
    }
}
