using Microsoft.AspNetCore.Mvc;
using Services.Services;
using BusinessObjects.Entity;

namespace LibraryManager.Hosting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("books")]
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

        [HttpGet]
        [Route("id/{id}")]
        public ActionResult<Book> GetCatalog(int id)
        {
            try
            {
                var book = _catalogService.FindBook(id);
                if (book == null)
                {
                    return NotFound("Livre inexistant.");
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur est survenue lors de la récupération du livre.");
                return StatusCode(500, "Une erreur interne est survenue, veuillez réessayer plus tard.");
            }
        }


        [HttpGet]
        [Route("type/{type}")]
        public ActionResult<IEnumerable<Book>> GetCatalog(BusinessObjects.Entity.Type type)
        {
            try
            {
                var books = _catalogService.ShowCatalog(type);
                if (books == null || !books.Any())
                {
                    return NotFound("Aucun livre fantastique");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur est survenue lors de la récupération du catalogue.");
                return StatusCode(500, "Une erreur interne est survenue, veuillez réessayer plus tard.");
            }
        }

        [HttpGet]
        [Route("topRatedBook")]
        public ActionResult<IEnumerable<Book>> findBestBookInCatalog()
        {
            try
            {
                var book = _catalogService.findBestBookInCatalog();
                if (book == null)
                {
                    return NotFound("Pas de meilleur livre.");
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur est survenue lors de la récupération du livre.");
                return StatusCode(500, "Une erreur interne est survenue, veuillez réessayer plus tard.");
            }
        }

        [HttpGet]
        [Route("fantasy")]
        public ActionResult<IEnumerable<Book>> findFantasyBooksInCatalog()
        {
            try
            {
                var books = _catalogService.findFantasyBooksInCatalog();
                if (books == null || !books.Any())
                {
                    return NotFound("Aucun livre fantastique");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur est survenue lors de la récupération du catalogue.");
                return StatusCode(500, "Une erreur interne est survenue, veuillez réessayer plus tard.");
            }
        }
        [HttpGet]
        [Route("add")]
        public ActionResult<IEnumerable<Book>> AddBook()
        {
            return Ok();
        }
        [HttpGet]
        [Route("update/{id}")]
        public ActionResult<IEnumerable<Book>> UpdateBook(int id)
        {
            return Ok();
        }
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult<IEnumerable<Book>> DeleteBook(int id)
        {
            return Ok();
        }

    }
}
