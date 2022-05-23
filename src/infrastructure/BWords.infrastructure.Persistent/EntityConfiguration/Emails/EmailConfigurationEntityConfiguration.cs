using BWords.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
