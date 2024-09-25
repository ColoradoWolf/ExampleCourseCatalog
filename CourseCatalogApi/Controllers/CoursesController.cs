using CourseCatalogDb;
using CourseCatalogDb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CourseCatalogApi.Controllers;

/// <summary>
/// Provides endpoints for course-related data.
/// </summary>
/// <param name="context">DB context for data access.</param>
/// <param name="options">Configuration options for course catalog functionality.</param>
[Route("api/[controller]")]
[ApiController]
public class CoursesController(CourseCatalogDbContext context, IOptions<CatalogOptions> options) : ControllerBase
{
    private readonly CatalogOptions _options = options.Value;

    /// <summary>
    /// Provides listing of courses in the catalog.  For now, always includes associated sections and lessons, and data paginated
    /// with page size given in CatalogOptions (defaults to 1000).
    /// </summary>
    /// <param name="pageNum">Provides a page number to return.  Include in query string.</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Course>>> Index(int? pageNum = 1)
    {
        if (pageNum < 1)
        {
            return BadRequest("Page number must be >= 1.");
        }

        // Use basic Skip/Take method of pagination here.  Would impl better method with more time.
        //  NOTE:  Could be issue with Take/Skip behavior with includes (multi-level joins).
        var qry = context.Courses
            .Include(c => c.Sections.OrderBy(s => s.Order))
            .ThenInclude(s => s.Lessons.OrderBy(l => l.Order))
            .Skip(((pageNum ?? 1) - 1) * _options.PageSize)
            .Take(_options.PageSize)
            .AsNoTracking();

        return await qry.ToListAsync();
    }
}