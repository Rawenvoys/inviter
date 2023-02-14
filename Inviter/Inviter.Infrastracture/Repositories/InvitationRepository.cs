using Inviter.Domain.DbModels;
using Inviter.Domain.Enums;
using Inviter.Application.Interfaces.IRepositories;

namespace Inviter.Infrastracture.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        public async Task<InvitationDto> GetInvitationAsync(Guid id) => new()
        {
            Id = id,
            DisplayText = "Beatę Szadurską z osobą towarzyszącą",
            AccompanyingPerson = true,
            AskForRoom = true,
            RelationType = RelationType.AnnaFamily
        };

        public async Task SaveAsync(InvitationDto invitationDto)
        {
        }
    }
}
