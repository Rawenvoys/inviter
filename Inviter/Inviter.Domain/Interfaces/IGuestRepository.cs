using Inviter.Domain.Aggregate;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestRepository
    {
        public Task<Guid> Save(Guest guest);
        public Task Remove(Guid guestId);
    }
}
