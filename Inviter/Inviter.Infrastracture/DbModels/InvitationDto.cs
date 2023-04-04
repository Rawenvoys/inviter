using Inviter.Domain.Enums;

namespace Inviter.Infrastracture.DbModels
{
    public class InvitationDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public int KnowledgeTypes { get; set; }
        public bool AskForAfterparty { get; set; }
        public bool AskForAccomodation { get; set; }
        public bool AskAboutAccompanying { get; set; }
    }
}
