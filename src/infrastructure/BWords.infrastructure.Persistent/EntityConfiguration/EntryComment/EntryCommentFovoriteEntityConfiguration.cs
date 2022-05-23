using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.EntryComments
{
    public class EntryCommentFovoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFovorite>
    {
        public void Configure(EntityTypeBuilder<EntryCommentFovorite> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryCommentFovorite", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.EntryComment)
                .WithMany(x => x.EntityCommentFovorites)
                .HasForeignKey(x => x.EntryCommandId);
            builder.HasOne(x => x.CreatedUser)
                .WithMany(x => x.EntityCommentFovorites)
                .HasForeignKey(x => x.CreateById);
            
        }
    }
}
