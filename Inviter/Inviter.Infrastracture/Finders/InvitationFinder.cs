using Inviter.Domain.Aggregate;
using Inviter.Domain.Exceptions;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Infrastracture.Repositories
{
    public class InvitationFinder : IInvitationFinder
    {
        private readonly InviterContext _inviterContext;
        private readonly IGuestFinder _guestRepository;
        public InvitationFinder(InviterContext inviterContext, IGuestFinder guestRepository)
        {
            _inviterContext = inviterContext;
            _guestRepository = guestRepository;
        }

        public async Task<Invitation> Get(Code code)
        {
            using var connection = _inviterContext.CreateConnection();
            var invitation = await connection.QueryFirstOrDefaultAsync<InvitationDto>("SP_InvitationGetByCode",
                new { code }, commandType: CommandType.StoredProcedure);
            if (invitation is null) throw new InvitationNotFoundException(code);

            var invitationGuests = await _guestRepository.GetGuestsForInvitation(code);
            Invitation result = new(invitation.Id, invitation.DisplayName, invitation.KnowledgeTypes, invitation.AskForAccomodation, invitation.AskForAfterparty, invitation.AskAboutAccompanying, invitationGuests);
            return result;
        }
    }
}
