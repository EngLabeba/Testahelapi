using Application.Common.Models;
using MediatR;

namespace Application.Features.OffersFeatures.GetFiltered
{
    public class GetFilteredOffersRequest : IRequest<PaginatedList<GetFilteredOffersResponse>>
    {
        public PaginationInput PaginationInput { get; set; } = new();
        
        public int? CategoryId { get; set; } = null;
        
        public string? UserId { get; set; } = null;
        
        public double? UserLatitude { get; set; } = null;
        
        public double? UserLongitude { get; set; } = null;
        
        public OfferFilterType FilterType { get; set; } = OfferFilterType.LastInserted;
    }
    
    public enum OfferFilterType
    {
        NoFilter = 0,
        NearestLocation = 1,
        LastInserted = 2,
        MaxUsed = 3,
        HigherEvaluation = 4
    }
}
