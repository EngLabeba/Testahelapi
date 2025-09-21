using MediatR;

namespace Application.Features.CategoryFeatures.GetAll;

public sealed record GetAllCategoriesRequest() : IRequest<IEnumerable<GetAllCategoriesResponse>>;
