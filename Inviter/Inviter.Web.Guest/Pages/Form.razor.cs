using Inviter.Application.Interfaces.IServices;
using Inviter.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    [Route("/Formularz/{code:guid}")]
    public partial class Form
    {
        [Parameter]
        public Guid Code { get; set; }

        [Inject]
        IInvitationService _invitationService { get; set; }

        private Invitation invitation { get; set; }


        protected override async Task OnInitializedAsync() => invitation = await _invitationService.FindAsync(Code);

        private async Task SaveResponseAsync() => await _invitationService.SaveResponseAsync(invitation);
    }
}
