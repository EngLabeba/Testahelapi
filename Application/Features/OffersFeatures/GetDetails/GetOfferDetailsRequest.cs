using MediatR;

namespace Application.Features.OffersFeatures.GetDetails
{
    public class GetOfferDetailsRequest : IRequest<GetOfferDetailsResponse>
    {
        public int OfferId { get; set; }
        
    }
}
