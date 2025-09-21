using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.DependentsFeatures.GetAll;

public sealed class GetAllDependentsHandler : IRequestHandler<GetAllDependentsRequest, GetAllDependentsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDependentRepository _dependentRepository;

    public GetAllDependentsHandler(
        IUnitOfWork unitOfWork,
        IDependentRepository dependentRepository)
    {
        _unitOfWork = unitOfWork;
        _dependentRepository = dependentRepository;
    }

    public async Task<GetAllDependentsResponse> Handle(GetAllDependentsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get all active dependents
            var dependents = await _dependentRepository.GetAllDependentsAsync();
            
            await _unitOfWork.Save(cancellationToken);

            // Map dependents to response items
            var dependentItems = new List<DependentItem>();
            
            foreach (var dependent in dependents)
            {
                var item = new DependentItem
                {
                    Id = dependent.Id,
                    Relationship = dependent.Relationship,
                    IsActive = dependent.IsActive,
                    UpdatedAt = dependent.UpdatedAt
                };

                dependentItems.Add(item);
            }

            return new GetAllDependentsResponse
            {
                Dependents = dependentItems,
                TotalCount = dependentItems.Count
            };
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_all_dependents", nameof(Dependent));
        }
    }
}
