using Inviter.Domain.Enums;

namespace Inviter.Domain.Models
{
    public class Invitation
    {
        public Guid Code { get; set; }
        public string DisplayText { get; set; }
        public bool AccompanyingPerson { get; set; }
        public bool AskForRoom { get; set; }
        public RelationType RelationType { get; set; }
        public List<Guest> GuestList { get; set; }
    }
}
