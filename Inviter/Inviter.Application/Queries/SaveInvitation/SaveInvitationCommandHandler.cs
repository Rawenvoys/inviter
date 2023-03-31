namespace Inviter.Application.Queries.SaveInvitation
{
    public class SaveInvitationCommandHandler : IRequestHandler<SaveInvitationCommand, bool>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IGuestResponseRepository _guestResponseRepository;

        public SaveInvitationCommandHandler(IGuestRepository guestRepository, IGuestResponseRepository guestResponseRepository)
        {
            _guestRepository = guestRepository;
            _guestResponseRepository = guestResponseRepository;
        }
        public async Task<bool> Handle(SaveInvitationCommand request, CancellationToken cancellationToken)
        {
            if (request.Invitation.WillTakeAccompanyingPerson)
            {
                var guestId = await _guestRepository.AddOrEdit(request.Invitation.AccompanyingPerson);
                request.Invitation.AccompanyingPerson.Response.GuestId = guestId;
                await _guestResponseRepository.AddOrEdit(request.Invitation.AccompanyingPerson.Response);
            }
            else if (request.Invitation.AccompanyingPerson?.Id.HasValue ?? false)
            {
                await _guestRepository.Remove(request.Invitation.AccompanyingPerson.Id.Value);
            }

            foreach(var guest in request.Invitation.Guests)
            {
                var guestId = await _guestRepository.AddOrEdit(guest);
                guest.Response.GuestId = guestId;
                await _guestResponseRepository.AddOrEdit(guest.Response);
            }

            return true;
        }
    }
}
