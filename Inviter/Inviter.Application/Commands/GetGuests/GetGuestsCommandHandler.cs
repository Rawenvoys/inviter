using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetGuests
{
    public class GetGuestsCommandHandler : IRequestHandler<GetGuestsCommand, List<Guest>>
    {
        private IGuestFinder _guestFinder;

        public GetGuestsCommandHandler(IGuestFinder guestFinder)
        {
            _guestFinder = guestFinder;
        }

        public async Task<List<Guest>> Handle(GetGuestsCommand request, CancellationToken cancellationToken)
        {
            var guests = await _guestFinder.GetAll();
            return guests.ToList();
        }
    }
}
