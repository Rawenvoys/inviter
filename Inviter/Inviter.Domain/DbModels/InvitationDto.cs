using Inviter.Domain.Enums;

namespace Inviter.Domain.DbModels
{
    public class InvitationDto
    {
        public Guid Id { get; set; }    
        public string DisplayText { get; set; }
        public bool AccompanyingPerson { get; set; }
        public bool AskForRoom { get; set; }
        public RelationType RelationType { get; set; }
        public string? PhoneNo { get; set; }    
    }
}
