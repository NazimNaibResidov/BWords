using BWords.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.Users
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
        }
    }
}
