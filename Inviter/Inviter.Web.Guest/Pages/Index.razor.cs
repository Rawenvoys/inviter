using Inviter.Application.Interfaces.IServices;
using Inviter.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    [Route("/Zaproszenie/{code:guid}")]
    public partial class Index
    {
        [Parameter]
        public Guid Code { get; set; }

        [Inject]
        IInvitationService _invitationService { get; set; }

        public Invitation Invitation { get; set; }

        protected override async Task OnInitializedAsync() => Invitation = await _invitationService.Find(Code);

    }
}
