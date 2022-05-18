using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWords.infrastructure.Persistent.EntityConfiguration.Entry
{
    public class EntryFovoriteEntityConfiguration : BaseEntityConfiguration<EntryFovorite>
    {
        public void Configure(EntityTypeBuilder<EntryFovorite> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryFovorite", BWordsContext.DATABASE_SHAME);
            builder.HasOne(x => x.Entiry)
                .WithMany(x => x.EntityFovorites)
                .HasForeignKey(x => x.EntryId);
            builder.HasOne(x => x.GreatedUser)
                .WithMany(x => x.EntityFovorites)
                .HasForeignKey(x => x.CreateById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
