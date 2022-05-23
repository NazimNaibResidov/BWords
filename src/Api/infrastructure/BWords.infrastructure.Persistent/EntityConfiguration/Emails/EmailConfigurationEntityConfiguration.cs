using BWords.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.Emails
{
    public class EmailConfigurationEntityConfiguration : BaseEntityConfiguration<EmailConfiguration>
    {
        public void Configure(EntityTypeBuilder<EmailConfiguration> builder)
        {
            base.Configure(builder);
        }
    }
}
