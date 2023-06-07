using Inviter.Application.Commands.GetInvitations;
using Inviter.Application.Commands.GetQRCodeBase64;
using Inviter.Application.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class Index
    {
        [Inject]
        public IMediator _mediator { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }

        private IList<InvitationViewModel> invitations;

        protected override async Task OnInitializedAsync()
        {
            invitations = await _mediator.Send(new GetInvitationsCommand());
            invitations.Where(i => i.QRCode is not null)
                .ToList()
                .ForEach(async i =>
                {
                    i.QRCodeBase64 = await _mediator.Send(new GetQRCodeBase64Command()
                    {
                        QRCode = i.QRCode
                    });
                });
        }

        private void NavigateToEdit(Guid code) => _navigationManager.NavigateTo("Invitation/Edit/" + code.ToString());
    }
}
