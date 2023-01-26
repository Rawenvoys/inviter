using Inviter.Application.Interfaces.IServices;
using Inviter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inviter.Application.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IInvitationService, InvitationService>();
        }
    }
}
