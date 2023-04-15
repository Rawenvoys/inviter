using Inviter.Infrastracture.Finders;
using Inviter.Infrastracture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Inviter.Infrastracture.Extensions
{
    public static class ServiceCollectionExtension
    {
        private static void AddFinders(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IInvitationFinder, InvitationFinder>();
            serviceCollection.AddScoped<IGuestFinder, GuestFinder>();
            serviceCollection.AddScoped<IGuestResponseFinder, GuestResponseFinder>();
        }

        private static void AddDapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<InviterContext>();
        }

        private static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGuestRepository, GuestRepository>();
            serviceCollection.AddScoped<IGuestResponseRepository, GuestResponseRepository>();
        }

        public static void AddInfrastracture(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDapper();
            serviceCollection.AddFinders();
            serviceCollection.AddRepositories();
        }
    }
}
