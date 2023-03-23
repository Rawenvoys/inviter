using Inviter.Domain.Aggregate;
using Inviter.Domain.ValueObjects.Invitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.FindersMock
{
    internal class GuestFinderMock : IGuestFinder
    {
        public async Task<IList<Guest>> GetGuestsForInvitation(Code code)
        {
            var guests = new List<Guest>()
                {
                    new(Guid.Parse("B6311A32-1842-447F-A8BF-8ADC218E3CE5"), "Beata", "Szadurska", false, false)
                };
            return await Task.FromResult(guests);
        }
    }
}
