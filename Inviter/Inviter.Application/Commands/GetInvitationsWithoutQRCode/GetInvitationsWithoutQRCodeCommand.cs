using Inviter.Domain.Aggregate;

namespace Inviter.Application.Commands.GetInvitationsWithoutQRCode
{
    public class GetInvitationsWithoutQRCodeCommand : IRequest<List<Invitation>>
    {
    }
}
