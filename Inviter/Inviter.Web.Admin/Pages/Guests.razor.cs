using Inviter.Application.Commands.GetGuests;
using Inviter.Domain.Aggregate;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class Guests
    {
        [Inject]
        public IMediator _mediator { get; set; }
        
        [Parameter]
        public Guid? Code { get; set; }

        private IList<Guest> guests;

        private string searchString = "";

        protected override async Task OnInitializedAsync()
            => guests = await _mediator.Send(new GetGuestsCommand());

        private bool ContainsSearchString(Guest guest)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (guest.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (guest.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
    }
}
