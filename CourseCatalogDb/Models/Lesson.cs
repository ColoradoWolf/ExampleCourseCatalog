using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseCatalogDb.Models;

public class Lesson
{
    /// <summary>
    /// Lesson Primary Key field
    /// </summary>
    [Key]
    public int LessonId { get; set; }

    /// <summary>
    /// The (required) name of the lesson.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string LessonName { get; set; }

    /// <summary>
    /// The (optional) description of the lesson.
    /// </summary>
    [StringLength(500, MinimumLength = 1)]
    public string? LessonDesc { get; set; }

    /// <summary>
    /// Required URL to the video for this lesson.
    /// </summary>
    [Required]
    public required Uri VideoUrl { get; set; }

    /// <summary>
    /// Required length of the video represented by this lesson.
    /// </summary>
    [Required]
    public TimeSpan VideoLength { get; set; }

    #region Parent Foreign Key Data and Nav/Ref Prop
    /// <summary>
    /// ID of parent section.  Foreign Key.
    /// </summary>
    public int SectionId { get; set; }

    /// <summary>
    /// Reference property to parent section.
    /// </summary>
    [JsonIgnore]
    public Section Section { get; set; } = null!;
    #endregion Parent Foreign Key Data and Nav/Ref Prop

    //public ICollection<UserLesson> UserLessons { get; } = new List<UserLesson>();
}