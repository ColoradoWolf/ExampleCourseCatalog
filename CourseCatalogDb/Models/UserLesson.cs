using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalogDb.Models;

[PrimaryKey("UserId", "LessonId")]
public class UserLesson
{
    /// <summary>
    /// Foreign Key to Users table, part of primary key.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Foreign Key to Lessons table, part of primary key.
    /// </summary>
    public int LessonId { get; set; }

    [Required]
    public float PctViewed { get; set; }

    /// <summary>
    /// Parent User ref
    /// </summary>
    [JsonIgnore]
    public User User { get; set; } = null!;

    /// <summary>
    /// Parent Lesson ref
    /// </summary>
    [JsonIgnore]
    public Lesson Lesson { get; set; } = null!;
}