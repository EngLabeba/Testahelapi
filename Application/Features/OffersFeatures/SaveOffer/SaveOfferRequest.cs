using MediatR;

namespace Application.Features.OffersFeatures.SaveOffer
{
    public class SaveOfferRequest : IRequest<SaveOfferResponse>
    {
        public int OfferId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? Notes { get; set; } = null;
    }
}
