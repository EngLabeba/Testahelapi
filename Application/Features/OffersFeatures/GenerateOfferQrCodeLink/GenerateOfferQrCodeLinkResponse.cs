namespace Application.Features.OffersFeatures.GenerateOfferQrCodeLink
{
    public class GenerateOfferQrCodeLinkResponse
    {
        public string QrCodeData { get; set; } = string.Empty;
        public string QrCodeLink { get; set; } = string.Empty;
        public string QrCodeFormat { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        
        // Offer information for reference
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
        
        // Metadata
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
