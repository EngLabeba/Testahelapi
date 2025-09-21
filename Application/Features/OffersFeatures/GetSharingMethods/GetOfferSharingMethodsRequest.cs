using MediatR;

namespace Application.Features.OffersFeatures.GetSharingMethods
{
    public class GetOfferSharingMethodsRequest : IRequest<GetOfferSharingMethodsResponse>
    {
        public int OfferId { get; set; }
    }
}
