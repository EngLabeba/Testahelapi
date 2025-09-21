using Domain.Entities;

namespace Application.Features.QrCodeFeatures.GenerateOfferShareQrCode
{
    public class GenerateOfferShareQrCodeResponse
    {
        public string QrCodeBase64 { get; set; } = string.Empty;
        public string QrCodeData { get; set; } = string.Empty;
        public string? QrCodeIdentifier { get; set; }
        public OfferShare? OfferShare { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
