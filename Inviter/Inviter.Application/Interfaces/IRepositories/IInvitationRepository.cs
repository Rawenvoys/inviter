
using Inviter.Domain.DbModels;

namespace Inviter.Application.Interfaces.IRepositories
{
    public interface IInvitationRepository
    {
        public Task<InvitationDto> GetInvitation(Guid id);
    }
}
