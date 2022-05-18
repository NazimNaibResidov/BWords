using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.EntityConfiguration.Entry
{
    public class EntryEntityConfiguration : BaseEntityConfiguration<Entiry>
    {
        public void Configure(EntityTypeBuilder<Entiry> builder)
        {
            base.Configure(builder);
            builder.ToTable("entry", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.CreateBy)
                .WithMany(x => x.Entiries)
                .HasForeignKey(x => x.CreateById);
        }
    }
}
