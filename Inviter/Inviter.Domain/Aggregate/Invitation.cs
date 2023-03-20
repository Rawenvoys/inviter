using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Domain.Aggregate
{
    public class Invitation
    {
        public Code Code { get; set; }
        public DisplayName DisplayName { get; set; }
        public Source Source { get; set; }
        public IList<Guest> Guests { get; set; }

        public bool AskForAfterparty { get; set; }
        public bool AskForAccomodation { get; set; }

        public bool AskAboutAccompanying { get; set; }
        public Guest? AccompanyingPerson { get; set; }

        public Invitation(Guid id, string displayName, int source, bool askForAccomodation, bool askForAfterparty, bool askAboutAccompanying, IList<Guest> guests)
        {
            Code = id;
            DisplayName = displayName;
            Source = source;
            AskForAfterparty = askForAfterparty;
            AskForAccomodation = askForAfterparty && askForAccomodation;
            AskAboutAccompanying = askAboutAccompanying;
            var accompanyingPerson = guests?.FirstOrDefault(g => g.IsAccompanyingPerson);
            Guests = guests?.Where(g => !g.IsAccompanyingPerson).ToList() ?? new List<Guest>();
            AccompanyingPerson = accompanyingPerson;
        }

        //ToDo: IGuestRepository? 
        //public void SetAccompanyingPerson(string firstName, string lastName)
        //{
        //    switch (AccompanyingPerson)
        //    {
        //        case null:
        //            AccompanyingPerson = new(firstName, lastName);
        //            break;
        //        default:
        //            AccompanyingPerson.FirstName = firstName;
        //            AccompanyingPerson.LastName = lastName;
        //            break;
        //    }
        //}
    }
}
