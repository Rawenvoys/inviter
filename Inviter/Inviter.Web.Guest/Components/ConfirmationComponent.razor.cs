using Inviter.Domain.ValueObjects.Invitation;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class ConfirmationComponent
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Parameter]
        public Guid Code { get; set; }

        public int RemainingDays { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await Task.FromResult(() =>
            {
                DateTime today = DateTime.Now;
                DateTime lastConfirmationDay = new DateTime(2023, 07, 01);
                RemainingDays = (int)(lastConfirmationDay - today).TotalDays;
            });
        }

        private void NavigateToConfirm() => _navigationManager.NavigateTo("/Potwierdzenie/" + Code.ToString());

    }
}
