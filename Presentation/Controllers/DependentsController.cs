using Application.Features.DependentsFeatures.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// Api operations for Dependents
    /// </summary>
    [Route("api/Dependents")]
    [ApiController]
    public class DependentsController(IMediator mediator, ILogger<DependentsController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<DependentsController> _logger = logger;

        /// <summary>
        /// Get all active dependents
        /// </summary>
        /// <param name="request">Request with no parameters</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of all active dependents</returns>
        [HttpPost]
        [Route("get-all-dependents")]
        public async Task<ActionResult<GetAllDependentsResponse>> GetAllDependents(GetAllDependentsRequest request, CancellationToken cancellationToken)
        {
            try
            {
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
