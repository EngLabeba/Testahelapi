using Application.Repositories;
using MediatR;

namespace Application.Features.OfferUsageFeatures.GetOfferUsageStats
{
    public class GetOfferUsageStatsQuery : IRequest<GetOfferUsageStatsResponse>
    {
        public int? OfferId { get; set; }
        public int? EmployeeId { get; set; }
        public int? DependentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetOfferUsageStatsResponse
    {
        public int TotalUsages { get; set; }
        public decimal TotalAmountSaved { get; set; }
        public int VerifiedUsages { get; set; }
        public int UnverifiedUsages { get; set; }
        public List<OfferUsageStat> TopUsedOffers { get; set; } = new();
        public List<EmployeeUsageStat> TopEmployees { get; set; } = new();
    }

    public class OfferUsageStat
    {
        public int OfferId { get; set; }
        public string OfferName { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public decimal TotalAmountSaved { get; set; }
    }

    public class EmployeeUsageStat
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int UsageCount { get; set; }
        public decimal TotalAmountSaved { get; set; }
    }
}
