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

        [Inject]
        NavigationManager _navManager { get; set; }

        public Invitation Invitation { get; set; }

        protected override async Task OnInitializedAsync() => Invitation = await _invitationService.FindAsync(Code);

        private async Task RedirectToDeclarationFormAsync() => _navManager.NavigateTo($"/Formularz/{Code}");
    }
}
