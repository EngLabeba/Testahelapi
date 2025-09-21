using MediatR;

namespace Application.Features.OffersFeatures.GenerateOfferQrCodeLink
{
    public class GenerateOfferQrCodeLinkRequest : IRequest<GenerateOfferQrCodeLinkResponse>
    {
        public int OfferId { get; set; }
        public string? CustomData { get; set; } // Optional custom data to encode in QR code
        public string? QrCodeFormat { get; set; } = "qr-offer"; // Format: qr-offer, qr-share, qr-custom
    }
}
