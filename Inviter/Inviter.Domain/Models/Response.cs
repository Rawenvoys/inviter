namespace Inviter.Domain.Models
{
    public class Response
    {
        public Guid GuestId { get; set; }
        public bool WeddingParty { get; set; }
        public bool AfterParty { get; set; }
        public bool Accomodation { get; set; }  
        public DateTime ResponseDateUTC { get; set; }   
    }
}
