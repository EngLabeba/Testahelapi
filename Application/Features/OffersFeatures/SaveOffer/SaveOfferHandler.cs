using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.OffersFeatures.SaveOffer;

public sealed class SaveOfferHandler : IRequestHandler<SaveOfferRequest, SaveOfferResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;

    public SaveOfferHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
    }

    public async Task<SaveOfferResponse> Handle(SaveOfferRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if offer exists and is active
            var offer = await _offerRepository.GetByIdAsync(request.OfferId);
            if (offer == null || !offer.IsActive)
            {
                throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
            }

            // Check if offer is already saved by this user
            var existingSavedOffer = await _offerRepository.ExistsAsync(o => 
                o.Id == request.OfferId && 
                o.SavedOffers.Any(s => s.UserId == request.UserId));

            if (existingSavedOffer)
            {
                throw new BusinessException(new Exception("Offer is already saved by this user"), "offer_already_saved", nameof(SavedOffer));
            }

            // Save the offer for the user
            var success = await _offerRepository.SaveOfferForUserAsync(request.OfferId, request.UserId, request.Notes);
            
            if (!success)
            {
                throw new BusinessException(new Exception("Failed to save offer"), "save_offer_failed", nameof(SavedOffer));
            }

            await _unitOfWork.Save(cancellationToken);

            // Get the saved offer details for response
            var savedOffers = await _offerRepository.GetUserSavedOffersAsync(request.UserId);
            var savedOffer = savedOffers.FirstOrDefault(s => s.OfferId == request.OfferId);

            return new SaveOfferResponse
            {
                Success = true,
                Message = "Offer saved successfully",
                SavedOfferId = savedOffer?.Id ?? 0,
                OfferId = request.OfferId,
                UserId = request.UserId,
                SavedAt = savedOffer?.SavedAt ?? DateTime.UtcNow,
                Notes = request.Notes
            };
        }
        catch (BusinessException)
        {
            throw new BusinessException(new Exception("general_save_offer"), "general_save_offer", nameof(Offer));
        
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_save_offer", nameof(SavedOffer));
        }
    }
}
