using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Repositories
{
    public class GuestResponseRepository : IGuestResponseRepository
    {
        public Task<Guid?> AddOrEdit(Response response)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid guestId)
        {
            throw new NotImplementedException();
        }
    }
}
