using Inviter.Domain.Aggregate;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestFinder
    {
        Task<IList<Guest>?> GetGuestsForInvitation(Code code);
    }
}
