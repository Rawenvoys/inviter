using Inviter.Domain.Aggregate;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Domain.Interfaces
{
    public interface IInvitationFinder
    {
        Task<Invitation> Get(Code code);
    }
}
