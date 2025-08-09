using Inviter.Domain.Enums;
using Inviter.Domain.ValueObjects.Invitation;
using QRCoder;

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
        public bool IsAnyGuest => Guests is not null && Guests.Count > 0;

        public DateTime? InvitationDate { get; set; }
        public TimeSpan? InvitationTime { get; set; }
        public QRCodeData? QRCode { get; set; }

        public bool IsSelectedToGenerate { get; set; } = false;
        public string QRCodeBase64 { get; set; }
        public byte[]? QRCodeByteArray { get; set; }

        public Invitation(Guid id, string displayName, int source, bool askForAccomodation, bool askForAfterparty, bool askAboutAccompanying, IList<Guest>? guests, DateTime? invitationDate, byte[]? qrCode)
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
            AccompanyingPerson = !WillTakeAccompanyingPerson && askAboutAccompanying ? Guest.CreateAccompanyingPerson(id) : accompanyingPerson;
            InvitationDate = invitationDate;
            QRCode = qrCode is not null ? new QRCodeData(qrCode, QRCodeData.Compression.Uncompressed) : null;
            QRCodeByteArray = qrCode;
            InvitationTime = InvitationDate?.TimeOfDay;
        }

       
    }
}
