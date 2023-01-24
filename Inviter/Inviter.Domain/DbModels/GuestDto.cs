namespace Inviter.Domain.DbModels
{
    public class GuestDto
    {
        public Guid Id { get; set; }    
        public Guid InvitationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsChild { get; set; }
    }
}
