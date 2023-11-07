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

        private string searchString = "";

        protected override async Task OnInitializedAsync()
            => invitations = await _mediator.Send(new GetInvitationsCommand());

        private void NavigateToEdit(Guid code)
            => _navigationManager.InvitationEdit(code);

        private bool ContainsSearchString(InvitationViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (vm.DisplayName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
    }
}
