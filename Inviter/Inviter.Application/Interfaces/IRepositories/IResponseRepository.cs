using Inviter.Domain.DbModels;

namespace Inviter.Application.Interfaces.IRepositories
{
    public interface IResponseRepository
    {
        public Task SaveAsync(ResponseDto responseDto);
    }
}
