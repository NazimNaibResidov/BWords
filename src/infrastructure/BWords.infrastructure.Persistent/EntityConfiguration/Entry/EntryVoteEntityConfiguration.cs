using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.Entry
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguration<EntryVote>
    {
        public void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryVote", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.Entiry)
                .WithMany(x => x.EntityVotes)
                .HasForeignKey(x => x.EntiryId);
        }
    }
}
