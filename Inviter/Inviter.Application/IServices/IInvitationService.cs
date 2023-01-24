using Inviter.Domain.Models;

namespace Inviter.Application.IServices
{
    public interface IInvitationService
    {
        Task<Invitation> Find(Guid code);
    }
}
