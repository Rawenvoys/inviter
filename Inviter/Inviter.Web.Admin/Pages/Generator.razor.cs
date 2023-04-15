using Inviter.Application.Commands.GenerateQRCode;
using Inviter.Application.Commands.GetInvitationsWithoutQRCode;
using Inviter.Application.Commands.GetQRCodeBase64;
using Inviter.Domain.Aggregate;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class Generator
    {
        [Inject]
        public IMediator _mediator { get; set; }
        private IList<Invitation> invitations;

        private async Task GenerateQRCode()
        {
            var selectedInvitations = invitations.Where(i => i.IsSelectedToGenerate);
            foreach (var selectedInvitation in selectedInvitations)
            {
                selectedInvitation.QRCode = await _mediator.Send(new GenerateQRCodeCommand()
                {
                    Code = selectedInvitation.Code.ToString().ToUpper()
                });
                selectedInvitation.QRCodeBase64 = await _mediator.Send(new GetQRCodeBase64Command()
                {
                    QRCode = selectedInvitation.QRCode
                });
            }
        }

        protected override async Task OnInitializedAsync() => invitations = await _mediator.Send(new GetInvitationsWithoutQRCodeCommand());
    }
}
