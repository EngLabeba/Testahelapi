using Application.Repositories;
using MediatR;

namespace Application.Features.OfferUsageFeatures.GetOfferUsageStats
{
    public class GetOfferUsageStatsQueryHandler : IRequestHandler<GetOfferUsageStatsQuery, GetOfferUsageStatsResponse>
    {
        private readonly IOfferUsageRepository _offerUsageRepository;

        public GetOfferUsageStatsQueryHandler(IOfferUsageRepository offerUsageRepository)
        {
            _offerUsageRepository = offerUsageRepository;
        }

        public async Task<GetOfferUsageStatsResponse> Handle(GetOfferUsageStatsQuery request, CancellationToken cancellationToken)
        {
            // Use the repository method that includes all necessary data
            var usages = await _offerUsageRepository.GetOfferUsagesWithFiltersAsync(
                request.OfferId,
                request.EmployeeId,
                request.DependentId,
                request.FromDate,
                request.ToDate);

            var response = new GetOfferUsageStatsResponse
            {
                TotalUsages = usages.Count(),
                TotalAmountSaved = usages.Where(u => u.AmountSaved.HasValue).Sum(u => u.AmountSaved.Value),
                VerifiedUsages = usages.Count(u => u.IsVerified),
                UnverifiedUsages = usages.Count(u => !u.IsVerified)
            };

            // Get top used offers - handle null navigation properties
            response.TopUsedOffers = usages
                .Where(u => u.Offer != null)
                .GroupBy(u => new { u.OfferId, OfferName = u.Offer?.Name ?? "Unknown" })
                .Select(g => new OfferUsageStat
                {
                    OfferId = g.Key.OfferId,
                    OfferName = g.Key.OfferName,
                    UsageCount = g.Count(),
                    TotalAmountSaved = g.Where(u => u.AmountSaved.HasValue).Sum(u => u.AmountSaved.Value)
                })
                .OrderByDescending(s => s.UsageCount)
                .Take(10)
                .ToList();

            // Get top employees by usage - handle null navigation properties
            response.TopEmployees = usages
                .Where(u => u.Employee != null)
                .GroupBy(u => new { u.EmployeeId, EmployeeName = u.Employee?.Name ?? "Unknown" })
                .Select(g => new EmployeeUsageStat
                {
                    EmployeeId = g.Key.EmployeeId,
                    EmployeeName = g.Key.EmployeeName,
                    UsageCount = g.Count(),
                    TotalAmountSaved = g.Where(u => u.AmountSaved.HasValue).Sum(u => u.AmountSaved.Value)
                })
                .OrderByDescending(s => s.UsageCount)
                .Take(10)
                .ToList();

            return response;
        }
    }
}
