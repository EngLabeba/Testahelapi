using Domain.Entities;

namespace Application.Common.Services
{
    public interface IOfferShareService
    {
        Task<OfferShare?> GetOfferShareByIdAsync(int id);
        Task<OfferShare?> GetByShareTokenAsync(string shareToken);
        Task<OfferShare?> GetByQrCodeIdentifierAsync(string qrCodeIdentifier);
        Task<IEnumerable<OfferShare>> GetSharesByUserAsync(string userId);
        Task<OfferShare> CreateShareAsync(OfferShare offerShare);
        Task<bool> MarkAsScannedAsync(string qrCodeIdentifier, string scannedByUserId);
        Task<bool> MarkAsUsedAsync(string shareToken, string? usageNotes = null);
        Task<bool> DeleteShareAsync(int id);
    }
}
