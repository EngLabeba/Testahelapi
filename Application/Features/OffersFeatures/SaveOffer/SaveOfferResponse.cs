namespace Application.Features.OffersFeatures.SaveOffer
{
    public class SaveOfferResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SavedOfferId { get; set; }
        public int OfferId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime SavedAt { get; set; }
        public string? Notes { get; set; }
    }
}
