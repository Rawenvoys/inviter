using Inviter.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class InvitationCardComponent
    {
        [Parameter]
        public Invitation Invitation { get; set; }
    }
}
