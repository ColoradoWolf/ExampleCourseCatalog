using CourseCatalogApi.Requests;
using CourseCatalogDb;
using CourseCatalogDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalogApi.Controllers;

/// <summary>
/// Provides endpoints for user-related data.
/// </summary>
/// <param name="context">DB context</param>
[Route("api/[controller]")]
[ApiController]
public class UsersController(CourseCatalogDbContext context) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId">User ID to insert/update lesson data.</param>
    /// <param name="request">Provides lesson ID and pct viewed data.</param>
    /// <returns></returns>
    [HttpPost("{userId:int}/lessons/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> PostUserLessonAsync(int userId, LessonViewedRequest request)
    {
        var dbUserLesson =
            await context.UserLessons.SingleOrDefaultAsync(ul =>
                ul.UserId == userId && ul.LessonId == request.LessonId);

        if (dbUserLesson == null)
        {
            context.UserLessons.Add(new UserLesson
            {
                UserId = userId,
                LessonId = request.LessonId,
                PctViewed = request.PctViewed
            });
        }
        else
        {
            dbUserLesson.PctViewed = request.PctViewed;
        }

        try
        {
            return await context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException)
        {
            return BadRequest("Unable to save data.  Please verify the user and lesson IDs provided are correct, and pct is between 0 and 1.");
        }
        catch
        {
            return new StatusCodeResult(500);
        }
    }
}