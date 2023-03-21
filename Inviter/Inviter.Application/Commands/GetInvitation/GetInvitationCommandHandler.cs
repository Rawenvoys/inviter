using Inviter.Domain.Aggregate;
using Inviter.Domain.IRepositories;

namespace Inviter.Application.Commands.GetInvitation
{
    public class GetInvitationCommandHandler : IRequestHandler<GetInvitationCommand, Invitation>
    {
        private readonly IInvitationFinder _invitationFinder;
        public GetInvitationCommandHandler(IInvitationFinder invitationFinder) => _invitationFinder = invitationFinder;

        public async Task<Invitation> Handle(GetInvitationCommand request, CancellationToken cancellationToken) 
            => await _invitationFinder.Get(request.Code);
    }
}
