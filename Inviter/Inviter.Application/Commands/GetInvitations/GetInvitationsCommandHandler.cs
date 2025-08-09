using Inviter.Application.ViewModels;
using Inviter.Domain.Aggregate;
using Microsoft.Extensions.Configuration;

namespace Inviter.Application.Commands.GetInvitations
{
    internal class GetInvitationsCommandHandler : IRequestHandler<GetInvitationsCommand, List<InvitationViewModel>>
    {
        private readonly IInvitationFinder _invitationFinder;
        private readonly string _baseUrl;

        public GetInvitationsCommandHandler(IInvitationFinder invitationFinder, IConfiguration configuration)
        {
            _invitationFinder = invitationFinder;
            _baseUrl = configuration["InviterWebGuestBaseUrl"] ?? string.Empty;
        }

        public async Task<List<InvitationViewModel>> Handle(GetInvitationsCommand request, CancellationToken cancellationToken)
        {
            var invitation = await _invitationFinder.GetAll();
            return invitation.Select(i => new InvitationViewModel(i.Code,
                                                                  i.DisplayName,
                                                                  (int)i.Source,
                                                                  i.AskForAccomodation,
                                                                  i.AskForAfterparty,
                                                                  i.AskAboutAccompanying,
                                                                  GetInvitationUrl(i.Code),
                                                                  i.Guests,
                                                                  i.InvitationDate,
                                                                  i.QRCodeByteArray))
                .ToList();
        }

        private string GetInvitationUrl(Guid code) 
            => $"{_baseUrl}/{code}";
    }
}
