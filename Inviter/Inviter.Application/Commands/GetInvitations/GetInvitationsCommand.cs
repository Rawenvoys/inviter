using Inviter.Application.ViewModels;

namespace Inviter.Application.Commands.GetInvitations
{
    public class GetInvitationsCommand : IRequest<List<InvitationViewModel>>
    {
    }
}
