using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    public partial class Invitation
    {
        [Parameter]
        public Guid Code { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //ToDo: Get Invitation details (by Mediator)
            await Task.FromResult(() =>
            {
                Console.WriteLine(Code);
            });
        }
    }
}
