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
        private readonly InviterContext _inviterContext;

        public GuestResponseRepository(InviterContext inviterContext) => _inviterContext = inviterContext;

        public async Task<Guid> Save(Response response)
        {
            using var connection = _inviterContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Guid>("SP_GuestResponseSave", new { guestid = response.GuestId, willBeAtWeddingParty = response.WillBeAtWeddingParty, willBeAtAfterparty = response.WillBeAtAfterparty, needAccomodation = response.NeedAccomodation }, commandType: CommandType.StoredProcedure);
        }
    }
}
