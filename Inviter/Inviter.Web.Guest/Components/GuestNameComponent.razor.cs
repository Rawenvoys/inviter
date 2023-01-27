using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class GuestNameComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
