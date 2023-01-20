using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Services
{
    public interface IInvitationService
    {
        Task Find(Guid code);
    }
}
