using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components;

public partial class InvitationComponent
{

    [Parameter]
    public string DisplayName { get; set; }
}
