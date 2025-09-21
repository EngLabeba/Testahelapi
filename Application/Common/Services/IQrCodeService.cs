namespace Application.Common.Services
{
    public interface IQrCodeService
    {
        /// <summary>
        /// Generate QR code as base64 string
        /// </summary>
        string GenerateQrCodeBase64(string data, int size = 200);

        /// <summary>
        /// Generate QR code as byte array
        /// </summary>
        byte[] GenerateQrCodeBytes(string data, int size = 200);
    }
}
