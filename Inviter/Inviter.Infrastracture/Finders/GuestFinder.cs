using Inviter.Domain.Aggregate;
using Inviter.Domain.Interfaces;
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
        private readonly IGuestResponseFinder _guestResponseFinder;

        public GuestFinder(InviterContext inviterContext, IGuestResponseFinder guestResponseFinder)
        {
            _inviterContext = inviterContext;
            _guestResponseFinder = guestResponseFinder;
        }

        public async Task<IList<Guest>?> GetGuestsForInvitation(Code code)
        {
            using var connection = _inviterContext.CreateConnection();
            var guests = await connection.QueryAsync<GuestDto>("SP_GuestGetByCode", new { code = (Guid)code }, commandType: CommandType.StoredProcedure);

            if (guests is null) return null;

            IList<Guest> result = new List<Guest>();
            foreach(var guest in guests)
            {
                var response = await _guestResponseFinder.Get(guest.Id);
                result.Add(new(guest.Id, guest.FirstName, guest.LastName, guest.IsAccompanyingPerson, guest.IsChild, response));
            }
            return result;
        }
    }
}
