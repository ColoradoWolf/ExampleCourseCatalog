using System.ComponentModel.DataAnnotations;

namespace CourseCatalogDb.Models;

/// <summary>
/// Course domain model represents a course in the catalog.  Courses contain
/// Sections, which contain Lessons.
/// </summary>
public class Course
{
    /// <summary>
    /// Primary Key field
    /// </summary>
    [Key]
    public int CourseId { get; set; }

    /// <summary>
    /// The (required) name of the catalog item (the course, section, or lesson).
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string CourseName { get; set; }

    /// <summary>
    /// The (optional) description of the catalog item (the course, section, or lesson).
    /// </summary>
    [StringLength(500, MinimumLength = 1)]
    public string? CourseDesc { get; set; }

    public ICollection<Section> Sections { get; } = new List<Section>();
}