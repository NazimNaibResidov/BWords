using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.infrastructure.Persistent.Repostors;
using Microsoft.Extensions.DependencyInjection;

namespace BWords.infrastructure.Persistent.Extensions
{
    public static class InjectionRepsotory
    {
        public static IServiceCollection AddRepstoryRegistertion(this IServiceCollection services)
        {
           // services.AddTransient(typeof(IGenericRepstory<>),typeof(GenericRepstory<>));
            services.AddTransient<IUserRepstory, UserRepstory>();
            services.AddTransient<IEmailConfigurationRepstory, EmailConfigurationRepstory>();
            services.AddTransient<IEntryCommentFovoriteRepstory, EntryCommentFovoriteRepstory>();
            services.AddTransient<IEntryCommentRepstory, EntryCommentRepstory>();
            services.AddTransient<IEntryCommentVoteRepstory, EntryCommentVoteRepstory>();
            services.AddTransient<IEntryFovoriteRepstory, EntryFovoriteRepstory>();
            services.AddTransient<IEntryRepstory, EntryRepstory>();
            services.AddTransient<IEntryVoteRepstory, EntryVoteRepstory>();
            services.AddTransient<IUserRepstory, UserRepstory>();
            return services;

        }
     }
}
