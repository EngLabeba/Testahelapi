using MediatR;

namespace Application.Features.OffersFeatures.GenerateOfferQrCode
{
    public class GenerateOfferQrCodeRequest : IRequest<GenerateOfferQrCodeResponse>
    {
        public int OfferId { get; set; }
        public int Size { get; set; } = 300;
        public string? CustomData { get; set; } // Optional custom data to encode in QR code
    }
}
