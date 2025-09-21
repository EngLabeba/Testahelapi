using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Application.Repositories;
using Persistence.Common;

namespace Persistence.Repositories
{
    public class OfferShareRepository : BaseRepository<OfferShare>, IOfferShareRepository
    {
        public OfferShareRepository(OffersDbContext context) : base(context) { }

        public async Task<OfferShare?> GetByShareTokenAsync(string shareToken)
        {
            return await Context.OfferShares
                .Include(os => os.Offer)
                .ThenInclude(o => o.Category)
                .Include(os => os.Offer)
                .ThenInclude(o => o.DiscountType)
                .Include(os => os.Dependent)
                .FirstOrDefaultAsync(os => os.ShareToken == shareToken && os.IsActive);
        }

        public async Task<OfferShare?> GetByQrCodeIdentifierAsync(string qrCodeIdentifier)
        {
            return await Context.OfferShares
                .Include(os => os.Offer)
                .ThenInclude(o => o.Category)
                .Include(os => os.Offer)
                .ThenInclude(o => o.DiscountType)
                .Include(os => os.Dependent)
                .FirstOrDefaultAsync(os => os.QrCodeIdentifier == qrCodeIdentifier && os.IsActive);
        }

        public async Task<OfferShare?> GetOfferShareByIdAsync(int id)
        {
            return await Context.OfferShares
                .Include(os => os.Offer)
                .ThenInclude(o => o.Category)
                .Include(os => os.Offer)
                .ThenInclude(o => o.DiscountType)
                .Include(os => os.Dependent)
                .FirstOrDefaultAsync(os => os.Id == id && os.IsActive);
        }

        public async Task<IEnumerable<OfferShare>> GetSharesByUserAsync(string userId)
        {
            return await Context.OfferShares
                .Include(os => os.Offer)
                .ThenInclude(o => o.Category)
                .Include(os => os.Offer)
                .ThenInclude(o => o.DiscountType)
                .Include(os => os.Dependent)
                .Where(os => os.SharedByUserId == userId && os.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<OfferShare>> GetExpiredSharesAsync()
        {
            return await Context.OfferShares
                .Include(os => os.Offer)
                .Where(os => os.ExpiresAt.HasValue && os.ExpiresAt < DateTime.UtcNow && os.IsActive)
                .ToListAsync();
        }

        public Task<OfferShare> CreateShareAsync(OfferShare offerShare)
        {
            return Task.FromResult(offerShare);
        }

        public async Task<bool> MarkAsScannedAsync(string qrCodeIdentifier, string scannedByUserId)
        {
            var share = await GetByQrCodeIdentifierAsync(qrCodeIdentifier);
            if (share == null) return false;

            share.IsScanned = true;
            share.ScannedAt = DateTime.UtcNow;
            share.ScannedByUserId = scannedByUserId;
            return true;
        }

        public async Task<bool> MarkAsUsedAsync(string shareToken, string? usageNotes = null)
        {
            var share = await GetByShareTokenAsync(shareToken);
            if (share == null) return false;

            share.IsUsed = true;
            share.UsedAt = DateTime.UtcNow;
            share.UsageNotes = usageNotes;
            return true;
        }

        public async Task<bool> DeleteShareAsync(int id)
        {
            var share = await Context.OfferShares.FindAsync(id);
            if (share == null) return false;
            
            share.IsActive = false;
            Context.OfferShares.Update(share);
            return true;
        }
    }
}