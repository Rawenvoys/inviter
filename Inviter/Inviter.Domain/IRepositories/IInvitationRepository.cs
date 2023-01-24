
using Inviter.Domain.DbModels;

namespace Inviter.Domain.IRepositories
{
    public interface IInvitationRepository
    {
        public Task<InvitationDto> GetInvitation(Guid id);
    }
}
