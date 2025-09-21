namespace Application.Features.OffersFeatures.GetSharingMethods
{
    public class GetOfferSharingMethodsResponse
    {
        public int OfferId { get; set; }
        public string OfferTitle { get; set; } = string.Empty;
        public List<SharingMethodItem> SharingMethods { get; set; } = new List<SharingMethodItem>();
        public int TotalCount { get; set; }
    }

    public class SharingMethodItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEnglish { get; set; }
        public bool IsActive { get; set; }
    }
}
