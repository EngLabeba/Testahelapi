using Microsoft.AspNetCore.Mvc;
using Persistence.Services;
using Domain.Entities;

namespace Offersapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferShareController : ControllerBase
    {
        private readonly IOfferShareService _offerShareService;

        public OfferShareController(IOfferShareService offerShareService)
        {
            _offerShareService = offerShareService;
        }

        /// <summary>
        /// Share an offer with a dependent or another user
        /// </summary>
        [HttpPost("share")]
        public async Task<ActionResult<OfferShare>> ShareOffer([FromBody] ShareOfferRequest request)
        {
            try
            {
                var offerShare = await _offerShareService.ShareOfferAsync(
                    request.OfferId,
                    request.SharedByUserId,
                    request.DependentId,
                    request.SharedWithUserId,
                    request.Notes
                );

                return Ok(offerShare);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get offer details by share token (for QR code scanning)
        /// </summary>
        [HttpGet("scan/{shareToken}")]
        public async Task<ActionResult<OfferShare>> ScanOfferShare(string shareToken, [FromQuery] string scannedByUserId)
        {
            try
            {
                var offerShare = await _offerShareService.ScanOfferShareAsync(shareToken, scannedByUserId);
                
                if (offerShare == null)
                    return NotFound("Offer share not found or expired");

                return Ok(offerShare);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Validate QR code data (for merchant/staff validation)
        /// </summary>
        [HttpPost("validate")]
        public async Task<ActionResult<OfferShare>> ValidateQrCode([FromBody] ValidateQrCodeRequest request)
        {
            try
            {
                var offerShare = await _offerShareService.ValidateQrCodeAsync(request.QrCodeData, request.ValidatedByUserId);
                
                if (offerShare == null)
                    return BadRequest("Invalid QR code or offer expired");

                return Ok(offerShare);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get offer share by QR code identifier
        /// </summary>
        [HttpGet("qr/{qrCodeIdentifier}")]
        public async Task<ActionResult<OfferShare>> GetOfferShareByQrCode(string qrCodeIdentifier)
        {
            try
            {
                var offerShare = await _offerShareService.GetOfferShareByQrCodeIdentifierAsync(qrCodeIdentifier);
                
                if (offerShare == null)
                    return NotFound("Offer share not found");

                return Ok(offerShare);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Use an offer share (mark as used)
        /// </summary>
        [HttpPost("use/{offerShareId}")]
        public async Task<ActionResult> UseOfferShare(int offerShareId, [FromBody] UseOfferRequest? request = null)
        {
            try
            {
                var success = await _offerShareService.UseOfferShareAsync(offerShareId, request?.UsageNotes);
                
                if (!success)
                    return BadRequest("Unable to use offer share");

                return Ok(new { message = "Offer used successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all offers shared by an employee
        /// </summary>
        [HttpGet("employee/{employeeId}/shared")]
        public async Task<ActionResult<IEnumerable<OfferShare>>> GetEmployeeSharedOffers(string employeeId)
        {
            try
            {
                var sharedOffers = await _offerShareService.GetEmployeeSharedOffersAsync(employeeId);
                return Ok(sharedOffers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all offers received by a user
        /// </summary>
        [HttpGet("user/{userId}/received")]
        public async Task<ActionResult<IEnumerable<OfferShare>>> GetUserReceivedOffers(string userId)
        {
            try
            {
                var receivedOffers = await _offerShareService.GetUserReceivedOffersAsync(userId);
                return Ok(receivedOffers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete an offer share
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOfferShare(int id)
        {
            try
            {
                var success = await _offerShareService.DeleteOfferShareAsync(id);
                
                if (!success)
                    return NotFound("Offer share not found");

                return Ok(new { message = "Offer share deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cleanup expired offer shares
        /// </summary>
        [HttpPost("cleanup")]
        public async Task<ActionResult> CleanupExpiredShares()
        {
            try
            {
                await _offerShareService.CleanupExpiredSharesAsync();
                return Ok(new { message = "Expired shares cleaned up successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class ShareOfferRequest
    {
        public int OfferId { get; set; }
        public string SharedByUserId { get; set; } = string.Empty;
        public int? DependentId { get; set; }
        public string? SharedWithUserId { get; set; }
        public string? Notes { get; set; }
    }

    public class UseOfferRequest
    {
        public string? UsageNotes { get; set; }
    }

    public class ValidateQrCodeRequest
    {
        public string QrCodeData { get; set; } = string.Empty;
        public string ValidatedByUserId { get; set; } = string.Empty;
    }
}
