
using Inviter.Domain.DbModels;

namespace Inviter.Domain.IRepositories
{
    public interface IGuestRepository
    {
        public Task<List<GuestDto>> GetInvitationGuests(Guid invitationId);
    }
}
