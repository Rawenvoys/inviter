using Inviter.Domain.DbModels;
using Inviter.Application.Interfaces.IRepositories;

namespace Inviter.Infrastracture.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        public async Task<List<GuestDto>> GetInvitationGuests(Guid invitationId) => new ()
            {
                new ()
                {
                    Id = Guid.NewGuid(),
                    InvitationId = invitationId,
                    FirstName = "Beata",
                    LastName = "Szadurska",
                    IsChild = false
                }
            };
    }
}
