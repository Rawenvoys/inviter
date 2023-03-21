using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestRepository
    {
        public Task Edit(Guest guest);
        public Task<Guid> Add(Guest guest);
    }
}
