using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.OffersFeatures.GetSharingMethods;

public sealed class GetOfferSharingMethodsHandler : IRequestHandler<GetOfferSharingMethodsRequest, GetOfferSharingMethodsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;

    public GetOfferSharingMethodsHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
    }

    public async Task<GetOfferSharingMethodsResponse> Handle(GetOfferSharingMethodsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if offer exists and is active
            var offer = await _offerRepository.GetByIdAsync(request.OfferId);
            if (offer == null || !offer.IsActive)
            {
                throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
            }

            // Get sharing methods for the offer
            var sharingMethods = await _offerRepository.GetOfferSharingMethodsAsync(request.OfferId, cancellationToken);
            
            await _unitOfWork.Save(cancellationToken);

            // Map sharing methods to response items
            var sharingMethodItems = new List<SharingMethodItem>();
            
            foreach (var sharingMethod in sharingMethods)
            {
                var item = new SharingMethodItem
                {
                    Id = sharingMethod.Id,
                    Name = sharingMethod.Name,
                    NameEnglish = sharingMethod.Name,
                    IconUrl = sharingMethod.Icon,
                    Description = sharingMethod.Description,
                    DescriptionEnglish = sharingMethod.Description,
                    IsActive = sharingMethod.IsActive
                };

                sharingMethodItems.Add(item);
            }

            return new GetOfferSharingMethodsResponse
            {
                OfferId = request.OfferId,
                OfferTitle = offer.Title,
                SharingMethods = sharingMethodItems,
                TotalCount = sharingMethodItems.Count
            };
        }
        catch (BusinessException)
        {
            throw new BusinessException(new Exception("general_get_offer_sharing_methods"), "general_get_offer_sharing_methods", nameof(OfferSharingMethod));
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_offer_sharing_methods", nameof(OfferSharingMethod));
        }
    }
}
