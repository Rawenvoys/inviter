using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Queries.SaveInvitation
{
    public class SaveInvitationQuery : IRequest<bool>
    {
        public Invitation Invitation { get; set; }
        public SaveInvitationQuery(Invitation invitation) => Invitation = invitation;
    }
}
