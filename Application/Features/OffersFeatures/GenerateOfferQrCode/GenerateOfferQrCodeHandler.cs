using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Common.Services;

namespace Application.Features.OffersFeatures.GenerateOfferQrCode;

public sealed class GenerateOfferQrCodeHandler : IRequestHandler<GenerateOfferQrCodeRequest, GenerateOfferQrCodeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;
    private readonly IMapper _mapper;
    private readonly IQrCodeService _qrCodeService;

    public GenerateOfferQrCodeHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository,
        IMapper mapper,
        IQrCodeService qrCodeService)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
        _mapper = mapper;
        _qrCodeService = qrCodeService;
    }

    public async Task<GenerateOfferQrCodeResponse> Handle(GenerateOfferQrCodeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get offer with all related data
            var offer = await _offerRepository.GetOfferDetailsAsync(request.OfferId, cancellationToken);
            
            if (offer == null)
            {
                throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
            }

            // Generate QR code data
            string qrCodeData;
            if (!string.IsNullOrEmpty(request.CustomData))
            {
                // Use custom data if provided
                qrCodeData = request.CustomData;
            }
            else
            {
                // Generate default QR code data with offer information
                qrCodeData = GenerateOfferQrCodeData(offer);
            }

            // Generate QR code as base64
            var qrCodeBase64 = _qrCodeService.GenerateQrCodeBase64(qrCodeData, request.Size);

            await _unitOfWork.Save(cancellationToken);

            // Map offer to response
            var response = _mapper.Map<GenerateOfferQrCodeResponse>(offer);
            
            // Set QR code specific properties
            response.QrCodeBase64 = qrCodeBase64;
            response.QrCodeData = qrCodeData;
            response.Success = true;
            response.ErrorMessage = null;

            // Set additional calculated properties
            response.IsCurrentlyValid = DateTime.UtcNow >= offer.ValidFrom && DateTime.UtcNow <= offer.ValidUntil;
            
            // Set category information
            if (offer.Category != null)
            {
                response.CategoryName = offer.Category.Name;
            }

            // Set discount type information
            if (offer.DiscountType != null)
            {
                response.DiscountTypeName = offer.DiscountType.Name;
            }

            // Set employee information
            if (offer.Employee != null)
            {
                response.EmployeeId = offer.Employee.Id;
                response.EmployeeName = offer.Employee.Name;
                response.EmployeeNameEnglish = offer.Employee.NameEnglish;
            }

            return response;
        }
        catch (BusinessException)
        {
            throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_generate_offer_qr_code", nameof(Offer));
        }
    }

    private string GenerateOfferQrCodeData(Offer offer)
    {
        // Create a structured QR code data with offer information
        var qrData = new
        {
            type = "offer",
            offerId = offer.Id,
            title = offer.Title,
            description = offer.Description,
            organizationName = offer.OrganizationName,
            validUntil = offer.ValidUntil.ToString("yyyy-MM-dd"),
            discountValue = offer.DiscountValue,
            categoryName = offer.Category?.Name,
            locations = offer.Locations.Select(l => new
            {
                name = l.Name,
                address = l.Address,
                latitude = l.Latitude,
                longitude = l.Longitude
            }).ToList(),
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
        };

        return System.Text.Json.JsonSerializer.Serialize(qrData);
    }
}
