using Application.Common.Services;

namespace Presentation.Services
{
    public class QrCodeService : IQrCodeService
    {
        public string GenerateQrCodeBase64(string data, int size = 200)
        {
            // Mock implementation - replace with actual QRCoder when package is working
            var mockQrCode = $"QR_CODE_FOR: {data} (Size: {size})";
            var mockBytes = System.Text.Encoding.UTF8.GetBytes(mockQrCode);
            return Convert.ToBase64String(mockBytes);
        }

        public byte[] GenerateQrCodeBytes(string data, int size = 200)
        {
            // Mock implementation - replace with actual QRCoder when package is working
            var mockQrCode = $"QR_CODE_FOR: {data} (Size: {size})";
            return System.Text.Encoding.UTF8.GetBytes(mockQrCode);
        }
    }
}