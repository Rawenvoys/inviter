using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetInvitationsWithoutQRCode
{
    public class GetInvitationWithoutQRCodeCommandHandler : IRequestHandler<GetInvitationsWithoutQRCodeCommand, List<Invitation>>
    {
        private readonly IInvitationFinder _invitationFinder;
        public GetInvitationWithoutQRCodeCommandHandler(IInvitationFinder invitationFinder) => _invitationFinder = invitationFinder;
        public async Task<List<Invitation>> Handle(GetInvitationsWithoutQRCodeCommand request, CancellationToken cancellationToken) => await _invitationFinder.GetWithoutCode();
    }
}
