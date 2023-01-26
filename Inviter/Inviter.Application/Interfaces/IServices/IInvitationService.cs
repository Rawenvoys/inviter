using Inviter.Domain.Models;

namespace Inviter.Application.Interfaces.IServices
{
    public interface IInvitationService
    {
        Task<Invitation> Find(Guid code);
    }
}
