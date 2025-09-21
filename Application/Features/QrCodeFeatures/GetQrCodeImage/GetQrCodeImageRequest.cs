using MediatR;

namespace Application.Features.QrCodeFeatures.GetQrCodeImage
{
    public class GetQrCodeImageRequest : IRequest<GetQrCodeImageResponse>
    {
        public int OfferShareId { get; set; }
        public int Size { get; set; } = 300;
    }
}
