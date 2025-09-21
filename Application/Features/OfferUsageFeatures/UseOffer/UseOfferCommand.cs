using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.OfferUsageFeatures.UseOffer
{
    public class RecordOfferUsageCommand : IRequest<RecordOfferUsageResponse>
    {
        public int OfferId { get; set; }
        public int EmployeeId { get; set; }
        public int DependentId { get; set; }
        public string? Notes { get; set; }
        public string? LocationUsed { get; set; }
        public decimal? AmountSaved { get; set; }
    }

    public class RecordOfferUsageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public OfferUsage? OfferUsage { get; set; }
        public int NewUsageCount { get; set; }
    }
}
