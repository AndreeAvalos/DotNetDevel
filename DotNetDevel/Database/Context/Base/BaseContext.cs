using DotNetDevel.Entities;
using DotNetDevel.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotNetDevel.Database.Context.Base;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerSurvey>(builder =>
        {
            builder.HasKey(entity => new {entity.SurveyId, entity.FieldSurveyId});
        });
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry> entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntityTimestamp && e.State is EntityState.Added or EntityState.Modified);

        foreach (EntityEntry entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    ((BaseEntityTimestamp) entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((BaseEntityTimestamp) entityEntry.Entity).Active = true;
                    break;
                case EntityState.Modified:
                    ((BaseEntityTimestamp) entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    Entry((BaseEntityTimestamp) entityEntry.Entity).Property(x => x.CreatedAt).IsModified = false;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                default:
                    continue;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    public virtual DbSet<UserEntity> UserEntity { get; set; } = null!;
}