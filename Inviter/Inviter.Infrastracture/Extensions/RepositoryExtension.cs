using Inviter.Application.Interfaces.IRepositories;
using Inviter.Infrastracture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Inviter.Infrastracture.Extensions
{
    public static class RepositoryExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<IResponseRepository, ResponseRepository>();
        }
    }
}
