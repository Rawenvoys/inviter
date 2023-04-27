using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Interfaces
{
    //ToDo: Think about method per property
    public interface IInvitationRepository
    {
        Task Save(Invitation invitation);
    }
}
