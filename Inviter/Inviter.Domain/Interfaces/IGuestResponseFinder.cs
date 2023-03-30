using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestResponseFinder
    {
        public Task<Response?> Get(Guid guestId);
    }
}
