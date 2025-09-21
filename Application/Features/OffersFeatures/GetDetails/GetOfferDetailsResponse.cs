using Domain.Entities;

namespace Application.Features.OffersFeatures.GetDetails
{
    public class GetOfferDetailsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
        // Category Information
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
      
        
        // Discount Information
        public int DiscountTypeId { get; set; }
        public string DiscountTypeName { get; set; } = string.Empty;
        public string DiscountValue { get; set; } = string.Empty;
        
        // Validity Period
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsCurrentlyValid { get; set; }
        
        // Organization Information
        public string? OrganizationName { get; set; }
        public string? OrganizationNameEnglish { get; set; }
        
        // Rating Information
        public decimal? Rating { get; set; }
        public int RatingCount { get; set; }
        
        // Usage Information
        public int CurrentUses { get; set; }
        
        // Employee Information
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeNameEnglish { get; set; }
        
        // Media
        public string? ImageUrl { get; set; }
        public string? DirectionsUrl { get; set; }
        
        // Terms and Conditions
        public string? TermsAndConditions { get; set; }
        
        // Location Information
        public List<OfferLocationDetails> Locations { get; set; } = new List<OfferLocationDetails>();
        
        // Platform Information
        public List<OfferPlatformDetails> Platforms { get; set; } = new List<OfferPlatformDetails>();
        
        // Sharing Method Information
        public List<OfferSharingMethodDetails> SharingMethods { get; set; } = new List<OfferSharingMethodDetails>();
        
        // User-specific Information
        public bool IsSaved { get; set; }
        public double? DistanceInKm { get; set; }
        
        // Metadata
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
    
    public class OfferLocationDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? AddressEnglish { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? DistanceInKm { get; set; }
        public string? DirectionsUrl { get; set; }
    }
    
    public class OfferPlatformDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
    }
    
    public class OfferSharingMethodDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
    }
}
