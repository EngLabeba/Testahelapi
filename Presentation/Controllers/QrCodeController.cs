using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.QrCodeFeatures.GenerateOfferShareQrCode;
using Application.Features.QrCodeFeatures.GenerateCustomQrCode;
using Application.Features.QrCodeFeatures.GetQrCodeImage;
using Application.Features.QrCodeFeatures.GetQrCodeImageFromData;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrCodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QrCodeController> _logger;

        public QrCodeController(IMediator mediator, ILogger<QrCodeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Generate QR code for offer share
        /// </summary>
        /// <param name="offerShareId">ID of the offer share</param>
        /// <param name="size">Size of the QR code (optional, default: 300)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code as base64 string with offer share details</returns>
        [HttpGet("offer-share/{offerShareId}")]
        public async Task<ActionResult<GenerateOfferShareQrCodeResponse>> GenerateOfferShareQrCode(
            int offerShareId, 
            [FromQuery] int size = 300,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new GenerateOfferShareQrCodeRequest
                {
                    OfferShareId = offerShareId,
                    Size = size
                };

                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating QR code for offer share {OfferShareId}", offerShareId);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Generate QR code from custom data
        /// </summary>
        /// <param name="request">Request containing data and size</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code as base64 string</returns>
        [HttpPost("generate")]
        public async Task<ActionResult<GenerateCustomQrCodeResponse>> GenerateQrCode(
            [FromBody] GenerateCustomQrCodeRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom QR code");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get QR code as image file for offer share
        /// </summary>
        /// <param name="offerShareId">ID of the offer share</param>
        /// <param name="size">Size of the QR code (optional, default: 300)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code as PNG image file</returns>
        [HttpGet("image/{offerShareId}")]
        public async Task<IActionResult> GetQrCodeImage(
            int offerShareId,
            [FromQuery] int size = 300,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new GetQrCodeImageRequest
                {
                    OfferShareId = offerShareId,
                    Size = size
                };

                var response = await _mediator.Send(request, cancellationToken);
                
                if (!response.Success)
                {
                    return BadRequest(response.ErrorMessage);
                }

                return File(response.QrCodeBytes, response.ContentType, response.FileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting QR code image for offer share {OfferShareId}", offerShareId);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get QR code as image file from custom data
        /// </summary>
        /// <param name="request">Request containing data and size</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>QR code as PNG image file</returns>
        [HttpPost("image")]
        public async Task<IActionResult> GetQrCodeImageFromData(
            [FromBody] GetQrCodeImageFromDataRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                
                if (!response.Success)
                {
                    return BadRequest(response.ErrorMessage);
                }

                return File(response.QrCodeBytes, response.ContentType, response.FileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting QR code image from custom data");
                return BadRequest(ex.Message);
            }
        }
    }
}