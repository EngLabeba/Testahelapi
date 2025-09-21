using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.OffersFeatures.GetSavedOffers;

public sealed class GetSavedOffersHandler : IRequestHandler<GetSavedOffersRequest, GetSavedOffersResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;

    public GetSavedOffersHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
    }

    public async Task<GetSavedOffersResponse> Handle(GetSavedOffersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get all saved offers for the user
            var savedOffers = await _offerRepository.GetUserSavedOffersAsync(request.UserId);
            
            await _unitOfWork.Save(cancellationToken);

            // Map saved offers to response items
            var savedOfferItems = new List<SavedOfferItem>();
            
            foreach (var savedOffer in savedOffers)
            {
                if (savedOffer.Offer != null)
                {
                    var item = new SavedOfferItem
                    {
                        SavedOfferId = savedOffer.Id,
                        OfferId = savedOffer.OfferId,
                        OfferTitle = savedOffer.Offer.Title,
                        OfferDescription = savedOffer.Offer.Description,
                        OfferName = savedOffer.Offer.Name,
                        CategoryName = savedOffer.Offer.Category?.Name ?? string.Empty,
                        DiscountValue = savedOffer.Offer.DiscountValue,
                        OrganizationName = savedOffer.Offer.OrganizationName,
                        ImageUrl = savedOffer.Offer.ImageUrl,
                        ValidFrom = savedOffer.Offer.ValidFrom,
                        ValidUntil = savedOffer.Offer.ValidUntil,
                        IsCurrentlyValid = DateTime.UtcNow >= savedOffer.Offer.ValidFrom && DateTime.UtcNow <= savedOffer.Offer.ValidUntil,
                        Rating = savedOffer.Offer.Rating,
                        RatingCount = savedOffer.Offer.RatingCount,
                        CurrentUses = savedOffer.Offer.CurrentUses,
                        SavedAt = savedOffer.SavedAt,
                        Notes = savedOffer.Notes,
                        IsUsed = savedOffer.IsUsed,
                        UsedAt = savedOffer.UsedAt
                    };

                    savedOfferItems.Add(item);
                }
            }

            // Order by saved date (newest first)
            savedOfferItems = savedOfferItems.OrderByDescending(x => x.SavedAt).ToList();

            return new GetSavedOffersResponse
            {
                SavedOffers = savedOfferItems,
                TotalCount = savedOfferItems.Count
            };
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_saved_offers", nameof(SavedOffer));
        }
    }
}
