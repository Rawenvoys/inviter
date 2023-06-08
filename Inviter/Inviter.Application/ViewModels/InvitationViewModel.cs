using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.ViewModels
{
    public class InvitationViewModel : Invitation
    {
        public InvitationViewModel(Guid id, string displayName, int source, bool askForAccomodation, bool askForAfterparty, bool askAboutAccompanying, string url, IList<Guest>? guests, DateTime? invitationDate, byte[]? qrCode) 
            : base(id, displayName, source, askForAccomodation, askForAfterparty, askAboutAccompanying, guests, invitationDate, qrCode) 
            => Url = url;

        public string Url { get; set; }
        public string DisplayInvitationDate => InvitationDate is null ? string.Empty : InvitationDate.ToString();
    }
}
