using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.DbModels
{
    public class GuestDto
    {
        public Guid Id { get; set; }
        public Guid InvitationId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsAccompanyingPerson { get; set; }
        public bool IsChild { get; set; }
    }
}
