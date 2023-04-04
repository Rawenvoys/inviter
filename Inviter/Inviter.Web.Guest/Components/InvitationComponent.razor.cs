using Inviter.Domain.ValueObjects.Invitation;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components;

public partial class InvitationComponent
{
    private MarkupString displayText;
    public void SetDisplayText(string displayName, bool askAboutAccompanying)
    {
        displayText = (MarkupString)$"{displayName ?? string.Empty} {(askAboutAccompanying ? "<br />wraz z osob¹ towarzysz¹c¹" : string.Empty)}";
        StateHasChanged();
    }
}
