using CourseCatalogDb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalogDb;

public class CourseCatalogDbContext(DbContextOptions<CourseCatalogDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLesson> UserLessons { get; set; }

    private const string CreatedPropName = "CreatedOn_Utc";
    private const string UpdatedPropName = "LastUpdatedOn_Utc";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add Check constraint to pct fld, 1 = 100%
        modelBuilder.Entity<UserLesson>().ToTable(ul =>
            ul.HasCheckConstraint("CK_UserLesson_PctViewed", "PctViewed >= 0 AND PctViewed <= 1"));

        // For now, add timestamps to all entity types.
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entity.Name).Property<DateTime>(CreatedPropName).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity(entity.Name).Property<DateTime?>(UpdatedPropName);
        }

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Called by SaveChanges(Async) overrides to update timestamps on appropriate changed entities.
    /// </summary>
    private void UpdateTimestamps()
    {
        // Iterate over changed entities, and update appropriate timestamps for inserted & modified entities.
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State is EntityState.Added or EntityState.Modified))
        {
            var propName = entry.State == EntityState.Added ? CreatedPropName : UpdatedPropName;

            entry.Property(propName).CurrentValue = DateTime.UtcNow;
        }
    }
}