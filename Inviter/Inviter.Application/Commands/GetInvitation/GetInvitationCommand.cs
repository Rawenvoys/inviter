using Inviter.Domain.Aggregate;
using Inviter.Domain.ValueObjects.Invitation;

namespace Inviter.Application.Commands.GetInvitation
{
    public class GetInvitationCommand : IRequest<Invitation>
    {
        public Code Code { get; set; }

        public GetInvitationCommand(Code code) => Code = code;
    }
}
