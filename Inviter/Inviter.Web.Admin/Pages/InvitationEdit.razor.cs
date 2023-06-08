using Inviter.Application.Commands.GetInvitation;
using Inviter.Application.Queries.SaveInvitation;
using Inviter.Domain.Aggregate;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class InvitationEdit
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        public AdminNavigationManager _navigationManager { get; set; }

        [Parameter]
        public Guid Code { get; set; }

        private Invitation invitation;


        protected override async Task OnInitializedAsync() 
            => invitation = await _mediator.Send(new GetInvitationCommand(Code));

        private async Task SaveInvitation()
        {
            await _mediator.Send(new SaveInvitationQuery(invitation));
            _navigationManager.MainPage();
        }

    }
}
