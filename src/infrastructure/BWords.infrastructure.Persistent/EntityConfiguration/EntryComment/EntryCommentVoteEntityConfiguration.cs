using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.EntryComments
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryCommentVote", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.EntryComment)
               .WithMany(x => x.EntityCommentVotes)
               .HasForeignKey(x => x.EntiryCommentId);
              
        }
    }
}
