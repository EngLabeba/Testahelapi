using MediatR;

namespace Application.Features.QrCodeFeatures.GenerateCustomQrCode
{
    public class GenerateCustomQrCodeRequest : IRequest<GenerateCustomQrCodeResponse>
    {
        public string Data { get; set; } = string.Empty;
        public int Size { get; set; } = 200;
    }
}
