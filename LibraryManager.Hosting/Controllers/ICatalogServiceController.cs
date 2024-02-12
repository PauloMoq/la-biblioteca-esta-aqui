using Microsoft.AspNetCore.Mvc;
using Services.Services;
using BusinessObjects.Entity;
using System.Collections.Generic;

namespace LibraryManager.Hosting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [HttpGet(Name = "GetCatalog")]
        public ActionResult<IEnumerable<Book>> GetCatalog()
        {
            try
            {
                var books = _catalogService.ShowCatalog();
                if (books == null || !books.Any())
                {
                    return NotFound("Aucun livre trouvé.");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur est survenue lors de la récupération du catalogue.");
                return StatusCode(500, "Une erreur interne est survenue, veuillez réessayer plus tard.");
            }
        }
    }
}
