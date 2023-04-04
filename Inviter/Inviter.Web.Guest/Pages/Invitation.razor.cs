using Inviter.Application.Commands.GetInvitation;
using Inviter.Web.Guest.Components;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    public partial class Invitation
    {

        [Parameter]
        public Guid Code { get; set; }

        [Inject]
        public IMediator _mediator { get; set; }

        private Domain.Aggregate.Invitation invitation;

        protected InvitationComponent InvitationComponentRef;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                invitation = await _mediator.Send(new GetInvitationCommand(Code));
            InvitationComponentRef.SetDisplayText(invitation.DisplayName, invitation.AskAboutAccompanying);
        }

    }
}