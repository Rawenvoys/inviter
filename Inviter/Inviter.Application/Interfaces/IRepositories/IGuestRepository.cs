
using Inviter.Domain.DbModels;

namespace Inviter.Application.Interfaces.IRepositories
{
    public interface IGuestRepository
    {
        public Task<List<GuestDto>> GetInvitationGuests(Guid invitationId);
    }
}
