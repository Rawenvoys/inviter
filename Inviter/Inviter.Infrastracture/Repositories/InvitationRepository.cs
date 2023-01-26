using Inviter.Domain.DbModels;
using Inviter.Domain.Enums;
using Inviter.Application.Interfaces.IRepositories;

namespace Inviter.Infrastracture.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        public async Task<InvitationDto> GetInvitation(Guid id) => new()
        {
            Id = id,
            DisplayText = "Beatę Szadurską z osobą towarzyszącą",
            AccompanyingPerson = true,
            AskForRoom = false,
            RelationType = RelationType.AnnaFamily
        };
    }
}
