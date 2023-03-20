using Inviter.Domain.Aggregate;
using Inviter.Domain.ValueObjects.Invitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Finders
{
    internal class GuestFinder : IGuestFinder
    {
        private readonly InviterContext _inviterContext;

        public GuestFinder(InviterContext inviterContext) => _inviterContext = inviterContext;

        public async Task<IList<Guest>> GetGuestsForInvitation(Code code)
        {
            using var connection = _inviterContext.CreateConnection();
            var guests = await connection.QueryAsync<GuestDto>("SP_GuestGetByCode", new { code }, commandType: CommandType.StoredProcedure);
            return guests.Select(g => new Guest(g.Id, g.FirstName, g.LastName, g.IsAccompanyingPerson, g.IsChild)).ToList();
        }
    }
}
