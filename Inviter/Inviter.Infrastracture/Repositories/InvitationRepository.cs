using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Repositories
{
    internal class InvitationRepository : IInvitationRepository
    {
        public Task Save(Invitation invitation)
        {
            throw new NotImplementedException();
        }
    }
}
