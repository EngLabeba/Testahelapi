using Domain.Entities;

namespace Application.Features.OffersFeatures.GetSavedOffers
{
    public class GetSavedOffersResponse
    {
        public List<SavedOfferItem> SavedOffers { get; set; } = new List<SavedOfferItem>();
        public int TotalCount { get; set; }
    }

    public class SavedOfferItem
    {
        public int SavedOfferId { get; set; }
        public int OfferId { get; set; }
        public string OfferTitle { get; set; } = string.Empty;
        public string OfferDescription { get; set; } = string.Empty;
        public string OfferName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string DiscountValue { get; set; } = string.Empty;
        public string? OrganizationName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsCurrentlyValid { get; set; }
        public decimal? Rating { get; set; }
        public int RatingCount { get; set; }
        public int CurrentUses { get; set; }
        public DateTime SavedAt { get; set; }
        public string? Notes { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }
    }
}
