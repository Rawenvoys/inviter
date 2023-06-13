using Inviter.Domain.Aggregate;
using Inviter.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Repositories
{
    internal class InvitationRepository : IInvitationRepository
    {
        private readonly InviterContext _inviterContext;

        public InvitationRepository(InviterContext inviterContext) => _inviterContext = inviterContext;
        public async Task<Guid> Save(Invitation invitation)
        {
            using var connection = _inviterContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Guid>("SP_InvitationSave",
                                                                   new { id = invitation.Code
                                                                   , displayName = invitation.DisplayName
                                                                   , knowledgeTypes = (int)invitation.Source
                                                                   , askForAfterparty = invitation.AskForAfterparty
                                                                   , askForAccomodation = invitation.AskForAccomodation
                                                                   , askAboutAccompanying = invitation.AskAboutAccompanying
                                                                   , qrCode = invitation.QRCodeByteArray
                                                                   , invitationDate = invitation.InvitationDate.SetTime(invitation.InvitationTime)
                                                                   },
                                                                   commandType: CommandType.StoredProcedure);
        }
    }
}
