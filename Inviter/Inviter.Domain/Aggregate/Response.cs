
namespace Inviter.Domain.Aggregate
{
    public class Response
    {
        public Guid? GuestId { get; set; }
        public bool WillBeAtWeddingParty { get; set; }
        public bool WillBeAtAfterparty { get; set; }
        public bool NeedAccomodation { get; set; }

        public Response(Guid guestId, bool? willBeAtWeddingParty, bool? willBeAtAfterparty, bool? needAccomodation)
        {
            GuestId = guestId;
            WillBeAtWeddingParty = willBeAtWeddingParty ?? false;
            WillBeAtAfterparty = willBeAtAfterparty ?? false;
            NeedAccomodation = needAccomodation ?? false;
        }

        public Response(Guid guestId) 
            => GuestId = guestId;

        public Response() { }
    }
}
