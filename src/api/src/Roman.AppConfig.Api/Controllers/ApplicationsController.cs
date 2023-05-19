using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.AppConfig.Application.Queries;
using Roman.CQRS.Abstraction.Query;

namespace Roman.AppConfig.Api.Controllers
{
    /// <summary>
    /// Applications controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        /// <summary>
        /// Get list of applications.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        // GET: applications
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromServices] IQueryHandler<ApplicationListQuery, ApplicationListQueryResult> handler,
            [FromQuery] string? sortBy = null,
            [FromQuery] bool? sortDesc = null,
            [FromQuery] int page = 1,
            [FromQuery] int itemsPerPage = -1)
        {
            var query = new ApplicationListQuery
            {
                SortBy = sortBy,
                SortDesc = sortDesc,
                Page = page,
                ItemsPerPage = itemsPerPage,
            };

            var result = await handler.ExecuteAsync(query).ToApiActionResultAsync(HttpContext);

            return result;
        }

        /// <summary>
        /// Get application by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: applications/{id:guid}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }
    }
}