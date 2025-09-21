using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.OfferUsageFeatures.UseOffer
{
    public class RecordOfferUsageCommandHandler : IRequestHandler<RecordOfferUsageCommand, RecordOfferUsageResponse>
    {
        private readonly IOfferUsageRepository _offerUsageRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDependentRepository _dependentRepository;

        public RecordOfferUsageCommandHandler(
            IOfferUsageRepository offerUsageRepository,
            IOfferRepository offerRepository,
            IEmployeeRepository employeeRepository,
            IDependentRepository dependentRepository)
        {
            _offerUsageRepository = offerUsageRepository;
            _offerRepository = offerRepository;
            _employeeRepository = employeeRepository;
            _dependentRepository = dependentRepository;
        }

        public async Task<RecordOfferUsageResponse> Handle(RecordOfferUsageCommand request, CancellationToken cancellationToken)
        {
            // Validate that the offer exists and is active
            var offer = await _offerRepository.GetByIdAsync(request.OfferId);
            if (offer == null || !offer.IsActive)
            {
                return new RecordOfferUsageResponse
                {
                    Success = false,
                    Message = "Offer not found or inactive"
                };
            }

            // Validate that the offer is still valid
            if (DateTime.UtcNow < offer.ValidFrom || DateTime.UtcNow > offer.ValidUntil)
            {
                return new RecordOfferUsageResponse
                {
                    Success = false,
                    Message = "Offer is not currently valid"
                };
            }

            // Validate employee exists
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null || !employee.IsActive)
            {
                return new RecordOfferUsageResponse
                {
                    Success = false,
                    Message = "Employee not found or inactive"
                };
            }

            // Validate dependent exists
            var dependent = await _dependentRepository.GetByIdAsync(request.DependentId);
            if (dependent == null || !dependent.IsActive)
            {
                return new RecordOfferUsageResponse
                {
                    Success = false,
                    Message = "Dependent not found or inactive"
                };
            }

            // Check if this employee has already used this offer for this dependent
            var hasUsed = await _offerUsageRepository.HasEmployeeUsedOfferForDependentAsync(
                request.OfferId, request.EmployeeId, request.DependentId);

            if (hasUsed)
            {
                return new RecordOfferUsageResponse
                {
                    Success = false,
                    Message = "This employee has already used this offer for this dependent"
                };
            }

            // Record the offer usage
            var offerUsage = await _offerUsageRepository.RecordOfferUsageAsync(
                request.OfferId,
                request.EmployeeId,
                request.DependentId,
                request.Notes,
                request.LocationUsed,
                request.AmountSaved);

            // Get the updated usage count
            var usageCount = await _offerUsageRepository.GetUsageCountForOfferAsync(request.OfferId);

            return new RecordOfferUsageResponse
            {
                Success = true,
                Message = "Offer used successfully",
                OfferUsage = offerUsage,
                NewUsageCount = usageCount
            };
        }
    }
}
