using Application.Features.OfferUsageFeatures.UseOffer;
using Application.Features.OfferUsageFeatures.GetOfferUsageStats;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferUsageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferUsageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Record that an employee used an offer for a dependent
        /// </summary>
        [HttpPost("use")]
        public async Task<ActionResult<RecordOfferUsageResponse>> UseOffer([FromBody] RecordOfferUsageCommand command)
        {
            var result = await _mediator.Send(command);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get offer usage statistics
        /// </summary>
        [HttpGet("stats")]
        public async Task<ActionResult<GetOfferUsageStatsResponse>> GetUsageStats(
            [FromQuery] int? offerId = null,
            [FromQuery] int? employeeId = null,
            [FromQuery] int? dependentId = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var query = new GetOfferUsageStatsQuery
            {
                OfferId = offerId,
                EmployeeId = employeeId,
                DependentId = dependentId,
                FromDate = fromDate,
                ToDate = toDate
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get usage statistics for a specific offer
        /// </summary>
        [HttpGet("stats/offer/{offerId}")]
        public async Task<ActionResult<GetOfferUsageStatsResponse>> GetOfferStats(int offerId)
        {
            var query = new GetOfferUsageStatsQuery
            {
                OfferId = offerId
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Get usage statistics for a specific employee
        /// </summary>
        [HttpGet("stats/employee/{employeeId}")]
        public async Task<ActionResult<GetOfferUsageStatsResponse>> GetEmployeeStats(int employeeId)
        {
            var query = new GetOfferUsageStatsQuery
            {
                EmployeeId = employeeId
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
