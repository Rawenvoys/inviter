using Inviter.Domain.Aggregate;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestResponseRepository
    {
        public Task<Guid?> AddOrEdit(Response response);
        public Task Remove(Guid guestId);
    }
}
