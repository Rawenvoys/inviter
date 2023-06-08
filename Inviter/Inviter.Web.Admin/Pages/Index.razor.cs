using Inviter.Application.Commands.GetInvitations;
using Inviter.Application.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class Index
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        public AdminNavigationManager _navigationManager { get; set; }

        private IList<InvitationViewModel> invitations;

        protected override async Task OnInitializedAsync() 
            => invitations = await _mediator.Send(new GetInvitationsCommand());

        private void NavigateToEdit(Guid code) 
            => _navigationManager.InvitationEdit(code);
    }
}
