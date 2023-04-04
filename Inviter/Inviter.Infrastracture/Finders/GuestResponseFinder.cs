using Inviter.Domain.Aggregate;
using Inviter.Domain.Interfaces;

namespace Inviter.Infrastracture.Finders
{
    public class GuestResponseFinder : IGuestResponseFinder
    {
        private readonly InviterContext _inviterContext;

        public GuestResponseFinder(InviterContext inviterContext) => _inviterContext = inviterContext;
        
        public async Task<Response?> Get(Guid guestId)
        {
            using var connection = _inviterContext.CreateConnection();
            var guestResponse = await connection.QueryFirstOrDefaultAsync<GuestResponseDto>("SP_GuestResponseGetByGuestId", new { guestId = guestId }, commandType: CommandType.StoredProcedure);
            return guestResponse is not null ? new Response(guestResponse.GuestId, guestResponse.WillBeAtWeddingParty, guestResponse.WillBeAtAfterparty, guestResponse.NeedAccomodation) : null;
        }
    }
}
