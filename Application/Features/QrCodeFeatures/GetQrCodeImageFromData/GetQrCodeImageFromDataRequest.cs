using MediatR;

namespace Application.Features.QrCodeFeatures.GetQrCodeImageFromData
{
    public class GetQrCodeImageFromDataRequest : IRequest<GetQrCodeImageFromDataResponse>
    {
        public string Data { get; set; } = string.Empty;
        public int Size { get; set; } = 200;
    }
}
