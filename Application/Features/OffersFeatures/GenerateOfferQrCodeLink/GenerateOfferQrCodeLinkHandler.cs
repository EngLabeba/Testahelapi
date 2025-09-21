using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OffersFeatures.GenerateOfferQrCodeLink;

public sealed class GenerateOfferQrCodeLinkHandler : IRequestHandler<GenerateOfferQrCodeLinkRequest, GenerateOfferQrCodeLinkResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;
    private readonly IMapper _mapper;

    public GenerateOfferQrCodeLinkHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
        _mapper = mapper;
    }

    public async Task<GenerateOfferQrCodeLinkResponse> Handle(GenerateOfferQrCodeLinkRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get offer with all related data
            var offer = await _offerRepository.GetOfferDetailsAsync(request.OfferId, cancellationToken);
            
            if (offer == null)
            {
                throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
            }

            // Generate QR code data based on format
            string qrCodeData;
            string qrCodeLink;
            string qrCodeFormat = request.QrCodeFormat?.ToLower() ?? "qr-offer";

            if (!string.IsNullOrEmpty(request.CustomData))
            {
                // Use custom data if provided
                qrCodeData = request.CustomData;
                qrCodeLink = request.CustomData;
                qrCodeFormat = "qr-custom";
            }
            else
            {
                // Generate QR code data based on format
                switch (qrCodeFormat)
                {
                    case "qr-offer":
                        qrCodeData = GenerateOfferQrCodeData(offer);
                        qrCodeLink = GenerateOfferQrCodeLink(offer);
                        break;
                    case "qr-share":
                        qrCodeData = GenerateOfferShareQrCodeData(offer);
                        qrCodeLink = GenerateOfferShareQrCodeLink(offer);
                        break;
                    default:
                        qrCodeData = GenerateOfferQrCodeData(offer);
                        qrCodeLink = GenerateOfferQrCodeLink(offer);
                        break;
                }
            }

            await _unitOfWork.Save(cancellationToken);

            // Map offer to response
            var response = _mapper.Map<GenerateOfferQrCodeLinkResponse>(offer);
            
            // Set QR code specific properties
            response.QrCodeData = qrCodeData;
            response.QrCodeLink = qrCodeLink;
            response.QrCodeFormat = qrCodeFormat;
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
            throw new BusinessException(exception, "general_generate_offer_qr_code_link", nameof(Offer));
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

    private string GenerateOfferQrCodeLink(Offer offer)
    {
        // Generate a simple link format: qr-offer-{offerId}-{categoryId}
        var categoryId = offer.CategoryId;
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        return $"qr-offer-{offer.Id}-{categoryId}-{timestamp}";
    }

    private string GenerateOfferShareQrCodeData(Offer offer)
    {
        // Create a share-specific QR code data
        var qrData = new
        {
            type = "offer-share",
            offerId = offer.Id,
            title = offer.Title,
            organizationName = offer.OrganizationName,
            validUntil = offer.ValidUntil.ToString("yyyy-MM-dd"),
            discountValue = offer.DiscountValue,
            shareToken = Guid.NewGuid().ToString("N")[..8], // Short share token
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
        };

        return System.Text.Json.JsonSerializer.Serialize(qrData);
    }

    private string GenerateOfferShareQrCodeLink(Offer offer)
    {
        // Generate a share link format: qr-share-{offerId}-{categoryId}-{shareToken}
        var categoryId = offer.CategoryId;
        var shareToken = Guid.NewGuid().ToString("N")[..8];
        return $"qr-share-{offer.Id}-{categoryId}-{shareToken}";
    }
}
