using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.EntityConfiguration.EntryComments
{
    public class EntryCommentEntityConfiguration : BaseEntityConfiguration<EntryComment>
    {
        public void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryComment", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.CreateBy)
                .WithMany(x => x.EntryComments)
                .HasForeignKey(x => x.CreateById)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Entiry)
                .WithMany(x => x.EntryComments)
                .HasForeignKey(x => x.EntiryId);
        
        }
    }
}
