using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly InviterContext _inviterContext;

        public GuestRepository(InviterContext inviterContext) => _inviterContext = inviterContext;

        public async Task<Guid> Save(Guest guest)
        {
            using var connection = _inviterContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Guid>("SP_GuestSave", new { id = guest.Id, invitationId = guest.InvitationId, firstName = guest.FirstName, lastName = guest.LastName, isAccompanyingPerson = guest.IsAccompanyingPerson, isChild = guest.IsChild }, commandType: CommandType.StoredProcedure);
        }

        public async Task Remove(Guid guestId)
        {
            using var connection = _inviterContext.CreateConnection();
            await connection.QueryAsync("SP_GuestRemove", new { guestId = guestId }, commandType: CommandType.StoredProcedure);
        }
    }
}
