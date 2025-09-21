
using Application.Common.Models;
using Domain.Entities;

namespace Application.Features.DeviceFeatures.GetPaginated
{
    public class GetPaginatedOfferResponse 
    {
		public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string DiscountValue { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? DistanceInKm { get; set; }
        public bool IsSaved { get; set; }
        public string? DirectionsUrl { get; set; }
    }
}
