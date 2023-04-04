using Inviter.Domain.Aggregate;

namespace Inviter.Domain.Interfaces
{
    public interface IGuestResponseRepository
    {
        public Task<Guid> Save(Response response);
    }
}
