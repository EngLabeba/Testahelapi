using Domain.Entities;
using Domain.Common;
using Application.Common.Repositories;

namespace Application.Repositories
{
    public interface IOfferUsageRepository : IBaseRepository<OfferUsage>
    {
        Task<OfferUsage> RecordOfferUsageAsync(int offerId, int employeeId, int dependentId, string? notes = null, string? locationUsed = null, decimal? amountSaved = null);
        Task<IEnumerable<OfferUsage>> GetOfferUsagesByEmployeeAsync(int employeeId);
        Task<IEnumerable<OfferUsage>> GetOfferUsagesByOfferAsync(int offerId);
        Task<IEnumerable<OfferUsage>> GetOfferUsagesByDependentAsync(int dependentId);
        Task<int> GetUsageCountForOfferAsync(int offerId);
        Task<bool> HasEmployeeUsedOfferForDependentAsync(int offerId, int employeeId, int dependentId);
        IQueryable<OfferUsage> GetQueryable();
        Task<IEnumerable<OfferUsage>> GetOfferUsagesWithFiltersAsync(int? offerId = null, int? employeeId = null, int? dependentId = null, DateTime? fromDate = null, DateTime? toDate = null);
    }
}
