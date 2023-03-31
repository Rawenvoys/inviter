using Inviter.Domain.ValueObjects;
using Inviter.Domain.ValueObjects.Guest;

namespace Inviter.Domain.Aggregate
{
    public class Guest
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public bool IsAccompanyingPerson { get; set; }
        public bool IsChild { get; set; }
        public Response Response { get; set; }


        public Guest(Guid id, string firstName, string lastName, bool isAccompanyingPerson, bool isChild, Response? response)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsAccompanyingPerson = isAccompanyingPerson;
            IsChild = isChild;
            Response = response ?? new(id);
        }

        public Guest()
        {

        }

        public static Guest CreateAccompanyingPerson()
        {
            return new()
            {
                IsAccompanyingPerson = true,
                IsChild = false,
                Response = new()
            };
        }
    }
}
