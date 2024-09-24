using System.ComponentModel.DataAnnotations;

namespace CourseCatalogDb.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string ScreenName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string Email { get; set; }

    public ICollection<UserLesson> UserLessons { get; } = new List<UserLesson>();
}