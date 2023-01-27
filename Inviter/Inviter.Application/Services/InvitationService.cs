using Inviter.Domain.Models;
using Inviter.Application.Interfaces.IServices;
using Inviter.Application.Interfaces.IRepositories;
using Inviter.Domain.Mappers;
using Inviter.Domain.DbModels;

namespace Inviter.Application.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IResponseRepository _responseRepository;

        public InvitationService(IInvitationRepository invitationRepository, IGuestRepository guestRepository, IResponseRepository responseRepository)
        {
            _invitationRepository = invitationRepository;
            _guestRepository = guestRepository;
            _responseRepository = responseRepository;
        }

        public async Task<Invitation> FindAsync(Guid code)
        {
            var invitationDto = await _invitationRepository.GetInvitationAsync(code);
            var invitationGuestList = await _guestRepository.GetInvitationGuestsAsync(code);
            return InvitationMapper.Map(invitationDto, invitationGuestList);
        }

        public async Task SaveResponseAsync(Invitation invitation)
        {
            var invitationDto = new InvitationDto()
            {
                Id = invitation.Code,
                AskForRoom = invitation.AskForRoom,
                DisplayText = invitation.DisplayText,
                AccompanyingPerson = invitation.IsAccompanyingPerson,
                Notes = invitation.Notes,
                RelationType = invitation.RelationType
            };

            await _invitationRepository.SaveAsync(invitationDto);

            foreach (var guest in invitation.Guests)
            {
                var responseDto = new ResponseDto()
                {
                    GuestId = guest.Id,
                    Accomodation = guest.Response.Accomodation,
                    AfterParty = guest.Response.AfterParty,
                    WeddingParty = guest.Response.WeddingParty,
                    ResponseDateUTC = DateTime.UtcNow
                };

                await _responseRepository.SaveAsync(responseDto);
            }
        }
    }
}
