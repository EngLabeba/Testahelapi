using Application.Repositories;
using Domain.Entities;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Common;

namespace Persistence.Repositories
{
    public class OfferUsageRepository : BaseRepository<OfferUsage>, IOfferUsageRepository
    {
        public OfferUsageRepository(OffersDbContext context) : base(context)
        {
        }

        public async Task<OfferUsage> RecordOfferUsageAsync(int offerId, int employeeId, int dependentId, string? notes = null, string? locationUsed = null, decimal? amountSaved = null)
        {
            // Create new offer usage record
            var offerUsage = new OfferUsage
            {
                OfferId = offerId,
                EmployeeId = employeeId,
                DependentId = dependentId,
                UsedAt = DateTime.UtcNow,
                Notes = notes,
                LocationUsed = locationUsed,
                AmountSaved = amountSaved,
                IsVerified = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await Context.OfferUsages.AddAsync(offerUsage);

            // Increment the offer's usage count
            var offer = await Context.Offers.FindAsync(offerId);
            if (offer != null)
            {
                offer.CurrentUses++;
                Context.Offers.Update(offer);
            }

            await Context.SaveChangesAsync();
            return offerUsage;
        }

        public async Task<IEnumerable<OfferUsage>> GetOfferUsagesByEmployeeAsync(int employeeId)
        {
            return await Context.OfferUsages
                .Include(ou => ou.Offer)
                .Include(ou => ou.Dependent)
                .Where(ou => ou.EmployeeId == employeeId && ou.IsActive)
                .OrderByDescending(ou => ou.UsedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<OfferUsage>> GetOfferUsagesByOfferAsync(int offerId)
        {
            return await Context.OfferUsages
                .Include(ou => ou.Employee)
                .Include(ou => ou.Dependent)
                .Where(ou => ou.OfferId == offerId && ou.IsActive)
                .OrderByDescending(ou => ou.UsedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<OfferUsage>> GetOfferUsagesByDependentAsync(int dependentId)
        {
            return await Context.OfferUsages
                .Include(ou => ou.Offer)
                .Include(ou => ou.Employee)
                .Where(ou => ou.DependentId == dependentId && ou.IsActive)
                .OrderByDescending(ou => ou.UsedAt)
                .ToListAsync();
        }

        public async Task<int> GetUsageCountForOfferAsync(int offerId)
        {
            return await Context.OfferUsages
                .Where(ou => ou.OfferId == offerId && ou.IsActive)
                .CountAsync();
        }

        public async Task<bool> HasEmployeeUsedOfferForDependentAsync(int offerId, int employeeId, int dependentId)
        {
            return await Context.OfferUsages
                .AnyAsync(ou => ou.OfferId == offerId && 
                               ou.EmployeeId == employeeId && 
                               ou.DependentId == dependentId && 
                               ou.IsActive);
        }

        public IQueryable<OfferUsage> GetQueryable()
        {
            return Context.OfferUsages.AsQueryable();
        }

        public async Task<IEnumerable<OfferUsage>> GetOfferUsagesWithFiltersAsync(int? offerId = null, int? employeeId = null, int? dependentId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = Context.OfferUsages
                .Include(ou => ou.Offer)
                .Include(ou => ou.Employee)
                .Include(ou => ou.Dependent)
                .Where(ou => ou.IsActive);

            if (offerId.HasValue)
                query = query.Where(ou => ou.OfferId == offerId.Value);

            if (employeeId.HasValue)
                query = query.Where(ou => ou.EmployeeId == employeeId.Value);

            if (dependentId.HasValue)
                query = query.Where(ou => ou.DependentId == dependentId.Value);

            if (fromDate.HasValue)
                query = query.Where(ou => ou.UsedAt >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(ou => ou.UsedAt <= toDate.Value);

            return await query.ToListAsync();
        }
    }
}
