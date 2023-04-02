
namespace Inviter.Domain.Aggregate
{
    public class Response
    {
        public Guid? GuestId { get; set; }
        public bool WillBeAtWeddingParty => WillBeAtWeddingPartyCb;
        public bool WillBeAtAfterparty => WillBeAtWeddingParty && WillBeAtAfterpartyCb;
        public bool NeedAccomodation => WillBeAtAfterparty && NeedAccomodationCb;

        public bool WillBeAtWeddingPartyCb { get; set; }
        public bool WillBeAtAfterpartyCb { get; set; }
        public bool NeedAccomodationCb { get; set; }

        public Response(Guid guestId, bool? willBeAtWeddingParty, bool? willBeAtAfterparty, bool? needAccomodation)
        {
            GuestId = guestId;
            WillBeAtWeddingPartyCb = willBeAtWeddingParty ?? false;
            WillBeAtAfterpartyCb = willBeAtAfterparty ?? false;
            NeedAccomodationCb = needAccomodation ?? false;
        }

        public Response(Guid guestId)
            => GuestId = guestId;

        public Response() { }

        public static Response CreateAccompanyingPersonResponse()
        {
            return new()
            { WillBeAtWeddingPartyCb = true };
        }
    }
}
