using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using Application.Common.Services;

namespace Application.Features.QrCodeFeatures.GenerateOfferShareQrCode;

public sealed class GenerateOfferShareQrCodeHandler : IRequestHandler<GenerateOfferShareQrCodeRequest, GenerateOfferShareQrCodeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferShareService _offerShareService;
    private readonly IQrCodeService _qrCodeService;

    public GenerateOfferShareQrCodeHandler(
        IUnitOfWork unitOfWork,
        IOfferShareService offerShareService,
        IQrCodeService qrCodeService)
    {
        _unitOfWork = unitOfWork;
        _offerShareService = offerShareService;
        _qrCodeService = qrCodeService;
    }

    public async Task<GenerateOfferShareQrCodeResponse> Handle(GenerateOfferShareQrCodeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get offer share
            var offerShare = await _offerShareService.GetOfferShareByIdAsync(request.OfferShareId);
            
            if (offerShare == null)
            {
                throw new BusinessException(new Exception("Offer share not found"), "offer_share_not_found", nameof(OfferShare));
            }

            // Generate QR code as base64
            var qrCodeBase64 = _qrCodeService.GenerateQrCodeBase64(offerShare.QrCodeData, request.Size);

            await _unitOfWork.Save(cancellationToken);

            return new GenerateOfferShareQrCodeResponse
            {
                QrCodeBase64 = qrCodeBase64,
                QrCodeData = offerShare.QrCodeData,
                QrCodeIdentifier = offerShare.QrCodeIdentifier,
                OfferShare = offerShare,
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
            throw new BusinessException(exception, "general_generate_offer_share_qr_code", nameof(OfferShare));
        }
    }
}
