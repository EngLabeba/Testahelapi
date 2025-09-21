using Domain.Entities;

namespace Application.Repositories
{
    public interface IOfferShareRepository
    {
        Task<OfferShare?> GetByShareTokenAsync(string shareToken);
        Task<OfferShare?> GetByQrCodeIdentifierAsync(string qrCodeIdentifier);
        Task<OfferShare?> GetOfferShareByIdAsync(int id);
        Task<IEnumerable<OfferShare>> GetSharesByUserAsync(string userId);
        Task<IEnumerable<OfferShare>> GetExpiredSharesAsync();
        Task<OfferShare> CreateShareAsync(OfferShare offerShare);
        Task<bool> MarkAsScannedAsync(string qrCodeIdentifier, string scannedByUserId);
        Task<bool> MarkAsUsedAsync(string shareToken, string? usageNotes = null);
        Task<bool> DeleteShareAsync(int id);
    }
}
