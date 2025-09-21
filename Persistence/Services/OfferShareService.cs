using Application.Repositories;
using Application.Common.Services;
using Domain.Entities;

namespace Persistence.Services
{
    public class OfferShareService : IOfferShareService
    {
        private readonly IOfferShareRepository _offerShareRepository;

        public OfferShareService(IOfferShareRepository offerShareRepository)
        {
            _offerShareRepository = offerShareRepository;
        }

        public async Task<OfferShare?> GetOfferShareByIdAsync(int id)
        {
            return await _offerShareRepository.GetOfferShareByIdAsync(id);
        }

        public async Task<OfferShare?> GetByShareTokenAsync(string shareToken)
        {
            return await _offerShareRepository.GetByShareTokenAsync(shareToken);
        }

        public async Task<OfferShare?> GetByQrCodeIdentifierAsync(string qrCodeIdentifier)
        {
            return await _offerShareRepository.GetByQrCodeIdentifierAsync(qrCodeIdentifier);
        }

        public async Task<IEnumerable<OfferShare>> GetSharesByUserAsync(string userId)
        {
            return await _offerShareRepository.GetSharesByUserAsync(userId);
        }

        public async Task<OfferShare> CreateShareAsync(OfferShare offerShare)
        {
            return await _offerShareRepository.CreateShareAsync(offerShare);
        }

        public async Task<bool> MarkAsScannedAsync(string qrCodeIdentifier, string scannedByUserId)
        {
            return await _offerShareRepository.MarkAsScannedAsync(qrCodeIdentifier, scannedByUserId);
        }

        public async Task<bool> MarkAsUsedAsync(string shareToken, string? usageNotes = null)
        {
            return await _offerShareRepository.MarkAsUsedAsync(shareToken, usageNotes);
        }

        public async Task<bool> DeleteShareAsync(int id)
        {
            return await _offerShareRepository.DeleteShareAsync(id);
        }
    }
}