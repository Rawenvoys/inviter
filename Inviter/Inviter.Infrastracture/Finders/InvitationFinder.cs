using Inviter.Domain.Aggregate;
using Inviter.Domain.Exceptions;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Infrastracture.Finders
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
                new { code = (Guid)code }, commandType: CommandType.StoredProcedure);
            if (invitation is null) throw new InvitationNotFoundException(code);

            var invitationGuests = await _guestRepository.GetGuestsForInvitation(code);
            Invitation result = new(invitation.Id, invitation.DisplayName, invitation.KnowledgeTypes, invitation.AskForAccomodation, invitation.AskForAfterparty, invitation.AskAboutAccompanying, invitationGuests, invitation.InvitationDate, invitation.QRCode);
            return result;
        }

        public async Task<List<Invitation>> GetAll()
        {
            using var connection = _inviterContext.CreateConnection();
            var invitations = await connection.QueryAsync<InvitationDto>("SP_InvitationGetAll"
                , commandType: CommandType.StoredProcedure);

            List<Invitation> result = new();
            foreach (var invitation in invitations)
            {
                var invitationGuests = await _guestRepository.GetGuestsForInvitation(invitation.Id);
                result.Add(new Invitation(invitation.Id, invitation.DisplayName, invitation.KnowledgeTypes, invitation.AskForAccomodation, invitation.AskForAfterparty, invitation.AskAboutAccompanying, invitationGuests, invitation.InvitationDate, invitation.QRCode));
            }
            return result;
        }

        public async Task<List<Invitation>> GetWithoutCode()
        {
            using var connection = _inviterContext.CreateConnection();
            var invitations = await connection.QueryAsync<InvitationDto>("SP_InvitationGetWithoutQRCode"
                , commandType: CommandType.StoredProcedure);

            List<Invitation> result = new();
            foreach (var invitation in invitations)
            {
                var invitationGuests = await _guestRepository.GetGuestsForInvitation(invitation.Id);
                result.Add(new Invitation(invitation.Id, invitation.DisplayName, invitation.KnowledgeTypes, invitation.AskForAccomodation, invitation.AskForAfterparty, invitation.AskAboutAccompanying, invitationGuests, invitation.InvitationDate, invitation.QRCode));
            }
            return result;
        }
    }
}
