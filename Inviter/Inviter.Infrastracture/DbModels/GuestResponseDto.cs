using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.DbModels
{
    public class GuestResponseDto
    {
        public Guid GuestId { get; set; }
        public bool? WillBeAtWeddingParty { get; set; }
        public bool? WillBeAtAfterparty { get; set; }
        public bool? NeedAccomodation { get; set; }
    }
}
