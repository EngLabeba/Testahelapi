using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using Application.Common.Services;

namespace Application.Features.QrCodeFeatures.GetQrCodeImageFromData;

public sealed class GetQrCodeImageFromDataHandler : IRequestHandler<GetQrCodeImageFromDataRequest, GetQrCodeImageFromDataResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQrCodeService _qrCodeService;

    public GetQrCodeImageFromDataHandler(
        IUnitOfWork unitOfWork,
        IQrCodeService qrCodeService)
    {
        _unitOfWork = unitOfWork;
        _qrCodeService = qrCodeService;
    }

    public async Task<GetQrCodeImageFromDataResponse> Handle(GetQrCodeImageFromDataRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Generate QR code as bytes
            var qrCodeBytes = _qrCodeService.GenerateQrCodeBytes(request.Data, request.Size);

            await _unitOfWork.Save(cancellationToken);

            return new GetQrCodeImageFromDataResponse
            {
                QrCodeBytes = qrCodeBytes,
                FileName = "qr-code.png",
                ContentType = "image/png",
                Success = true,
                ErrorMessage = null
            };
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_qr_code_image_from_data", nameof(GetQrCodeImageFromDataRequest));
        }
    }
}
