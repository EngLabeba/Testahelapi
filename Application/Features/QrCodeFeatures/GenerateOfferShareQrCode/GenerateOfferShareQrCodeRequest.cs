using MediatR;

namespace Application.Features.QrCodeFeatures.GenerateOfferShareQrCode
{
    public class GenerateOfferShareQrCodeRequest : IRequest<GenerateOfferShareQrCodeResponse>
    {
        public int OfferShareId { get; set; }
        public int Size { get; set; } = 300;
    }
}
