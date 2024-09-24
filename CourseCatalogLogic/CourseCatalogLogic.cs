using CourseCatalogDb;
using CourseCatalogLogic.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CourseCatalogLogic;

public class CourseCatalogLogic(CourseCatalogDbContext context, IOptions<CatalogOptions> options, ILogger<CourseCatalogLogic> logger)
{
    private readonly ILogger _logger = logger;
    private readonly CourseCatalogDbContext _context = context;
    private readonly CatalogOptions _options = options.Value;
}