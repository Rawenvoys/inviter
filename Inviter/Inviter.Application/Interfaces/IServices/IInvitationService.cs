using Inviter.Domain.Models;

namespace Inviter.Application.Interfaces.IServices
{
    public interface IInvitationService
    {
        Task<Invitation> FindAsync(Guid code);

        Task SaveResponseAsync(Invitation invitation);
    }
}
