using MediatR;

namespace Application.Features.DependentsFeatures.GetAll
{
    public class GetAllDependentsRequest : IRequest<GetAllDependentsResponse>
    {
        // No parameters needed - gets all dependents
    }
}
