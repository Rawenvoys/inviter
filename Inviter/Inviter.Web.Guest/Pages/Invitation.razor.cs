using Inviter.Application.Commands.GetInvitation;
using Inviter.Application.Models;
using Inviter.Web.Guest.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Inviter.Web.Guest.Pages
{
    public partial class Invitation
    {

        [Parameter]
        public Guid Code { get; set; }

        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        public IOptions<GuestAppSettings> _appSettings { get; set; }

        private bool displayGaleryPage => _appSettings?.Value.DisplayGaleryPage ?? false;

        private Domain.Aggregate.Invitation invitation;

        protected InvitationComponent InvitationComponentRef;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (displayGaleryPage)
                _navigationManager.NavigateTo("/Galeria");

            if (firstRender)
                invitation = await _mediator.Send(new GetInvitationCommand(Code));
            InvitationComponentRef.SetDisplayText(invitation.DisplayName, invitation.AskAboutAccompanying);
        }

    }
}