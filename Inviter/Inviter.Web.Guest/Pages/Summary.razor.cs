using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    public partial class Summary
    {

        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Parameter]
        public Guid Code { get; set; }

        private void RedirectToInvitation() => _navigationManager.NavigateTo("/" + Code.ToString());

    }
}
