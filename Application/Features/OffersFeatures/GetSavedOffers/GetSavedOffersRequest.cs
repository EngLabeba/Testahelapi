using MediatR;

namespace Application.Features.OffersFeatures.GetSavedOffers
{
    public class GetSavedOffersRequest : IRequest<GetSavedOffersResponse>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
