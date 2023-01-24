using Inviter.Domain.IRepositories;
using Inviter.Infrastracture.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Extensions
{
    public static class RepositoryExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
        }
    }
}
