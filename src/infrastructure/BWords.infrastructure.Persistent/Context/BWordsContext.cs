using BWords.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.Context
{
    public class BWordsContext:DbContext
    {
        public const string DATABASE_SHAME = "dbo"; 
        public BWordsContext(DbContextOptions options):base(options)
        {

        }
        public BWordsContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=.;Initial catalog=BWordBD;Integrated security=true";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn, ops =>
                {
                    ops.EnableRetryOnFailure();
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<User>   Users { get; set; }
        public DbSet<Entiry> Entiries { get; set; }

        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFovorite> EntryFovorites { get; set; }

        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFovorite> EntryCommentFovorites { get; set; }

        public DbSet<EmailConfiguration> EmailConfigurations { get; set; }



        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            var addedEntity = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => (BaseEntity)x.Entity);
            PrepareAddedEntityes(addedEntity);
        }
        private void PrepareAddedEntityes(IEnumerable<BaseEntity> entities)
        {
            foreach (var item in entities)
            {
                if (item.CreateDate==DateTime.MinValue)
                item.CreateDate = DateTime.Now;
            }
        }

    }
}
