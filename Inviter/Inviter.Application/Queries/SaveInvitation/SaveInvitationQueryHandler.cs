namespace Inviter.Application.Queries.SaveInvitation
{
    public class SaveInvitationQueryHandler : IRequestHandler<SaveInvitationQuery, bool>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestResponseRepository _guestResponseRepository;
        private readonly IInvitationRepository _invitationRepository;

        public SaveInvitationQueryHandler(IGuestRepository guestRepository, IGuestResponseRepository guestResponseRepository, IInvitationRepository invitationRepository)
        {
            _guestRepository = guestRepository;
            _guestResponseRepository = guestResponseRepository;
            _invitationRepository = invitationRepository;
        }
        public async Task<bool> Handle(SaveInvitationQuery request, CancellationToken cancellationToken)
        {
            if (request.Invitation.WillTakeAccompanyingPerson)
            {
                var guestId = await _guestRepository.Save(request.Invitation.AccompanyingPerson);
                request.Invitation.AccompanyingPerson.Response.GuestId = guestId;
                await _guestResponseRepository.Save(request.Invitation.AccompanyingPerson.Response);
            }
            else if (request.Invitation.AccompanyingPerson?.Id.HasValue ?? false)
            {
                await _guestRepository.Remove(request.Invitation.AccompanyingPerson.Id.Value);
            }

            foreach(var guest in request.Invitation.Guests)
            {
                var guestId = await _guestRepository.Save(guest);
                guest.Response.GuestId = guestId;
                await _guestResponseRepository.Save(guest.Response);
            }

            await _invitationRepository.Save(request.Invitation);

            return true;
        }
    }
}
