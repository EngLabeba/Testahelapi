using AutoMapper;
using Domain.Entities;

namespace Application.Features.CategoryFeatures.GetAll;

public sealed class GetAllCategoriesMapper : Profile
{
    public GetAllCategoriesMapper()
    {
        CreateMap<OfferCategory, GetAllCategoriesResponse>();
    }
}
