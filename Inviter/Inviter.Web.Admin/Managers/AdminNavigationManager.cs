using Inviter.Web.Admin.Consts;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Managers
{
    public class AdminNavigationManager
    {
        private readonly NavigationManager _navigationManager;
        public AdminNavigationManager(NavigationManager navigationManager) 
            => _navigationManager = navigationManager;

        public void Guests() 
            => _navigationManager.NavigateTo(Urls.GUESTS);

        public void InvitationEdit(Guid code) 
            => _navigationManager.NavigateTo($"{Urls.INVITATION_EDIT}/{code}");

        public void MainPage()
            => _navigationManager.NavigateTo(Urls.MAIN_PAGE);
    }
}
