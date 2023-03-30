using Inviter.Domain.Enums;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Domain.Aggregate
{
    public class Invitation
    {
        public Guid Code { get; set; }
        public string DisplayName { get; set; }
        public KnowledgeTypes Source { get; set; }
        public IList<Guest>? Guests { get; set; }

        public bool AskForAfterparty { get; set; }
        public bool AskForAccomodation { get; set; }

        public bool AskAboutAccompanying { get; set; }
        public Guest? AccompanyingPerson { get; set; }
        public bool WillTakeAccompanyingPerson { get; set; }

        public Invitation(Guid id, string displayName, int source, bool askForAccomodation, bool askForAfterparty, bool askAboutAccompanying, IList<Guest>? guests)
        {
            Code = id;
            DisplayName = displayName;
            Source = (KnowledgeTypes)source;
            AskForAfterparty = askForAfterparty;
            AskForAccomodation = askForAfterparty && askForAccomodation;
            AskAboutAccompanying = askAboutAccompanying;
            var accompanyingPerson = guests?.FirstOrDefault(g => g.IsAccompanyingPerson);
            Guests = guests?.Where(g => !g.IsAccompanyingPerson).ToList() ?? new List<Guest>();
            WillTakeAccompanyingPerson = accompanyingPerson is not null;
            AccompanyingPerson = !WillTakeAccompanyingPerson && askAboutAccompanying ? new Guest() : null;
        }

        //ToDo: 
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
