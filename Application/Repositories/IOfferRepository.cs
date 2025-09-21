using Application.Common.Models;
using Application.Common.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IOfferRepository :  IBaseRepository<Offer>
    {
        Task<IEnumerable<Offer>> GetAllOffersAsync();
        Task<Offer?> GetOfferByIdAsync(int id);
        Task<IEnumerable<Offer>> GetOffersByCategoryAsync(int categoryId);
        Task<IEnumerable<Offer>> GetOffersByLocationAsync(int locationId);
        Task<IEnumerable<Offer>> GetOffersByPlatformAsync(int platformId);
        Task<IEnumerable<Offer>> GetOffersBySharingMethodAsync(int sharingMethodId);
        Task<IEnumerable<Offer>> GetOffersByDependentAsync(int dependentId);
        Task<IEnumerable<Offer>> GetActiveOffersAsync();
        Task<IEnumerable<Offer>> SearchOffersAsync(string searchTerm);
        Task<Offer> CreateOfferAsync(Offer offer);
        Task<Offer> UpdateOfferAsync(Offer offer);
        Task<bool> DeleteOfferAsync(int id);
        Task<bool> SaveOfferForUserAsync(int offerId, string userId, string? notes = null);
        Task<IEnumerable<SavedOffer>> GetUserSavedOffersAsync(string userId);
        Task<bool> RemoveSavedOfferAsync(int offerId, string userId);
        Task<PaginatedList<Offer>> GetPaginatedByCategoryAsync(PaginationInput paginationInput, int? categoryId, string? userId, double? userLatitude, double? userLongitude, CancellationToken cancellationToken);
        Task<PaginatedList<Offer>> GetFilteredOffersAsync(PaginationInput paginationInput, int? categoryId, string? userId, double? userLatitude, double? userLongitude, Application.Features.OffersFeatures.GetFiltered.OfferFilterType filterType, CancellationToken cancellationToken);
        Task<Offer?> GetOfferDetailsAsync(int offerId, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Entities.OfferSharingMethod>> GetOfferSharingMethodsAsync(int offerId, CancellationToken cancellationToken);
    }
}
