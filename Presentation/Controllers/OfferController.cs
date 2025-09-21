
using Application.Common.Models;
using Application.Features.DeviceFeatures.GetPaginated;
using Application.Features.OffersFeatures.GetFiltered;
using Application.Features.OffersFeatures.GetDetails;
using Application.Features.OffersFeatures.SaveOffer;
using Application.Features.OffersFeatures.GetSavedOffers;
using Application.Features.OffersFeatures.GetSharingMethods;
using Application.Features.OffersFeatures.GenerateOfferQrCode;
using Application.Features.OffersFeatures.GenerateOfferQrCodeLink;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    /// <summary>
    /// Api operations for Device
    /// </summary>
    [Route("api/Offers")]
    [ApiController]
    public class OfferApiController(IMediator mediator, ILogger<OfferApiController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        private readonly ILogger<OfferApiController> _logger = logger;


        /// <summary>
        /// Get all offers paginated with optional category filter, user location, and saved status
        /// </summary>
        /// <param name="request">Request containing pagination input, optional category ID, user ID, and user location coordinates</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Paginated list of offers with distance calculations and saved status</returns>
          [HttpPost]
          [Route("get-paginated-offers")]
          public async Task<ActionResult<PaginatedList<GetPaginatedOfferResponse>>> GetPaginated(GetPaginatedOfferRequest request, CancellationToken cancellationToken)
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

          /// <summary>
        /// Get offers filtered by type (Nearest location, Last inserted, Max used, Higher evaluation) with optional category filter
          /// </summary>
        /// <param name="request">Request containing pagination input, filter type, optional category ID, user ID, and user location coordinates</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Paginated list of filtered offers with distance calculations and saved status</returns>
        [HttpPost]
        [Route("get-filtered-offers")]
        public async Task<ActionResult<PaginatedList<GetFilteredOffersResponse>>> GetFiltered(GetFilteredOffersRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Get detailed information about a specific offer
        /// </summary>
        /// <param name="request">Request containing offer ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Comprehensive offer details including locations, platforms, sharing methods, and offer information</returns>
          [HttpPost]
        [Route("get-offer-details")]
        public async Task<ActionResult<GetOfferDetailsResponse>> GetOfferDetails(GetOfferDetailsRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Save an offer for a user
        /// </summary>
        /// <param name="request">Request containing offer ID, user ID, and optional notes</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result of saving the offer</returns>
        [HttpPost]
        [Route("save-offer")]
        public async Task<ActionResult<SaveOfferResponse>> SaveOffer(SaveOfferRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Get all saved offers for a user
        /// </summary>
        /// <param name="request">Request containing user ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of all saved offers for the user</returns>
        [HttpPost]
        [Route("get-saved-offers")]
        public async Task<ActionResult<GetSavedOffersResponse>> GetSavedOffers(GetSavedOffersRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Get all sharing methods for a specific offer
        /// </summary>
        /// <param name="request">Request containing offer ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of all sharing methods available for the offer</returns>
        [HttpPost]
        [Route("get-offer-sharing-methods")]
        public async Task<ActionResult<GetOfferSharingMethodsResponse>> GetOfferSharingMethods(GetOfferSharingMethodsRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Generate QR code for a specific offer
        /// </summary>
        /// <param name="request">Request containing offer ID, size, and optional custom data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code as base64 string along with offer details</returns>
        [HttpPost]
        [Route("generate-qr-code")]
        public async Task<ActionResult<GenerateOfferQrCodeResponse>> GenerateOfferQrCode(GenerateOfferQrCodeRequest request, CancellationToken cancellationToken)
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

        /// <summary>
        /// Generate QR code link/data for a specific offer (for client-side QR generation)
        /// </summary>
        /// <param name="request">Request containing offer ID, format, and optional custom data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code data/link for client-side generation along with offer details</returns>
        [HttpPost]
        [Route("generate-qr-code-link")]
        public async Task<ActionResult<GenerateOfferQrCodeLinkResponse>> GenerateOfferQrCodeLink(GenerateOfferQrCodeLinkRequest request, CancellationToken cancellationToken)
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

