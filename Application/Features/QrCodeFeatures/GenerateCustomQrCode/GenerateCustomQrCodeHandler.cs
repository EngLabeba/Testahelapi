using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using Application.Common.Services;

namespace Application.Features.QrCodeFeatures.GenerateCustomQrCode;

public sealed class GenerateCustomQrCodeHandler : IRequestHandler<GenerateCustomQrCodeRequest, GenerateCustomQrCodeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQrCodeService _qrCodeService;

    public GenerateCustomQrCodeHandler(
        IUnitOfWork unitOfWork,
        IQrCodeService qrCodeService)
    {
        _unitOfWork = unitOfWork;
        _qrCodeService = qrCodeService;
    }

    public async Task<GenerateCustomQrCodeResponse> Handle(GenerateCustomQrCodeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Generate QR code as base64
            var qrCodeBase64 = _qrCodeService.GenerateQrCodeBase64(request.Data, request.Size);

            await _unitOfWork.Save(cancellationToken);

            return new GenerateCustomQrCodeResponse
            {
                QrCodeBase64 = qrCodeBase64,
                QrCodeData = request.Data,
                QrCodeIdentifier = null,
                Success = true,
                ErrorMessage = null
            };
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_generate_custom_qr_code", nameof(GenerateCustomQrCodeRequest));
        }
    }
}
