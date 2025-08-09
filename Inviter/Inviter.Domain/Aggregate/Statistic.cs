using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Aggregate
{
    public class Statistic
    {
        private readonly List<Invitation> _invitations;
        public Statistic(List<Invitation> invitations)
        {
            _invitations = invitations;
        }
        public int AllInvitations => _invitations.Count;
        //public int RemainingInvitation => _invitations.Where(i => i.)
    }
}
