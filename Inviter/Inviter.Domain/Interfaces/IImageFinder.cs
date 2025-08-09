using Inviter.Domain.Aggregate;

namespace Inviter.Domain.Interfaces
{
    public interface IImageFinder
    {
        Task<List<Image>> Get();
    }
}
