namespace Inviter.Domain.Models
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsChild { get; set; }   
    }
}
