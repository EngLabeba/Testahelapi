using Application.Common.Models;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(OffersDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Offer>> GetAllOffersAsync()
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
               
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
             
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Offer>> GetOffersByCategoryAsync(int categoryId)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
             
                .Where(o => o.CategoryId == categoryId && o.IsActive)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByLocationAsync(int locationId)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
               
                .Where(o => o.Locations.Any(l => l.Id == locationId) && o.IsActive)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByPlatformAsync(int platformId)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
              
                .Where(o => o.Platforms.Any(p => p.Id == platformId) && o.IsActive)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersBySharingMethodAsync(int sharingMethodId)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
               
                .Where(o => o.SharingMethods.Any(s => s.Id == sharingMethodId) && o.IsActive)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByDependentAsync(int dependentId)
        {
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
              
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            var now = DateTime.UtcNow;
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
           
                .Where(o => o.IsActive && 
                           o.ValidFrom <= now && o.ValidUntil > now 
                           )
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> SearchOffersAsync(string searchTerm)
        {
            var term = searchTerm.ToLower();
            return await Context.Offers
                .Include(o => o.Category)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
               
                .Where(o => o.IsActive &&
                           (o.Title.ToLower().Contains(term) ||
                            o.Description.ToLower().Contains(term) ||
                            o.Name!.ToLower().Contains(term) ||
                            o.Category.Name.ToLower().Contains(term)))
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public Task<Offer> CreateOfferAsync(Offer offer)
        {
            offer.CreatedAt = DateTime.UtcNow;
            Context.Offers.Add(offer);
            // Note: SaveChangesAsync is now handled by Unit of Work
            return Task.FromResult(offer);
        }

        public async Task<Offer> UpdateOfferAsync(Offer offer)
        {
            var existingOffer = await Context.Offers.FindAsync(offer.Id);
            if (existingOffer == null)
                throw new ArgumentException("Offer not found");

            Context.Entry(existingOffer).CurrentValues.SetValues(offer);
            // Note: SaveChangesAsync is now handled by Unit of Work
            return existingOffer;
        }

        public async Task<bool> DeleteOfferAsync(int id)
        {
            var offer = await Context.Offers.FindAsync(id);
            if (offer == null)
                return false;

            Context.Offers.Remove(offer);
            // Note: SaveChangesAsync is now handled by Unit of Work
            return true;
        }

        public async Task<bool> SaveOfferForUserAsync(int offerId, string userId, string? notes = null)
        {
            var existingSaved = await Context.SavedOffers
                .FirstOrDefaultAsync(s => s.OfferId == offerId && s.UserId == userId);

            if (existingSaved != null)
                return false; // Already saved

            var savedOffer = new SavedOffer
            {
                OfferId = offerId,
                UserId = userId,
                Notes = notes,
                SavedAt = DateTime.UtcNow
            };

            Context.SavedOffers.Add(savedOffer);
            // Note: SaveChangesAsync is now handled by Unit of Work
            return true;
        }

        public async Task<IEnumerable<SavedOffer>> GetUserSavedOffersAsync(string userId)
        {
            return await Context.SavedOffers
                .Include(s => s.Offer)
                .ThenInclude(o => o.Category)
                .Include(s => s.Offer)
                .ThenInclude(o => o.Locations)
                .Include(s => s.Offer)
                .ThenInclude(o => o.Platforms)
                .Include(s => s.Offer)
                .ThenInclude(o => o.SharingMethods)
                .Include(s => s.Offer)
                
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SavedAt)
                .ToListAsync();
        }

        public async Task<bool> RemoveSavedOfferAsync(int offerId, string userId)
        {
            var savedOffer = await Context.SavedOffers
                .FirstOrDefaultAsync(s => s.OfferId == offerId && s.UserId == userId);

            if (savedOffer == null)
                return false;

            Context.SavedOffers.Remove(savedOffer);
            // Note: SaveChangesAsync is now handled by Unit of Work
            return true;
        }

        public async Task<PaginatedList<Offer>> GetPaginatedByCategoryAsync(PaginationInput paginationInput, int? categoryId, string? userId, double? userLatitude, double? userLongitude, CancellationToken cancellationToken)
        {
            IQueryable<Offer> tempQueryable = Context.Offers
                .Where(o => o.IsActive == true)
                .Include(o => o.Locations)
                .AsNoTracking();

            // Apply category filter if provided
            if (categoryId.HasValue)
            {
                tempQueryable = tempQueryable.Where(o => o.CategoryId == categoryId.Value);
            }

            if (paginationInput.GetAll != null && paginationInput.GetAll == true)
            {
                var items = await tempQueryable.ToListAsync(cancellationToken: cancellationToken);
                var count = await tempQueryable.CountAsync(cancellationToken: cancellationToken);
                return new PaginatedList<Offer>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
            else
            {
                var items = await tempQueryable
                    .Skip((paginationInput.CurrentPage - 1) * paginationInput.TakenRows)
                    .Take(paginationInput.TakenRows)
                    .ToListAsync(cancellationToken: cancellationToken);

                var count = await tempQueryable.CountAsync(cancellationToken: cancellationToken);
                return new PaginatedList<Offer>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
        }

        public async Task<PaginatedList<Offer>> GetFilteredOffersAsync(PaginationInput paginationInput, int? categoryId, string? userId, double? userLatitude, double? userLongitude, Application.Features.OffersFeatures.GetFiltered.OfferFilterType filterType, CancellationToken cancellationToken)
        {
            IQueryable<Offer> tempQueryable = Context.Offers
                .Where(o => o.IsActive == true)
                .Include(o => o.Locations)
                .AsNoTracking();

            // Apply category filter if provided
            if (categoryId.HasValue)
            {
                tempQueryable = tempQueryable.Where(o => o.CategoryId == categoryId.Value);
            }

            // Apply filtering based on filter type
            switch (filterType)
            {
                case Application.Features.OffersFeatures.GetFiltered.OfferFilterType.NoFilter:
                    // No specific ordering - use default (by Id)
                    tempQueryable = tempQueryable.OrderBy(o => o.Id);
                    break;

                case Application.Features.OffersFeatures.GetFiltered.OfferFilterType.NearestLocation:
                    if (userLatitude.HasValue && userLongitude.HasValue)
                    {
                        // For nearest location, we'll order by CreatedAt as a proxy since we can't do complex distance calculations in SQL
                        // The actual distance calculation will be done in the handler
                        tempQueryable = tempQueryable.OrderByDescending(o => o.CreatedAt);
                    }
                    else
                    {
                        tempQueryable = tempQueryable.OrderByDescending(o => o.CreatedAt);
                    }
                    break;

                case Application.Features.OffersFeatures.GetFiltered.OfferFilterType.LastInserted:
                    tempQueryable = tempQueryable.OrderByDescending(o => o.CreatedAt);
                    break;

                case Application.Features.OffersFeatures.GetFiltered.OfferFilterType.MaxUsed:
                    // Order by CurrentUses field from Offer table
                    tempQueryable = tempQueryable.OrderByDescending(o => o.CurrentUses);
                    break;

                case Application.Features.OffersFeatures.GetFiltered.OfferFilterType.HigherEvaluation:
                    // Order by Rating field from Offer table
                    tempQueryable = tempQueryable.OrderByDescending(o => o.Rating);
                    break;

                default:
                    tempQueryable = tempQueryable.OrderByDescending(o => o.CreatedAt);
                    break;
            }

            if (paginationInput.GetAll != null && paginationInput.GetAll == true)
            {
                var items = await tempQueryable.ToListAsync(cancellationToken: cancellationToken);
                var count = await tempQueryable.CountAsync(cancellationToken: cancellationToken);
                return new PaginatedList<Offer>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
            else
            {
                var items = await tempQueryable
                    .Skip((paginationInput.CurrentPage - 1) * paginationInput.TakenRows)
                    .Take(paginationInput.TakenRows)
                    .ToListAsync(cancellationToken: cancellationToken);

                var count = await tempQueryable.CountAsync(cancellationToken: cancellationToken);
                return new PaginatedList<Offer>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
        }

        public async Task<Offer?> GetOfferDetailsAsync(int offerId, CancellationToken cancellationToken)
        {
            return await Context.Offers
                .Where(o => o.Id == offerId && o.IsActive == true)
                .Include(o => o.Category)
                .Include(o => o.DiscountType)
                .Include(o => o.Employee)
                .Include(o => o.Locations)
                .Include(o => o.Platforms)
                .Include(o => o.SharingMethods)
                .Include(o => o.SavedOffers)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Domain.Entities.OfferSharingMethod>> GetOfferSharingMethodsAsync(int offerId, CancellationToken cancellationToken)
        {
            // Query the junction table OfferOfferSharingMethod to get sharing methods for the offer
            var offer = await Context.Offers
                .Where(o => o.Id == offerId && o.IsActive == true)
                .Include(o => o.SharingMethods.Where(sm => sm.IsActive == true))
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            return offer?.SharingMethods ?? new List<Domain.Entities.OfferSharingMethod>();
        }

    }                                           
}