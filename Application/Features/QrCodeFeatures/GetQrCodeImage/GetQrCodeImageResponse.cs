namespace Application.Features.QrCodeFeatures.GetQrCodeImage
{
    public class GetQrCodeImageResponse
    {
        public byte[] QrCodeBytes { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = "image/png";
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
