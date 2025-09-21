using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryFeatures.GetAll;

public sealed class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, IEnumerable<GetAllCategoriesResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<GetAllCategoriesResponse>>(categories);
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_all_categories", nameof(OfferCategory));
        }
    }
}
