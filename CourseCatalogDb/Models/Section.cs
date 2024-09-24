using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseCatalogDb.Models;

/// <summary>
/// Section represents an individual module within a course, and
/// references the Lessons the module contains.
/// </summary>
public class Section
{
    /// <summary>
    /// Section Primary Key field
    /// </summary>
    [Key]
    public int SectionId { get; set; }

    /// <summary>
    /// The (required) name of the section.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string SectionName { get; set; }

    /// <summary>
    /// The (optional) description of the section.
    /// </summary>
    [StringLength(500, MinimumLength = 1)]
    public string? SectionDesc { get; set; }

    /// <summary>
    /// The lessons that are a part of this section.
    /// </summary>
    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    #region Parent Foreign Key Data and Nav/Ref Prop
    /// <summary>
    /// ID of parent course.  Foreign Key.
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// Reference property to parent course.
    /// </summary>
    [JsonIgnore]
    public Course Course { get; set; } = null!;
    #endregion Parent Foreign Key Data and Nav/Ref Prop
}