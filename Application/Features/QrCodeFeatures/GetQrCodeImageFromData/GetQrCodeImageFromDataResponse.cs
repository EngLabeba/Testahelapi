namespace Application.Features.QrCodeFeatures.GetQrCodeImageFromData
{
    public class GetQrCodeImageFromDataResponse
    {
        public byte[] QrCodeBytes { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = "qr-code.png";
        public string ContentType { get; set; } = "image/png";
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
