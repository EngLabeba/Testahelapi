using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Entities;
using MediatR;
using Application.Common.Services;

namespace Application.Features.QrCodeFeatures.GetQrCodeImage;

public sealed class GetQrCodeImageHandler : IRequestHandler<GetQrCodeImageRequest, GetQrCodeImageResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferShareService _offerShareService;
    private readonly IQrCodeService _qrCodeService;

    public GetQrCodeImageHandler(
        IUnitOfWork unitOfWork,
        IOfferShareService offerShareService,
        IQrCodeService qrCodeService)
    {
        _unitOfWork = unitOfWork;
        _offerShareService = offerShareService;
        _qrCodeService = qrCodeService;
    }

    public async Task<GetQrCodeImageResponse> Handle(GetQrCodeImageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get offer share
            var offerShare = await _offerShareService.GetOfferShareByIdAsync(request.OfferShareId);
            
            if (offerShare == null)
            {
                throw new BusinessException(new Exception("Offer share not found"), "offer_share_not_found", nameof(OfferShare));
            }

            // Generate QR code as bytes
            var qrCodeBytes = _qrCodeService.GenerateQrCodeBytes(offerShare.QrCodeData, request.Size);

            await _unitOfWork.Save(cancellationToken);

            return new GetQrCodeImageResponse
            {
                QrCodeBytes = qrCodeBytes,
                FileName = $"qr-code-{offerShare.QrCodeIdentifier}.png",
                ContentType = "image/png",
                Success = true,
                ErrorMessage = null
            };
        }
        catch (BusinessException)
        {
            throw new BusinessException(new Exception("Offer share not found"), "offer_share_not_found", nameof(OfferShare));
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_qr_code_image", nameof(OfferShare));
        }
    }
}
