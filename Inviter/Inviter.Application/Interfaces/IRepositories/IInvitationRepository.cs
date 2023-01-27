
using Inviter.Domain.DbModels;

namespace Inviter.Application.Interfaces.IRepositories
{
    public interface IInvitationRepository
    {
        public Task<InvitationDto> GetInvitationAsync(Guid id);
        public Task SaveAsync(InvitationDto invitationDto);
    }
}
