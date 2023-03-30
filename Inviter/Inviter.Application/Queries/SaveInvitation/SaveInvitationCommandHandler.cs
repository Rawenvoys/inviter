using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Queries.SaveInvitation
{
    public class SaveInvitationCommandHandler : IRequestHandler<SaveInvitationCommand, bool>
    {
        public async Task<bool> Handle(SaveInvitationCommand request, CancellationToken cancellationToken) 
            => await Task.FromResult(true);
    }
}
