using Application.Features.CategoryFeatures.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// Api operations for Categories
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(IMediator mediator, ILogger<CategoryController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<CategoryController> _logger = logger;

        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllCategoriesResponse>>> GetAllCategories(CancellationToken cancellationToken)
        {
            try
            {
                var request = new GetAllCategoriesRequest();
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
