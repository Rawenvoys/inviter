using Inviter.Domain.ValueObjects;
using Inviter.Domain.ValueObjects.Guest;

namespace Inviter.Domain.Aggregate
{
    public class Guest
    {
        public Id? Id { get; set; }
        public Name FirstName { get; set; }
        public Name LastName { get; set; }
        public bool IsAccompanyingPerson { get; set; }
        public bool IsChild { get; set; }

        public Guest(Guid id, string firstName, string lastName, bool isAccompanyingPerson, bool isChild)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsAccompanyingPerson = isAccompanyingPerson;
            IsChild = isChild;
        }

        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            IsAccompanyingPerson = true;
            IsChild = false;
        }
    }
}
