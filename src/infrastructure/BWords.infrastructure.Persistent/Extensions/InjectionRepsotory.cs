using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.infrastructure.Persistent.Repostors;
using Microsoft.Extensions.DependencyInjection;

namespace BWords.infrastructure.Persistent.Extensions
{
    public static class InjectionRepsotory
    {
        public static IServiceCollection AddRepstoryRegistertion(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepstory<>),typeof(GenericRepstory<>));
            services.AddScoped<IUserRepstory, UserRepstory>();
            services.AddScoped<IEmailConfigurationRepstory, EmailConfigurationRepstory>();
            services.AddScoped<IEntryCommentFovoriteRepstory, EntryCommentFovoriteRepstory>();
            services.AddScoped<IEntryCommentRepstory, EntryCommentRepstory>();
            services.AddScoped<IEntryCommentVoteRepstory, EntryCommentVoteRepstory>();
            services.AddScoped<IEntryFovoriteRepstory, EntryFovoriteRepstory>();
            services.AddScoped<IEntryRepstory, EntryRepstory>();
            services.AddScoped<IEntryVoteRepstory, EntryVoteRepstory>();
            services.AddScoped<IUserRepstory, UserRepstory>();
            return services;

        }
     }
}
