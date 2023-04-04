using Inviter.Application.Commands.GetInvitation;
using Inviter.Application.Queries.SaveInvitation;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    public partial class Confirmation
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Parameter]
        public Guid Code { get; set; }

        private Domain.Aggregate.Invitation? invitation;

        private string accompayingPersonDisplayText => string.IsNullOrWhiteSpace(invitation?.AccompanyingPerson?.FullName) ? "Osoba towarzysząca" : invitation?.AccompanyingPerson?.FullName;
        private bool displayAccompanyingPerson => invitation?.WillTakeAccompanyingPerson ?? false && (invitation?.AskAboutAccompanying ?? false);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                invitation = await _mediator.Send(new GetInvitationCommand(Code));
                StateHasChanged();
            }
        }

        private async Task SaveAsync()
        {
            var saveResult = await _mediator.Send(new SaveInvitationCommand(invitation));
            if (saveResult) _navigationManager.NavigateTo("/Podziekowanie/" + Code.ToString());
        }

        private void RedirectToInvitation()
        {
            _navigationManager.NavigateTo("/" + Code.ToString());
        }
    }
}
