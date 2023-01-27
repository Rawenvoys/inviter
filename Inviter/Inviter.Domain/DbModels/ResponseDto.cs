namespace Inviter.Domain.DbModels
{
    public class ResponseDto
    {
        public Guid GuestId { get; set; }
        public bool WeddingParty { get; set; }
        public bool AfterParty { get; set; }
        public bool Accomodation { get; set; }
        public DateTime ResponseDateUTC { get; set; }
    }
}
