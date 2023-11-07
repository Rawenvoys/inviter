using Inviter.Domain.Aggregate;

namespace Inviter.Application.Commands.GetGuests
{
    public class GetGuestsCommand : IRequest<List<Guest>>
    {
    }
}
