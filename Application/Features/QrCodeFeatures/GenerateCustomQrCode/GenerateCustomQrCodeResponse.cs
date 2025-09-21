namespace Application.Features.QrCodeFeatures.GenerateCustomQrCode
{
    public class GenerateCustomQrCodeResponse
    {
        public string QrCodeBase64 { get; set; } = string.Empty;
        public string QrCodeData { get; set; } = string.Empty;
        public string? QrCodeIdentifier { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
