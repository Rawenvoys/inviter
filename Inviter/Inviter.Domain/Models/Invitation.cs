using Inviter.Domain.Enums;

namespace Inviter.Domain.Models
{
    public class Invitation
    {
        public Guid Code { get; set; }
        public string DisplayText { get; set; }
        public bool AccompanyingPersonSelected { get; set; }
        public bool IsAccompanyingPerson { get; set; }
        public bool AskForRoom { get; set; }
        public RelationType RelationType { get; set; }
        public string? Notes { get; set; }
        public Guest AccompanyingPerson { get; set; }
        public List<Guest> Guests { get; set; }

        public bool IsAnyGuestAtWeddingParty => Guests.Any(g => g.Response.WeddingParty);
    }
}
