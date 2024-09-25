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

        #region Seed Data
        // Add simple seed data to DB (could be temporary).
        // Add Course seed data
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                CourseId = 1,
                CourseName = "Course #1",
                CourseDesc = "This is Course #1"
            },
            new Course
            {
                CourseId = 2,
                CourseName = "Course #2",
                CourseDesc = "This is Course #2"
            },
            new Course
            {
                CourseId = 3,
                CourseName = "Course #3",
                CourseDesc = "This is Course #3"
            });

        // Add Section seed data
        modelBuilder.Entity<Section>().HasData(
            new Section
            {
                SectionId = 1,
                SectionName = "Section #1",
                SectionDesc = "1st Section of Course #1",
                CourseId = 1,
                Order = 1
            },
            new Section
            {
                SectionId = 2,
                SectionName = "Section #2",
                SectionDesc = "2nd Section of Course #1",
                CourseId = 1,
                Order = 2
            },
            new Section
            {
                SectionId = 3,
                SectionName = "Section #3",
                SectionDesc = "1st Section of Course #2",
                CourseId = 2,
                Order = 1
            },
            new Section
            {
                SectionId = 4,
                SectionName = "Section #4",
                SectionDesc = "2nd Section of Course #2",
                CourseId = 2,
                Order = 2
            },
            new Section
            {
                SectionId = 5,
                SectionName = "Section #5",
                SectionDesc = "3rd Section of Course #2",
                CourseId = 2,
                Order = 3
            },
            new Section
            {
                SectionId = 6,
                SectionName = "Section #6",
                SectionDesc = "1st Section of Course #3",
                CourseId = 3,
                Order = 1
            });

        // Add Lesson seed data
        modelBuilder.Entity<Lesson>().HasData(
            new Lesson
            {
                LessonId = 1,
                LessonName = "Lesson #1",
                LessonDesc = "1st Lesson of Section #1",
                SectionId = 1,
                VideoUrl = new Uri("https://xyz.com/videos/lesson1.mp4"),
                VideoLength = new TimeSpan(0, 30, 25),
                Order = 1
            },
            new Lesson
            {
                LessonId = 2,
                LessonName = "Lesson #2",
                LessonDesc = "1st Lesson of Section #2",
                SectionId = 2,
                VideoUrl = new Uri("https://xyz.com/videos/lesson2.mp4"),
                VideoLength = new TimeSpan(0, 15, 46),
                Order = 1
            },
            new Lesson
            {
                LessonId = 3,
                LessonName = "Lesson #3",
                LessonDesc = "1st Lesson of Section #3",
                SectionId = 3,
                VideoUrl = new Uri("https://xyz.com/videos/lesson3.mp4"),
                VideoLength = new TimeSpan(0, 45, 15),
                Order = 1
            },
            new Lesson
            {
                LessonId = 4,
                LessonName = "Lesson #4",
                LessonDesc = "1st Lesson of Section #4",
                SectionId = 4,
                VideoUrl = new Uri("https://xyz.com/videos/lesson4.mp4"),
                VideoLength = new TimeSpan(0, 20, 10),
                Order = 1
            },
            new Lesson
            {
                LessonId = 5,
                LessonName = "Lesson #5",
                LessonDesc = "1st Lesson of Section #5",
                SectionId = 5,
                VideoUrl = new Uri("https://xyz.com/videos/lesson5.mp4"),
                VideoLength = new TimeSpan(0, 18, 57),
                Order = 1
            },
            new Lesson
            {
                LessonId = 6,
                LessonName = "Lesson #6",
                LessonDesc = "1st Lesson of Section #6",
                SectionId = 6,
                VideoUrl = new Uri("https://xyz.com/videos/lesson6.mp4"),
                VideoLength = new TimeSpan(0, 10, 53),
                Order = 1
            },
            new Lesson
            {
                LessonId = 7,
                LessonName = "Lesson #7",
                LessonDesc = "2nd Lesson of Section #1",
                SectionId = 1,
                VideoUrl = new Uri("https://xyz.com/videos/lesson7.mp4"),
                VideoLength = new TimeSpan(0, 12, 33),
                Order = 2
            },
            new Lesson
            {
                LessonId = 8,
                LessonName = "Lesson #8",
                LessonDesc = "2nd Lesson of Section #2",
                SectionId = 2,
                VideoUrl = new Uri("https://xyz.com/videos/lesson8.mp4"),
                VideoLength = new TimeSpan(0, 16, 5),
                Order = 2
            },
            new Lesson
            {
                LessonId = 9,
                LessonName = "Lesson #9",
                LessonDesc = "2nd Lesson of Section #3",
                SectionId = 3,
                VideoUrl = new Uri("https://xyz.com/videos/lesson9.mp4"),
                VideoLength = new TimeSpan(0, 22, 9),
                Order = 2
            },
            new Lesson
            {
                LessonId = 10,
                LessonName = "Lesson #10",
                LessonDesc = "2nd Lesson of Section #4",
                SectionId = 4,
                VideoUrl = new Uri("https://xyz.com/videos/lesson10.mp4"),
                VideoLength = new TimeSpan(0, 21, 45),
                Order = 2
            },
            new Lesson
            {
                LessonId = 11,
                LessonName = "Lesson #11",
                LessonDesc = "2nd Lesson of Section #5",
                SectionId = 5,
                VideoUrl = new Uri("https://xyz.com/videos/lesson11.mp4"),
                VideoLength = new TimeSpan(0, 21, 22),
                Order = 2
            },
            new Lesson
            {
                LessonId = 12,
                LessonName = "Lesson #12",
                LessonDesc = "1st Lesson of Section #6",
                SectionId = 6,
                VideoUrl = new Uri("https://xyz.com/videos/lesson12.mp4"),
                VideoLength = new TimeSpan(0, 14, 28),
                Order = 2
            },
            new Lesson
            {
                LessonId = 13,
                LessonName = "Lesson #13",
                LessonDesc = "3rd Lesson of Section #6",
                SectionId = 6,
                VideoUrl = new Uri("https://xyz.com/videos/lesson13.mp4"),
                VideoLength = new TimeSpan(0, 16, 47),
                Order = 3
            },
            new Lesson
            {
                LessonId = 14,
                LessonName = "Lesson #14",
                LessonDesc = "3rd Lesson of Section #3",
                SectionId = 3,
                VideoUrl = new Uri("https://xyz.com/videos/lesson14.mp4"),
                VideoLength = new TimeSpan(0, 11, 9),
                Order = 3
            },
            new Lesson
            {
                LessonId = 15,
                LessonName = "Lesson #15",
                LessonDesc = "3rd Lesson of Section #2",
                SectionId = 2,
                VideoUrl = new Uri("https://xyz.com/videos/lesson15.mp4"),
                VideoLength = new TimeSpan(0, 19, 58),
                Order = 3
            });

        // Add User seed data
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Email = "qwerty@some-email.org",
                ScreenName = "Qwerty McGee"
            },
            new User
            {
                UserId = 2,
                Email = "xyz@abc.net",
                ScreenName = "Joe Schmoe"
            });
        #endregion Seed Data


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