using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Queries.SaveInvitation
{
    public class SaveInvitationCommand : IRequest<bool>
    {
        public Invitation Invitation { get; set; }
        public SaveInvitationCommand(Invitation invitation) => Invitation = invitation;
    }
}
